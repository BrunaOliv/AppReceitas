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
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { VisualizarReceitaComponent } from '../visualizar-receita/visualizar-receita.component';

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
    FormsModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatSnackBarModule,
    MatPaginatorModule,
    MatProgressSpinnerModule
  ],
  declarations: [
    ReceitasComponent,
    CardReceitaComponent,
    CadastroReceitaComponent,
    VisualizarReceitaComponent],
    
  exports: [
    ReceitasComponent,
    CadastroReceitaComponent,
    VisualizarReceitaComponent]
})
export class ReceitasModule { }
