import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ReceitasService } from 'src/app/core/services/Receitas.service';
import { data } from 'src/app/model/Receita';

@Component({
  selector: 'app-visualizar-receita',
  templateUrl: './visualizar-receita.component.html',
  styleUrls: ['./visualizar-receita.component.scss']
})
export class VisualizarReceitaComponent implements OnInit {

  constructor(
              private serviceReceita: ReceitasService,
              private activetedRoute: ActivatedRoute) { }

  imagemDefault: string = 'url("assets/image/img-test.jpg")';
  id!: number;
  receita!: data;

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
      console.log(this.receita)
    })
  }
}
