import { Component, OnInit } from '@angular/core';
import { CategoriaService } from 'src/app/core/services/categoria.service';
import { Categoria } from 'src/app/model/Categoria';

@Component({
  selector: 'app-cadastro-receita',
  templateUrl: './cadastro-receita.component.html',
  styleUrls: ['./cadastro-receita.component.scss']
})
export class CadastroReceitaComponent implements OnInit {

  constructor(private serviceCategoria: CategoriaService) { }

  categorias: Categoria[] = [];
  levels: string[] = ["Fácil", "Médio", "Difícil", "Mestre Cuca"];
  levelSelecionado?: string;
  
  ngOnInit() {
    this.obterCategorias();
  }

  obterCategorias(): void{
    this.serviceCategoria.obterTodasCategorias().subscribe(data => {
      this.categorias = data;
      console.log(this.categorias)
    })
  }
}
