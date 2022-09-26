import { Component, ContentChildren, ElementRef, OnInit, QueryList } from '@angular/core';
import { ReceitasService } from 'src/app/core/services/Receitas.service';
import { Receita } from 'src/app/model/Receita';

@Component({
  selector: 'app-receitas',
  templateUrl: './receitas.component.html',
  styleUrls: ['./receitas.component.scss']
})
export class ReceitasComponent implements OnInit {

  constructor(private serviceReitas: ReceitasService) { }

  receitas: Receita = new Receita;
  receitaLista: any[] = [];
  nomeReceita?: string;
  levelReceita?: string;

  ngOnInit() {
    this.obterTodasReceitas();
  }

  obterTodasReceitas(): void{
    this.serviceReitas.obterTodasReceitas().subscribe(data => {
      this.receitas = data;
      console.log(this.receitas)
    })
  }

}
