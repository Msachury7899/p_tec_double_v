import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UiService } from '../../../../infraestructure/services/ui.service';
import { NAVIGATION_TYPE, ROUTES_APP_NAVIGATION } from '../../../../presentation/navigation';

@Component({
  selector: 'app-panel',
  templateUrl: './panel.component.html',
  styleUrl: './panel.component.scss'
})
export class PanelComponent {
  private readonly uiService = inject(UiService);



  navegar(value:number){
    switch(value){
      case 1:
        this.uiService.navigate(ROUTES_APP_NAVIGATION.LISTAR_PERSONAS,NAVIGATION_TYPE.BACKOFFICE)
        break;
      case 2:
        this.uiService.navigate(ROUTES_APP_NAVIGATION.CREAR_PERSONAS,NAVIGATION_TYPE.BACKOFFICE)
        break;
    }
  }
}
