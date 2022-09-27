import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { CategoriaService } from 'src/app/core/services/categoria.service';
import { HeaderService } from 'src/app/core/services/header.service';
import { Categoria } from 'src/app/model/Categoria';

@Component({
  selector: 'app-Header',
  templateUrl: './Header.component.html',
  styleUrls: ['./Header.component.css']
})
export class HeaderComponent implements OnInit {

  categorias: Categoria[] = [];
  constructor(
              private serviceCategoria: CategoriaService,
              private headerService: HeaderService,
              private router: Router) { }

  ngOnInit() {
    this.obterCategorias();
  }

  obterCategorias(): void{
    this.serviceCategoria.obterTodasCategorias().subscribe(data => {
      this.categorias = data;
      console.log(this.categorias)
    })
  }

  filtrarPorCategoria(categoria : string){
    this.headerService.setFiltroCategoria(categoria)
  }

  carregarPaginaInicial(): void{
    this.headerService.setFiltroCategoria('');
    this.router.navigate(['']);
  }
}
