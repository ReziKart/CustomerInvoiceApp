using Autofac;
using UniTaskAssignment.Application.Interfaces;
using UniTaskAssignment.Domain.Invoices;
using UniTaskAssignment.Persistence.Repositories;

namespace UniTaskAssignment.Api.Infrastructure.AutofacModules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<SqlRepository<Invoice>>().As<IRepository<Invoice>>()
                 .InstancePerLifetimeScope();
        }
    }

}

