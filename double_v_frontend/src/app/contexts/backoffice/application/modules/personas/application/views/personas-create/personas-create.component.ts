import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UiService } from '../../../../../../../../infraestructure/services/ui.service';
import { Subscription } from 'rxjs';
import { StoreServiceProvider } from '../../../../../../infraestructure/providers/store.service-provider';
import { TipoIdentificacionService } from '../../../../../../infraestructure/services/tipo_identificacion.service';
import { PersonasService } from '../../../../../../infraestructure/services/personas.service';

@Component({
  selector: 'app-personas-create',
  templateUrl: './personas-create.component.html',
  styleUrl: './personas-create.component.scss'
})
export class PersonasCreateComponent {

  form:FormGroup = this.fb.group({
    login: ['',Validators.required],
    password: ['',Validators.required],
    email: ['',Validators.required],
    nombres: ['',Validators.required],
    apellidos: ['',Validators.required],
    tipo_identificacion: [-1,Validators.required],
    identificacion: ['',Validators.required]
  });


  tiposIdentificacion$ = this.storeService.tipos_identificacion$;

  subs = new Subscription();

  constructor(
    private uiService: UiService,
    private fb:FormBuilder,
    private storeService: StoreServiceProvider,
    private tipoIdentificacionService: TipoIdentificacionService,
    private personasService: PersonasService,
  ){}

  ngOnInit(): void {
    this.subs.add(
      this.tipoIdentificacionService.getAll().subscribe(data => {
        this.storeService.tipos_identificacion$.next(data);
      })
    )
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  sendForm(){
    if(this.form.valid){
      this.uiService.showSpinner(true);
      const request = {
        login: this.form.value.login,
        password: this.form.value.password,
        email: this.form.value.email,
        nombres: this.form.value.nombres,
        apellidos: this.form.value.apellidos,
        idTipoIdentificacion: this.form.value.tipo_identificacion,
        identificacion: this.form.value.identificacion,
      }
      this.subs.add(
        this.personasService.create(request).subscribe({
        next: (value) => this.creacionExitosa(value),
        error: ((err) => {
          this.uiService.showSpinner(false);
          this.uiService.showToast({
            tipo: "ERROR",
            titulo: "Creación Personas",
            mensaje: "Ha habido un error",
          })
        }),
      }));
    }
  }


  creacionExitosa(response:any){
    this.uiService.showSpinner(false);
    this.uiService.showToast({
      tipo: "SUCCESS",
      titulo: "Creación Personas",
      mensaje: "Persona Creada Correctamente",
    })
  }

}
