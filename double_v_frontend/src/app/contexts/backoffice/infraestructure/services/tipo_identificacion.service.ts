import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, map } from "rxjs";
import { TipoIdentificacionResponse } from "../../presentation/responses/tipo_identificacion.response";
import { environment } from "../../../../../environments/environment";
import { Response } from "../../presentation";

@Injectable()
export class TipoIdentificacionService {


  constructor(
    private http: HttpClient,
  ){}

  getAll():Observable<Array<TipoIdentificacionResponse>> {
    return this.http.get<Response<Array<TipoIdentificacionResponse>>>(`${environment.api}/tipo_identificacion`).pipe(
      map((response:Response<Array<TipoIdentificacionResponse>>) => {
        return response.data;
      })
    );
  }
}
