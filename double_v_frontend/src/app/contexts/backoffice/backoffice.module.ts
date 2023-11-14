import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule } from '@angular/router';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LayoutBaseComponent } from './application/layout-base/layout-base.component';
import { PanelComponent } from './application/panel/panel.component';
import { TokenInterceptor } from '../../infraestructure/interceptors';
import { NgxSpinnerModule } from 'ngx-spinner';
import { validateSessionChildGuard, validateSessionGuard } from './infraestructure/guards/validate-session.guard';

export const routes: Route[] = [
  {
    path: '',
    component: LayoutBaseComponent,
    children: [
      {
        path:  "personas",
        loadChildren: () => import('./application/modules/personas/personas.module').then(m => m.PersonasModule)
      },
      {
        path: '**',
        component: PanelComponent
      },
    ]

  },
];

@NgModule({
  declarations: [
    LayoutBaseComponent,
    PanelComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgxSpinnerModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers:[
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
  ]

})
export class BackOfficeModule {}
