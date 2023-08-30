using System;
using System.Runtime.Serialization;
using MediatR;
using UniTaskAssignment.Application.ViewModels;
using UniTaskAssignment.Domain.Invoices;

namespace UniTaskAssignment.Application.Commands
{
    public class CreateOrEditInvoiceCommand: IRequest<CreateOrEditInvoiceDto>
    {
        public CreateOrEditInvoiceCommand()
        {

        }
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public InvoiceStatus Status { get; set; }
        public decimal Amount { get; set; }
        public Guid CommandId { get; set; }

    }
}

