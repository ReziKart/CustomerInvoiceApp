import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: '/invoices/list', pathMatch: 'full' },
  {
    path: 'invoices',
    loadChildren: () =>
      import('./features/invoice/invoice.module').then((m) => m.InvoiceModule),
  },
  // Add other routes for different features or components
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
