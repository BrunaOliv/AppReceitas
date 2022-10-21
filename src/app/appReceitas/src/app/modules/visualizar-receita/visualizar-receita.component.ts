import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { AvaliacaoService } from 'src/app/core/services/avaliacao.service';
import { ReceitasService } from 'src/app/core/services/Receitas.service';
import { Avaliação } from 'src/app/model/Avaliação';
import { Confirmacao } from 'src/app/model/Confirmacao';
import { PaginacaoAvaliacaoRequisicao } from 'src/app/model/PaginacaoAvaliacaoRequisicao';
import { PaginacaoAvaliacaoResultado } from 'src/app/model/PaginacaoAvaliacaoResultado';
import { data } from 'src/app/model/Receita';
import { ModalConfirmacaoComponent } from 'src/app/shared/modal-confirmacao/modal-confirmacao.component';

@Component({
  selector: 'app-visualizar-receita',
  templateUrl: './visualizar-receita.component.html',
  styleUrls: ['./visualizar-receita.component.scss']
})
export class VisualizarReceitaComponent implements OnInit {

  constructor(
              private serviceReceita: ReceitasService,
              private activetedRoute: ActivatedRoute,
              private router: Router,
              public dialog: MatDialog,
              private _snackBar: MatSnackBar,
              private serviceAvaliacao: AvaliacaoService) { 
                
              }

  imagemDefault: string = 'url("assets/image/img-test.jpg")';
  id!: number;
  receita!: data;
  avaliacoes?: Avaliação;

  ngOnInit() {
    this.id = this.activetedRoute.snapshot.params['id'];
    this.visualizar()
  }

  getUrlImagem(): string{
    if(this.receita.image != undefined && this.receita.image != '')
        return `url(${this.receita.image})`

    return this.imagemDefault;
  }

  private visualizar() : void{
    this.serviceReceita.obterReceitaPorId(this.id).subscribe((receita : data) => {
      this.receita = receita
    })
  }

  excluir(): void{
    const config ={
      data: {
        titulo: "Você tem certeza que deseja excluir esse item?",
        descricao: "Caso você tenha certeza que deseja excluir, clique no botão OK",
        possuiBtnFechar: true,
        corBtnCancelar: 'primary',
        corBtnSucesso: 'warn',
      } as Confirmacao
    };

    const dialogRef = this.dialog.open(ModalConfirmacaoComponent, config);

    dialogRef.afterClosed().subscribe((opcao: boolean) =>{
      if(opcao)
        this.serviceReceita.deletarReceita(this.id).subscribe(() => {
          this.router.navigateByUrl('');
          this._snackBar.open('Excluido com sucesso', 'x', {
            horizontalPosition: 'end',
            verticalPosition: 'top',
            duration: 1500,
            panelClass: ['green-snackbar']
          })
          })
    })
  }

  editar(): void{
    this.router.navigateByUrl('/cadastro/' + this.id);
  }
}
