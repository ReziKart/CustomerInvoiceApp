import { InvoiceStatus } from './invoice-status.enum';

export interface InvoiceModel {
  id: number;
  invoiceDate: Date;
  dueDate: Date;
  amount: number;
  status: InvoiceStatus;
}
