import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReceitasComponent } from './receitas.component';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import { CardReceitaComponent } from './card-receita/card-receita.component';
import {IvyCarouselModule} from 'angular-responsive-carousel';
import {MatTooltipModule} from '@angular/material/tooltip';
import { CadastroReceitaComponent } from '../cadastro-receita/cadastro-receita.component';
import {MatSelectModule} from '@angular/material/select';
import {MatRadioModule} from '@angular/material/radio';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    IvyCarouselModule,
    MatTooltipModule,
    MatSelectModule,
    MatRadioModule,
    FormsModule
  ],
  declarations: [
    ReceitasComponent,
    CardReceitaComponent,
    CadastroReceitaComponent],
    
  exports: [
    ReceitasComponent,
    CadastroReceitaComponent]
})
export class ReceitasModule { }
