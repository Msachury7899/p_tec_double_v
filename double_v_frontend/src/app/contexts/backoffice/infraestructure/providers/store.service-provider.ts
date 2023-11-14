import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { TipoIdentificacionResponse } from '../../presentation/responses/tipo_identificacion.response';
import { PersonasResponse } from '../../presentation/responses/persona.response';

@Injectable()
export class StoreServiceProvider {
  public tipos_identificacion$ = new BehaviorSubject<Array<TipoIdentificacionResponse>>([]);
  public personas$ = new BehaviorSubject<Array<PersonasResponse>>([]);


}
