import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PersonasCreateComponent, PersonasListComponent } from './application/views';
import { StoreServiceProvider } from '../../../infraestructure/providers/store.service-provider';
import { TipoIdentificacionService } from '../../../infraestructure/services/tipo_identificacion.service';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { PersonasService } from '../../../infraestructure/services/personas.service';

export const routes: Route[] = [
  {
    path: "list",
    component: PersonasListComponent
  },
  {
    path: "create",
    component: PersonasCreateComponent
  },
];

@NgModule({
  declarations: [
    PersonasListComponent,
    PersonasCreateComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatTableModule,
    MatToolbarModule,
    MatPaginatorModule,
    ScrollingModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule],
  providers:[
    PersonasService,
    StoreServiceProvider,
    TipoIdentificacionService
  ]

})
export class PersonasModule {}
