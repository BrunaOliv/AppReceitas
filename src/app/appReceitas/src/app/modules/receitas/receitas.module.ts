import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReceitasComponent } from './receitas.component';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import { CardReceitaComponent } from './card-receita/card-receita.component';
import {IvyCarouselModule} from 'angular-responsive-carousel';

@NgModule({
  imports: [
    CommonModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    IvyCarouselModule
  ],
  declarations: [
    ReceitasComponent,
    CardReceitaComponent],
    
  exports: [ReceitasComponent]
})
export class ReceitasModule { }
