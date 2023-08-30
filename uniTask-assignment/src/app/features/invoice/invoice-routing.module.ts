import { RouterModule, Routes } from '@angular/router';
import { InvoiceListComponent } from './components/invoice-list/invoice-list.component';
import { NgModule } from '@angular/core';
import { CreateInvoiceComponent } from './components/create-invoice/create-invoice.component';
import { EditInvoiceComponent } from './components/edit-invoice/edit-invoice.component';

const routes: Routes = [
  { path: '', redirectTo: 'list', pathMatch: 'full' },
  { path: 'list', component: InvoiceListComponent },
  { path: 'create', component: CreateInvoiceComponent },
  { path: 'invoices/edit/:id', component: EditInvoiceComponent },
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class InvoiceRoutingModule {}
