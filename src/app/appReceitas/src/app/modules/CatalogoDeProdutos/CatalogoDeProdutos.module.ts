import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CatalogoDeProdutosComponent } from './CatalogoDeProdutos.component';
import { CadastroProdutoComponent } from './cadastro-produto/cadastro-produto.component';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';

@NgModule({
  imports: [
    CommonModule,
    MatInputModule,
    MatFormFieldModule
  ],
  declarations: [
    CatalogoDeProdutosComponent, 
    CadastroProdutoComponent
  ]
})
export class CatalogoDeProdutosModule { }
