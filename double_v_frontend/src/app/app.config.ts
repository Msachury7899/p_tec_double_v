import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideAnimations } from '@angular/platform-browser/animations';
import { routes } from './app.routes';
import { provideToastr } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { HTTP_INTERCEPTORS, provideHttpClient } from '@angular/common/http';
import { TokenInterceptor } from './infraestructure/interceptors';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideAnimations(),
    provideToastr(),
    provideHttpClient(),
  ]
};
