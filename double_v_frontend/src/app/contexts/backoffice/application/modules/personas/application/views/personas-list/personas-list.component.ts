import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PageEvent } from '@angular/material/paginator';
import { Subscription } from 'rxjs';
import { PersonasService } from '../../../../../../infraestructure/services/personas.service';
import { StoreServiceProvider } from '../../../../../../infraestructure/providers/store.service-provider';
import { CustomDataSource } from '../../../../../../../../domain/shared/datasource.class';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-personas-list',
  templateUrl: './personas-list.component.html',
  styleUrl: './personas-list.component.scss'
})
export class PersonasListComponent {

  selectedPokemon!: number;

  subscription = new Subscription();

  constructor(
    private readonly storeServiceProvider:StoreServiceProvider,
    private readonly personasService:PersonasService,
    private spinner: NgxSpinnerService
  ) { }
  personas$ = this.storeServiceProvider.personas$;
  personasTable$ = new CustomDataSource<any>();

  ngOnInit(): void {
    this.spinner.show();
    this.subscription.add(
      this.personasService.getAll().subscribe( (data) => {
          this.storeServiceProvider.personas$.next(data);
          this.spinner.hide();
      })
    );
    this.subscription.add(
      this.storeServiceProvider.personas$.subscribe(personas => {
          this.personasTable$.data.next(personas);
          this.personasTable$.filteredData.next(personas);
          this.personasTable$.setMaxPages(personas.length);
      })
    )
  }


  filter:string = "";



  setPage(page:PageEvent){
    this.personasTable$.paginate(page.pageIndex)
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
    this.personasTable$.disconnect();
  }


  ngAfterViewInit(){
    this.personasTable$.connect();
  }

  displayedColumns: string[] = [
    "id",
    "login",
    "identificacion",
    "email",
    "nombres",
  ];
}
