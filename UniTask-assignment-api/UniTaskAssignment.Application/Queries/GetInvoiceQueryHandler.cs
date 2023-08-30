using System;
using AutoMapper;
using MediatR;
using UniTaskAssignment.Application.Interfaces;
using UniTaskAssignment.Application.ViewModels;
using UniTaskAssignment.Domain.Invoices;

namespace UniTaskAssignment.Application.Queries
{
	public class GetInvoiceQueryHandler: IRequestHandler<GetInvoiceQuery, CreateOrEditInvoiceDto>
	{
        private readonly IRepository<Invoice> _invoiceRepository;
        private readonly IMapper _mapper;


        public GetInvoiceQueryHandler(IRepository<Invoice> invoiceRepository, IMapper mapper)
		{
            _invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

        public async Task<CreateOrEditInvoiceDto> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
        {
            var invoice = await _invoiceRepository.GetAsync(e => e.Id == request.Id);
            return _mapper.Map<CreateOrEditInvoiceDto>(invoice);
        }
    }
}

