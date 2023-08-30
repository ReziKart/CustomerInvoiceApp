import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorInterceptor } from './interceptors/error-interceptor';
import { SharedModule } from '../shared/shared.module';
import { ErrorHandlerService } from './services/http-error-handler.service';

@NgModule({
  declarations: [],
  imports: [CommonModule, SharedModule],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi: true,
    },
    ErrorHandlerService,
  ],
})
export class CoreModule {}
