using System;
using System.Reflection;
using Autofac;
using MediatR;
using UniTaskAssignment.Application.Commands;
using UniTaskAssignment.Application.Queries;

namespace UniTaskAssignment.Api.Infrastructure.AutofacModules
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
            .AsImplementedInterfaces();


            builder.RegisterAssemblyTypes(typeof(CreateOrEditInvoiceCommandHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(GetInvoiceListQueryHandler).GetTypeInfo().Assembly)
              .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(GetInvoiceQueryHandler).GetTypeInfo().Assembly)
             .AsClosedTypesOf(typeof(IRequestHandler<,>));

        }
    }

}

