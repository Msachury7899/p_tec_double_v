import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UiService } from '../../../../infraestructure/services/ui.service';
import { NAVIGATION_TYPE, ROUTES_APP_NAVIGATION } from '../../../../presentation/navigation';
import { TokenService } from '../../../../infraestructure/services';

@Component({
  selector: 'app-layout-base',
  templateUrl: './layout-base.component.html',
  styleUrl: './layout-base.component.scss'
})
export class LayoutBaseComponent {
  private readonly uiService:UiService = inject(UiService);
  private readonly authService:TokenService = inject(TokenService);



  navegarPanel(){
    this.uiService.navigate(ROUTES_APP_NAVIGATION.PANEL_SELECCION,NAVIGATION_TYPE.BACKOFFICE)
  }

  cerrarSesion(){
    this.authService.cerrarSesion();
    this.uiService.navigate(ROUTES_APP_NAVIGATION.LOGIN,NAVIGATION_TYPE.BACKOFFICE)
  }
}
