import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ReceitasService } from 'src/app/core/services/Receitas.service';
import { Receita } from 'src/app/model/Receita';

@Component({
  selector: 'app-card-receita',
  templateUrl: './card-receita.component.html',
  styleUrls: ['./card-receita.component.scss']
})
export class CardReceitaComponent implements OnInit {

  constructor(private serviceReitas: ReceitasService,
              private router: Router) { }

  receitas?:Receita;
  imagemLevel?: string;
  imagemDefault: string = 'url("assets/image/img-test.jpg")';

  @Input() nomeReceita?:string;
  @Input() levelReceita?:string;
  @Input() imagemReceita?: string
  @Input() idReceita?: number


  ngOnInit() {
    
  }

  obterIconeLevel(): string{
    const level = this.levelReceita;

    if(level == "Fácil")
      return this.imagemLevel = "assets/image/facil.png";

    if(level == "Médio")
      return this.imagemLevel = "assets/image/medio.png"

    if(level == "Difícil")
      return this.imagemLevel = "assets/image/dificil.png"

    return this.imagemLevel = "assets/image/mestre-cuca.png"
  }

  getUrlImagem(): string{ 
    if(this.imagemReceita != undefined && this.imagemReceita != '')
        return `url(${this.imagemReceita})`

    return this.imagemDefault;
  }

  abrirReceita(){
    this.router.navigateByUrl('/receitas/' + this.idReceita)
  }
}
