using System;
using MediatR;
using UniTaskAssignment.Application.ViewModels;

namespace UniTaskAssignment.Application.Queries
{

	public class GetInvoiceQuery: IRequest<CreateOrEditInvoiceDto>
	{
		public GetInvoiceQuery(int id)
		{
			this.Id = id;
		}

		public int Id { get; set; }
	}
}

