using System;
using AutoMapper;
using UniTaskAssignment.Application.Commands;
using UniTaskAssignment.Application.ViewModels;
using UniTaskAssignment.Domain.Invoices;

namespace UniTaskAssignment.Application.MappingProfiles
{
    public class InvoiceMappingProfile : Profile
    {

        public InvoiceMappingProfile()
        {
            CreateMap<Invoice, CreateOrEditInvoiceDto>();
            CreateMap<CreateOrEditInvoiceCommand, Invoice>();
            CreateMap<Invoice, InvoiceItemDto>();
        }
    }

}

