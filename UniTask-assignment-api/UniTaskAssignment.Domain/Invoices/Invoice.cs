using System;
namespace UniTaskAssignment.Domain.Invoices
{
	public class Invoice
	{
		public Invoice()
		{

		}

		public int Id { get; set; }

		public DateTime InvoiceDate { get; set; }

		public DateTime DueDate { get; set; }

		public decimal Amount { get; set; }

		public InvoiceStatus Status { get; set; }
	}
}

