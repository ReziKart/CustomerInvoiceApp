import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription, Observable, switchMap, tap } from 'rxjs';
import { InvoiceModel } from '../../models/invoice-model';
import {
  InvoiceStatus,
  InvoiceStatusMap,
} from '../../models/invoice-status.enum';
import { InvoiceService } from '../../services/invoice.service';

@Component({
  selector: 'app-edit-invoice',
  templateUrl: './edit-invoice.component.html',
  styleUrls: ['./edit-invoice.component.scss'],
})
export class EditInvoiceComponent implements OnInit, OnDestroy {
  private subscription: Subscription = new Subscription();

  editInvoiceForm!: FormGroup;
  statuses$: Observable<InvoiceStatus[]> = new Observable();
  invoiceStatusMap = InvoiceStatusMap;
  invoice$!: Observable<InvoiceModel>;

  constructor(
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private router: Router,
    private invoiceService: InvoiceService
  ) {}

  ngOnInit(): void {
    this.getStatuses();
    this.buildInvoiceForm();
    this.loadInvoice();
  }

  buildInvoiceForm(): void {
    this.editInvoiceForm = this.formBuilder.group({
      invoiceDate: [Validators.required],
      amount: [Validators.required],
      status: [Validators.required],
      dueDate: [Validators.required],
    });
  }

  loadInvoice(): void {
    this.invoice$ = this.route.paramMap.pipe(
      switchMap((params) => {
        const invoiceId = (params.get('id') ?? 0) as number;
        return this.invoiceService.getById(invoiceId);
      }),
      tap((invoice) => {
        this.editInvoiceForm.patchValue(invoice);
      })
    );
  }

  getStatuses(): void {
    this.statuses$ = this.invoiceService.getAllStatuses();
  }

  saveChanges(): void {
    if (this.editInvoiceForm.valid) {
      const invoice: InvoiceModel = this.editInvoiceForm.value as InvoiceModel;
      this.subscription.add(
        this.invoiceService.edit(invoice).subscribe(() => {
          this.router.navigate(['/invoices']);
        })
      );
    }
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
