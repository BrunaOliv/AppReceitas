import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Confirmacao } from 'src/app/model/Confirmacao';

@Component({
  selector: 'app-modal-confirmacao',
  templateUrl: './modal-confirmacao.component.html',
  styleUrls: ['./modal-confirmacao.component.scss']
})
export class ModalConfirmacaoComponent implements OnInit {

  constructor(
              public dialogRef: MatDialogRef<ModalConfirmacaoComponent>,
              @Inject(MAT_DIALOG_DATA) public data: Confirmacao) { }

  confirmacao = {
    titulo: "Sucesso!",
    descricao: "Seu registro foi cadastrado com sucesso!",
    btnSucesso: "Ok",
    btnCancelar:  "Cancelar",
    corBtnSucesso: "accent",
    corBtnCancelar: "warn",
    possuiBtnFechar: false
  } as Confirmacao

  ngOnInit() {
    this.carregarDadosModal();
  }

  carregarDadosModal(): void{
    if(this.data){
      this.confirmacao.titulo = this.data.titulo || this.confirmacao.titulo;
      this.confirmacao.descricao = this.data.descricao || this.confirmacao.descricao;
      this.confirmacao.btnSucesso = this.data.btnSucesso || this.confirmacao.btnSucesso;
      this.confirmacao.corBtnSucesso = this.data.corBtnSucesso || this.confirmacao.corBtnSucesso;
      this.confirmacao.btnCancelar = this.data.btnCancelar || this.confirmacao.btnCancelar;
      this.confirmacao.corBtnCancelar = this.data.corBtnCancelar || this.confirmacao.corBtnCancelar;
      this.confirmacao.possuiBtnFechar = this.data.possuiBtnFechar || this.confirmacao.possuiBtnFechar;
    }
  }
}
