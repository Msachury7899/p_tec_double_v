import { CanActivateChildFn, CanActivateFn, Router } from '@angular/router';
import { TokenService } from '../../../../infraestructure/services';
import { inject } from '@angular/core';
import { catchError, map, of } from 'rxjs';

export const validateSessionChildGuard: CanActivateChildFn = (route, state) => {
  const authService:TokenService = inject(TokenService);
  const router:Router = inject(Router);

  return authService.checkSession().pipe(
    map((response)  => {
      return true;
    }),
    catchError(err => {
        router.navigate(['auth/login'])
        return of(false);
    }));
};

export const validateSessionGuard: CanActivateFn = (route, state) => {
  const authService:TokenService = inject(TokenService);
  const router:Router = inject(Router);
  return authService.checkSession().pipe(
    map((response)  => {
      return true;
    }),
    catchError(err => {
      router.navigate(['auth/login'])
      return of(false);
    }));
};
