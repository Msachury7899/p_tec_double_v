import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { Route, RouterModule } from '@angular/router';
import { LoginComponent } from './application/views';
import { LayoutBaseComponent } from './application/layout-base/layout-base.component';
import { LoginService } from './infraestructure/services';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxSpinnerModule } from 'ngx-spinner';

export const routes: Route[] = [
  {
    path: '',
    component: LayoutBaseComponent,
    children: [
      {
        path: 'login',
        component: LoginComponent
      }
    ]
  },
];

@NgModule({
  declarations: [
    LayoutBaseComponent,
    LoginComponent,
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
  providers:[LoginService]

})
export class AuthModule {}
