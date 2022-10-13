import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AvaliacaoService } from 'src/app/core/services/avaliacao.service';
import { Avaliação } from 'src/app/model/Avaliação';

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

  @Input() id?: number;
  @Input() avaliacoes: Array<Avaliação> = [];

  ngOnInit() {
    this.carregarFormAvalicao();
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
    })
  }
  
  numSequence(n: number): Array<number> {
    return Array(n);
  }
}
