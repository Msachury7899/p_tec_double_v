import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "../../../../../environments/environment";
import { Observable, map } from "rxjs";
import { Response } from "../../presentation";
import { PersonasResponse } from "../../presentation/responses/persona.response";

@Injectable()
export class PersonasService {


  constructor(
    private http: HttpClient,
  ){}

  getAll():Observable<Array<PersonasResponse>> {
    return this.http.get<Response<Array<PersonasResponse>>>(`${environment.api}/personas`).pipe(
      map((response:Response<Array<PersonasResponse>>) => {
        return response.data;
      })
    );
  }

  create(request:any):Observable<any> {
    return this.http.post<any>(`${environment.api}/personas/createPersona`,request).pipe(
      // map((response:Response<Array<PersonasResponse>>) => {
      //   return response.data;
      // })
    );
  }
}
