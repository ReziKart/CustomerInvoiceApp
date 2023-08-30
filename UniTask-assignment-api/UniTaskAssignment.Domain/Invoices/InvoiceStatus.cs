using System;
namespace UniTaskAssignment.Domain.Invoices
{
	public enum InvoiceStatus
	{
        Draft = 0,
        Sent,
        Paid,
        Overdue,
    }
}

