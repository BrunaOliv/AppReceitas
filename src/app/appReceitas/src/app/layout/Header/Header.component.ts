import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-Header',
  templateUrl: './Header.component.html',
  styleUrls: ['./Header.component.css']
})
export class HeaderComponent implements OnInit {

  categorias: string[] = ["Massas", "Carnes", "Receitas Fit", "Bebidas", "Lanches", "Sopas", "Molhos e Saladas"];
  constructor() { }

  ngOnInit() {
  }

}
