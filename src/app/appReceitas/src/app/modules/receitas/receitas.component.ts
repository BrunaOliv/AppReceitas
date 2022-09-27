import { Component, ContentChildren, ElementRef, OnInit, QueryList } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { ReceitasService } from 'src/app/core/services/Receitas.service';
import { PaginacaoRequisicao } from 'src/app/model/PaginacaoRequisicao';
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
  imagemReceita?: string;
  paginacaoRequisicao: PaginacaoRequisicao = new PaginacaoRequisicao;

  ngOnInit() {
    this.iniciarPaginaçao();
  }

  iniciarPaginaçao(): void{
    this.paginacaoRequisicao.pageIndex = 0;
    this.paginacaoRequisicao.pageSize = 9
    this.obterTodasReceitas(this.paginacaoRequisicao);
  }

  obterTodasReceitas(paginacaoRequisicao: PaginacaoRequisicao): void{
    this.serviceReitas.obterTodasReceitas(paginacaoRequisicao).subscribe(data => {
      this.receitas = data
    })
  }

  onPageChange(event: PageEvent): void {
    this.paginacaoRequisicao.pageIndex =  event.pageIndex,
    this.paginacaoRequisicao.pageSize = event.pageSize
    this.obterTodasReceitas(this.paginacaoRequisicao);
}
}
