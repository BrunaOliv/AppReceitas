import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AvaliacaoService } from 'src/app/core/services/avaliacao.service';
import { Avaliação } from 'src/app/model/Avaliação';
import { PaginacaoAvaliacaoRequisicao } from 'src/app/model/PaginacaoAvaliacaoRequisicao';
import { PaginacaoAvaliacaoResultado } from 'src/app/model/PaginacaoAvaliacaoResultado';
import { FiltroAvaliacao } from 'src/app/model/FiltroAvaliacao';

@Component({
  selector: 'app-avalicao-receita',
  templateUrl: './avalicao-receita.component.html',
  styleUrls: ['./avalicao-receita.component.scss']
})
export class AvalicaoReceitaComponent implements OnInit {

  constructor(private fb: FormBuilder,
              private avalicaoService: AvaliacaoService,
              private _snackBar: MatSnackBar) { }

  form!: FormGroup;
  avalicao!: Avaliação
  avaliacoes: Array<Avaliação> = [];
  paginacaoAvalicaoRequisicao: PaginacaoAvaliacaoRequisicao = new PaginacaoAvaliacaoRequisicao;
  paginacaoAvaliacaoResultado!: PaginacaoAvaliacaoResultado;
  filtroAvaliacao = new FormControl('');
  pageIndex: number = 0;
  pageSize: number = 5;
  exibirMais: boolean = false;

  @Input() id!: number;

  ngOnInit() {
    this.carregarFormAvalicao();
    this.obterAvaliacoes();
  }

  carregarFormAvalicao(){
    this.form = this.fb.group({
      grade: ['', Validators.required],
      comment: ['']
    })
  }

  submit(): void{
    this.avalicao = this.form.getRawValue() as Avaliação;
    this.avalicao.recipeId = this.id;

    this.salvarAvalicao();
  }

  salvarAvalicao(): void{
    this.avalicaoService.salvar(this.avalicao).subscribe(() => {
      this._snackBar.open('Salvo com sucesso', 'x', {
        horizontalPosition: 'end',
        verticalPosition: 'top',
        duration: 1000,
        panelClass: ['green-snackbar']
      })
      this.form.reset();
      this.obterAvaliacoes();
    })
  }
  
  numSequence(n: number): Array<number> {
    return Array(n);
  }

  obterAvaliacoes(): void{
    this.iniciarPaginacaoAvalicao();

    this.avalicaoService.obterAvaliacoesPorIdReceita(this.paginacaoAvalicaoRequisicao).subscribe(data => {
      this.paginacaoAvaliacaoResultado = data;
      this.avaliacoes = data.data;
    })
  }

  iniciarPaginacaoAvalicao(): void{
    this.paginacaoAvalicaoRequisicao.pageIndex = this.pageIndex;
    this.paginacaoAvalicaoRequisicao.pageSize = this.pageSize;
    this.paginacaoAvalicaoRequisicao.filterEvaluation = new FiltroAvaliacao;
    this.paginacaoAvalicaoRequisicao.filterEvaluation.id = this.id;
    this.paginacaoAvalicaoRequisicao.filterEvaluation.EvaluationType = this.filtroAvaliacao.value;
  }

  exibirMaisAvaliacoes(): void{
    this.exibirMais = true;
    this.pageSize = this.pageSize + 5;
    this.obterAvaliacoes();
  }

  verificarQuantidadeDeAvaliacoes(): boolean{
    if(this.paginacaoAvaliacaoResultado?.totalItems)
      return this.paginacaoAvaliacaoResultado.totalItems > 5

    return false
  }

  exibirMenosAvaliacoes(): void{
    this.pageSize = 5;
    this.obterAvaliacoes();
  }
}
