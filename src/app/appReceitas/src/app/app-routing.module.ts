import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastroReceitaComponent } from './modules/cadastro-receita/cadastro-receita.component';
import { CadastroProdutoComponent } from './modules/CatalogoDeProdutos/cadastro-produto/cadastro-produto.component';
import { ReceitasComponent } from './modules/receitas/receitas.component';
import { VisualizarReceitaComponent } from './modules/visualizar-receita/visualizar-receita.component';

const routes: Routes = [
  { path: '', component: ReceitasComponent },
  { path: 'cadastro',
    children: [{
      path: '',
      component: CadastroReceitaComponent
    },{
      path: ':id',
      component: CadastroReceitaComponent
    }]
 },
  { path: 'receitas/:id', component: VisualizarReceitaComponent},
  {path: 'catalogoCadastro', component: CadastroProdutoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    scrollPositionRestoration: 'enabled'
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
