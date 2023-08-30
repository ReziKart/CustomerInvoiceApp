using System;
using AutoMapper;
using MediatR;
using UniTaskAssignment.Application.Interfaces;
using UniTaskAssignment.Application.ViewModels;
using UniTaskAssignment.Domain.Invoices;

namespace UniTaskAssignment.Application.Commands
{
	public class CreateOrEditInvoiceCommandHandler: IRequestHandler<CreateOrEditInvoiceCommand, CreateOrEditInvoiceDto> 
    {
        private readonly IRepository<Invoice> _invoiceRepositoy;
        private readonly IMapper _mapper;
		public CreateOrEditInvoiceCommandHandler(IRepository<Invoice> invoiceRepositoy, IMapper mapper)
		{
            _invoiceRepositoy = invoiceRepositoy ?? throw new ArgumentNullException(nameof(invoiceRepositoy));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

		}

        public async  Task<CreateOrEditInvoiceDto> Handle(CreateOrEditInvoiceCommand request, CancellationToken cancellationToken)
        {
            _ = new CreateOrEditInvoiceDto();
            var invoice = _mapper.Map<Invoice>(request);
            CreateOrEditInvoiceDto result;
            if (invoice.Id == 0) // create
            {
                var entity = await _invoiceRepositoy.AddAsync(invoice);
                result = _mapper.Map<CreateOrEditInvoiceDto>(entity);
            }
            else // update
            {
                await _invoiceRepositoy.UpdateAsync(invoice);
                result = _mapper.Map<CreateOrEditInvoiceDto>(invoice);
            }
            await _invoiceRepositoy.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}

