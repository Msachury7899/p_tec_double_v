import { Injectable } from '@angular/core';
import { Observable, catchError, map, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { LoginRequest } from '../../presentation/request';
import { TokenService } from '../../../../infraestructure/services';
import { ResponseLogin } from '../../presentation/responses';
import { environment } from '../../../../../environments/environment';

@Injectable()
export class LoginService {

  constructor(
    private http: HttpClient,
    private tokenService:TokenService
  ){}

  login(request:LoginRequest):Observable<any> {
    const requestFinal = { ...request };
    return this.http.post<ResponseLogin>(`${environment.api}/auth/login`,requestFinal).pipe(
      catchError(({error}) => of(error))
    );
  }

}
