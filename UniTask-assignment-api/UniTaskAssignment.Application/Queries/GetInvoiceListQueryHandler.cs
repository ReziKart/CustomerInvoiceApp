using System;
using AutoMapper;
using MediatR;
using UniTaskAssignment.Application.Interfaces;
using UniTaskAssignment.Application.ViewModels;
using UniTaskAssignment.Domain.Invoices;

namespace UniTaskAssignment.Application.Queries
{
	public class GetInvoiceListQueryHandler : IRequestHandler<GetInvoiceListQuery, IList<InvoiceItemDto>>
	{
        private readonly IRepository<Invoice> _invoiceRepository;
        private readonly IMapper _mapper;

        public GetInvoiceListQueryHandler(IRepository<Invoice> invoiceRepository, IMapper mapper)
		{
            _invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

        public async Task<IList<InvoiceItemDto>> Handle(GetInvoiceListQuery request, CancellationToken cancellationToken)
        {
            var invoices = await _invoiceRepository.GetAllAsync();
            return _mapper.Map<IList<InvoiceItemDto>>(invoices);
        }
    }
}

