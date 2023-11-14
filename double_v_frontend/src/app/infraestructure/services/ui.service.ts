import { Injectable } from '@angular/core';
import { IDynamicParameters, NAVIGATION_TYPE, ROUTES_APP_NAVIGATION, RoutesNavigation } from '../../presentation/navigation';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class UiService {
  constructor(
    private _router: Router,
    private _toastr: ToastrService,
    private _spinner: NgxSpinnerService
  ) { }

  private addParametersToRoute(route:string,parameters?:IDynamicParameters){
    if(!!parameters == false) return route;
    const trueParameters:IDynamicParameters = parameters as IDynamicParameters;
    console.log(trueParameters)
    for( let param of Object.keys(trueParameters)){
      route = route.replace(`:${param}`,trueParameters[param] as string);
    }

    return route;
  }

  navigate(
    navigation: ROUTES_APP_NAVIGATION,
    navigationType: NAVIGATION_TYPE,
    parameters?:IDynamicParameters
  ) {
    switch(navigationType){
      case NAVIGATION_TYPE.BACKOFFICE:
        this._router.navigate([this.addParametersToRoute(RoutesNavigation[navigation],parameters)]);
        break;
    }
  }

  showSpinner(status:boolean){
    if(status){
      this._spinner.show();
    }else{
      this._spinner.hide();
    }
  }

  showToast({
    tipo,
    titulo,
    mensaje,
  }:{
    tipo:"ERROR" | "SUCCESS";
    titulo: string;
    mensaje:string;
  }){
    if(tipo == "ERROR"){
      this._toastr.error(mensaje,titulo);
    }
    if( tipo == "SUCCESS"){
      this._toastr.success(mensaje, titulo);
    }
  }


}
