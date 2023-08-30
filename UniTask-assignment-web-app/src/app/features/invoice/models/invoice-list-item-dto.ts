import { InvoiceStatus } from './invoice-status.enum';

export interface InvoiceListItemDto {
  id: number;
  invoiceDate: Date;
  dueDate: Date;
  amount: number;
  status: InvoiceStatus;
}
