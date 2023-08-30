import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { InvoiceService } from '../../services/invoice.service';
import { InvoiceModel } from '../../models/invoice-model';
import { Observable, Subscription } from 'rxjs';
import {
  InvoiceStatus,
  InvoiceStatusMap,
} from '../../models/invoice-status.enum';

@Component({
  selector: 'app-create-invoice',
  templateUrl: './create-invoice.component.html',
  styleUrls: ['./create-invoice.component.scss'],
})
export class CreateInvoiceComponent implements OnInit, OnDestroy {
  private subscription: Subscription = new Subscription();
  invoiceForm!: FormGroup;
  statuses$: Observable<InvoiceStatus[]> = new Observable();
  invoiceStatusMap = InvoiceStatusMap;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private invoiceService: InvoiceService
  ) {}

  ngOnInit(): void {
    this.buildInfoiceForm();
    this.getStatuses();
  }

  getStatuses(): void {
    this.statuses$ = this.invoiceService.getAllStatuses();
  }

  onSubmit(): void {
    if (this.invoiceForm.valid) {
      const newInvoice: InvoiceModel = this.invoiceForm.value as InvoiceModel;
      this.subscription.add(
        this.invoiceService.create(newInvoice).subscribe(() => {
          // Redirect to the invoice list page after successful creation
          this.router.navigate(['/']);
        })
      );
    }
  }

  private buildInfoiceForm(): void {
    this.invoiceForm = this.formBuilder.group({
      invoiceDate: ['', Validators.required],
      dueDate: ['', Validators.required],
      status: ['', Validators.required],
      amount: [Validators.required, Validators.min(0)],
    });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
