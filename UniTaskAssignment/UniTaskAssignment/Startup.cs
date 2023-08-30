using System;
using Autofac;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using UniTaskAssignment.Api.Infrastructure.AutofacModules;
using UniTaskAssignment.Application.Interfaces;
using UniTaskAssignment.Application.MappingProfiles;
using UniTaskAssignment.Persistence.Data;

namespace UniTaskAssignment.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;

        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services

                .AddCustomMvc()
                .AddCustomAutoMapper()
                .AddCustomDbContext(Configuration, Env)
                .AddCustomSwagger();
            ContainerBuilder builder = new();
            ConfigureContainer(builder);

        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new MediatorModule());
            builder.RegisterModule(new ApplicationModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
            app.UseCors("CorsPolicy");

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }



    }

    internal class SqlStorageExecutionStrategy : ExecutionStrategy
    {
        public SqlStorageExecutionStrategy(ExecutionStrategyDependencies dependencies, int maxRetryCount, TimeSpan maxRetryDelay)
            : base(dependencies, maxRetryCount, maxRetryDelay)
        {

        }

        protected override bool ShouldRetryOn(Exception exception)
        {
            return true;
        }
    }
    internal static class CustomExtensionsMethods
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<InvoiceDbContext>(options =>
                {
                    options.UseSqlServer(configuration["DefaultConnectionString"], sqlServerOptions =>
                    {
                        sqlServerOptions.ExecutionStrategy(dependencies => new SqlStorageExecutionStrategy(dependencies, 5, TimeSpan.FromMilliseconds(500)));
                    });
                }, ServiceLifetime.Scoped);

            services.AddScoped<IInvoiceDbContext>(sp => sp.GetRequiredService<InvoiceDbContext>());

            return services;
        }

      

        public static IServiceCollection AddCustomAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new InvoiceMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }

        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            services.AddMvc();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            return services;
        }

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }

    }

}

