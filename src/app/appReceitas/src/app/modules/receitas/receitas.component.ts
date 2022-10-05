import { Component, ContentChildren, ElementRef, OnInit, QueryList } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { Router } from '@angular/router';
import { HeaderService } from 'src/app/core/services/header.service';
import { ReceitasService } from 'src/app/core/services/Receitas.service';
import { Filter, PaginacaoRequisicao } from 'src/app/model/PaginacaoRequisicao';
import { Receita } from 'src/app/model/Receita';

@Component({
  selector: 'app-receitas',
  templateUrl: './receitas.component.html',
  styleUrls: ['./receitas.component.scss']
})
export class ReceitasComponent implements OnInit {

  constructor(
              private serviceReitas: ReceitasService,
              private headerService: HeaderService,
              private fb: FormBuilder,
              private router: Router) { }

  receitas: Receita = new Receita;
  receitaLista: any[] = [];
  nomeReceita?: string;
  levelReceita?: string;
  imagemReceita?: string;
  idReceita?: number;
  paginacaoRequisicao: PaginacaoRequisicao = new PaginacaoRequisicao;
  filtro!: FormGroup;

  ngOnInit() {
    this.carregarForm();
    this.iniciarPaginaçao();
    this.filtrarPorCategoria();
    this.iniciarEventListagemReceitas();
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

  filtrarPorCategoria(): void{
    this.headerService.getFiltroCategoria().subscribe(categoria => {
      this.router.navigate(['']);
      this.paginacaoRequisicao.filter = new Filter
      this.paginacaoRequisicao.filter.categoria = categoria

      this.obterTodasReceitas(this.paginacaoRequisicao);
    })
  }

  carregarForm(): void{
    this.filtro = this.fb.group({
      nome: ['']
    })
  }

  submitForm(): void{
    this.paginacaoRequisicao.filter.nome = this.filtro.value.nome;
    this.obterTodasReceitas(this.paginacaoRequisicao);
  }

  verificarSeExitemReceitas(): boolean{
    if(this.receitas.data)
        return this.receitas.data.length != 0

    return false
  }

  iniciarEventListagemReceitas(): void{
    this.headerService.getiniciarListagem().subscribe(result =>{
      if(result == true)
        this.iniciarPaginaçao();
    })
  }
}
