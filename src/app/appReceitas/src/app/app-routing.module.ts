import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastroReceitaComponent } from './modules/cadastro-receita/cadastro-receita.component';
import { ReceitasComponent } from './modules/receitas/receitas.component';

const routes: Routes = [
  { path: '', component: ReceitasComponent },
    { path: 'cadastro', component: CadastroReceitaComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
