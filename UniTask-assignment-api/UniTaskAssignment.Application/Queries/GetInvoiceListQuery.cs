using System;
using MediatR;
using UniTaskAssignment.Application.ViewModels;

namespace UniTaskAssignment.Application.Queries
{
	public class GetInvoiceListQuery : IRequest<IList<InvoiceItemDto>>
    {
		public GetInvoiceListQuery()
		{
		}
	}
}

