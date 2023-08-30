import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InvoiceListComponent } from './components/invoice-list/invoice-list.component';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../../shared/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { CreateInvoiceComponent } from './components/create-invoice/create-invoice.component';
import { InvoiceRoutingModule } from './invoice-routing.module';
import { EditInvoiceComponent } from './components/edit-invoice/edit-invoice.component';

@NgModule({
  declarations: [InvoiceListComponent, CreateInvoiceComponent, EditInvoiceComponent],
  imports: [CommonModule, SharedModule, HttpClientModule, InvoiceRoutingModule],
})
export class InvoiceModule {}
