import { Component, Input, OnInit } from '@angular/core';
import { ReceitasService } from 'src/app/core/services/Receitas.service';
import { Receita } from 'src/app/model/Receita';

@Component({
  selector: 'app-card-receita',
  templateUrl: './card-receita.component.html',
  styleUrls: ['./card-receita.component.scss']
})
export class CardReceitaComponent implements OnInit {

  constructor(private serviceReitas: ReceitasService) { }

  receitas?:Receita;
  imagemLevel?: string;

  @Input() nomeReceita?:string;
  @Input() levelReceita?:string;


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
}
