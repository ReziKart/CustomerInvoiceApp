export enum InvoiceStatus {
  Draft = 0,
  Sent,
  Paid,
  Overdue,
}

export const InvoiceStatusMap = {
  [InvoiceStatus.Draft]: 'Draft',
  [InvoiceStatus.Sent]: 'Sent',
  [InvoiceStatus.Paid]: 'Paid',
  [InvoiceStatus.Overdue]: 'Overdue',
};
