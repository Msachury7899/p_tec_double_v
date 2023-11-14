import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpHeaders
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { TokenService } from '../services';



@Injectable()
export class TokenInterceptor implements HttpInterceptor {


  constructor(
    private tokenService: TokenService
  ) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    request = this.addToken(request);
    return next.handle(request);
  }

  private addToken(request: HttpRequest<unknown>) {
    const tokenApi = this.tokenService.getItemSessionStorage('token');
    if (tokenApi) {
      const authReq = request.clone({
        headers: new HttpHeaders({
          'Authorization' : `Bearer ${tokenApi}`,
          'Content-Type': `application/json`
        })
      });

      return authReq;
    }
    return request;
  }
}
