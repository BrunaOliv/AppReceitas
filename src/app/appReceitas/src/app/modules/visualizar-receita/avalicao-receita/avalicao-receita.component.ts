import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-avalicao-receita',
  templateUrl: './avalicao-receita.component.html',
  styleUrls: ['./avalicao-receita.component.scss']
})
export class AvalicaoReceitaComponent implements OnInit {

  constructor(private fb: FormBuilder) { }

  form!: FormGroup;

  ngOnInit() {
    this.carregarFormAvalicao();
  }

  carregarFormAvalicao(){
    this.form = this.fb.group({
      nota: ['', Validators.required],
      comentario: ['']
    })
  }
}
