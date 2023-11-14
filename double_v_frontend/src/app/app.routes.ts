import { Routes } from '@angular/router';
import { validateSessionChildGuard, validateSessionGuard } from './contexts/backoffice/infraestructure/guards/validate-session.guard';

export const routes: Routes = [
  {
    path: "auth",
    loadChildren: () => import('./contexts/auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: "backoffice",
    canActivateChild: [validateSessionChildGuard],
    loadChildren: () => import('./contexts/backoffice/backoffice.module').then(m => m.BackOfficeModule)
  },
  {
    path: '**',
    redirectTo: 'auth/login'
  }

];
