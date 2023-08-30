import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { InvoiceListItemDto } from '../models/invoice-list-item-dto';
import { InvoiceStatus } from '../models/invoice-status.enum';
import { InvoiceModel } from '../models/invoice-model';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class InvoiceService {
  private baseUrl: string = `${environment.apiUrl}`;

  constructor(private httpClient: HttpClient) {}

  public getAll(): Observable<InvoiceListItemDto[]> {
    return this.httpClient.get<InvoiceListItemDto[]>(
      this.baseUrl + '/invoices'
    );
  }

  public create(invoice: InvoiceModel): Observable<InvoiceModel> {
    return this.httpClient.post<InvoiceModel>(
      this.baseUrl + '/invoices',
      invoice
    );
  }

  public edit(invoice: InvoiceModel): Observable<InvoiceModel> {
    return this.httpClient.post<InvoiceModel>(
      this.baseUrl + '/invoices',
      invoice
    );
  }

  public getById(id: number): Observable<InvoiceModel> {
    return this.httpClient.get<InvoiceModel>(this.baseUrl + '/invoices/' + id);
  }

  public getAllStatuses(): Observable<InvoiceStatus[]> {
    const statusValues = Object.values(InvoiceStatus) as InvoiceStatus[];
    return of(statusValues.filter((value) => typeof value === 'number'));
  }
}
