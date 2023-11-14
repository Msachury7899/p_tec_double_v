import { Component, OnDestroy, OnInit } from '@angular/core';
import { LoginService } from '../../../infraestructure/services';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { NAVIGATION_TYPE, ROUTES_APP_NAVIGATION } from '../../../../../presentation/navigation';
import { UiService } from '../../../../../infraestructure/services/ui.service';
import { TokenService } from '../../../../../infraestructure/services';


@Component({
  selector: 'm-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnDestroy {


  form:FormGroup = this.fb.group({
      login: ['',Validators.required],
      password: ['',Validators.required]
  });
  subs = new Subscription();

  constructor(
    private loginService:LoginService,
    private uiService: UiService,
    private fb:FormBuilder,
    private tokenService:TokenService
  ){}

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }



  sendForm(){
    if(this.form.valid){
      this.uiService.showSpinner(true);
      const request = {
        login: this.form.value.login,
        password: this.form.value.password,
      }
      this.subs = this.loginService.login(request).subscribe({
        next: (value) => this.inicioExitoso(value),
        complete: () => {
          this.uiService.showSpinner(false);
        }
      });
    }
  }

  inicioExitoso(response:any){
    if(response.operation){
      this.tokenService.addItemSessionStorage("token",response.token);
      this.uiService.showToast({
        tipo: "SUCCESS",
        titulo: "Autenticación",
        mensaje: "Inicio Correcto."
      })
      this.uiService.navigate(ROUTES_APP_NAVIGATION.PANEL_SELECCION,NAVIGATION_TYPE.BACKOFFICE);
    }else{
      this.uiService.showToast({
        tipo: "ERROR",
        titulo: "Autenticación",
        mensaje: "Credenciales Incorrectas"
      })
    }
  }


}
