﻿using System;
using UniTaskAssignment.Domain.Invoices;

namespace UniTaskAssignment.Application.ViewModels
{
	public class InvoiceItemDto
	{
		public InvoiceItemDto()
		{

		}
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public InvoiceStatus Status { get; set; }
        public decimal Amount { get; set; }
    }
}

