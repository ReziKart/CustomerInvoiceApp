import { Component, OnInit } from '@angular/core';
import { InvoiceListItemDto } from '../../models/invoice-list-item-dto';
import { Observable } from 'rxjs';
import { InvoiceService } from '../../services/invoice.service';
import { Router } from '@angular/router';
import {
  InvoiceStatus,
  InvoiceStatusMap,
} from '../../models/invoice-status.enum';

@Component({
  selector: 'app-invoice-list',
  templateUrl: './invoice-list.component.html',
  styleUrls: ['./invoice-list.component.scss'],
})
export class InvoiceListComponent implements OnInit {
  invoices$: Observable<InvoiceListItemDto[]> = new Observable<
    InvoiceListItemDto[]
  >();
  invoiceStatusMap = InvoiceStatusMap;

  constructor(private router: Router, private invoiceService: InvoiceService) {}

  ngOnInit(): void {
    this.invoices$ = this.invoiceService.getAll();
  }

  onCreate(): void {
    this.router.navigate(['invoices/create']);
  }

  onEdit(id: number): void {
    this.router.navigate(['invoices/edit/' + id]);
  }

  getStatusLabel(status: InvoiceStatus): string {
    return this.invoiceStatusMap[status];
  }
}
