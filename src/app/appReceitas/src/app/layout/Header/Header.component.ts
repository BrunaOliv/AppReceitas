import { Component, OnInit } from '@angular/core';
import { CategoriaService } from 'src/app/core/services/categoria.service';
import { Categoria } from 'src/app/model/Categoria';

@Component({
  selector: 'app-Header',
  templateUrl: './Header.component.html',
  styleUrls: ['./Header.component.css']
})
export class HeaderComponent implements OnInit {

  //categorias: string[] = ["Massas", "Carnes", "Receitas Fit", "Bebidas", "Lanches", "Sopas", "Molhos e Saladas", "Massas", "Carnes", "Receitas Fit", "Bebidas", "Lanches", "Sopas", "Molhos e Saladas"];

  categorias: Categoria[] = [];
  constructor(private serviceCategoria: CategoriaService) { }

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
