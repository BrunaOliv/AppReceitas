import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CategoriaService } from 'src/app/core/services/categoria.service';
import { Categoria } from 'src/app/model/Categoria';
import { data } from 'src/app/model/Receita';

@Component({
  selector: 'app-cadastro-receita',
  templateUrl: './cadastro-receita.component.html',
  styleUrls: ['./cadastro-receita.component.scss']
})
export class CadastroReceitaComponent implements OnInit {

  constructor(
              private serviceCategoria: CategoriaService,
              private fb: FormBuilder) {
                //this.gerarFormulario();
               }

  categorias: Categoria[] = [];
  levels: string[] = ["Fácil", "Médio", "Difícil", "Mestre Cuca"];
  levelSelecionado?: string;
  cadastroReceita!: FormGroup;


  
  ngOnInit() {
    this.obterCategorias();
    this.carregarFormulario(this.gerarReceita());
  }

  carregarFormulario(receita: data){
    this.cadastroReceita = this.fb.group({
      nome: [receita.name, [Validators.required, Validators.minLength(3), Validators.maxLength(256)]],
      ingredientes: [receita.ingredients, [Validators.required, Validators.minLength(5)]],
      modoPreparo: [receita.preparationMode, [Validators.required, Validators.minLength(5)]],
      categoria: [receita.category?.id, [Validators.required]],
      level: [receita.level?.id, [Validators.required]]
    })
  }


  obterCategorias(): void{
    this.serviceCategoria.obterTodasCategorias().subscribe(data => {
      this.categorias = data;
      console.log(this.categorias)
    })
  }

  private gerarReceita(): data{
    return{
      id: undefined,
      name: undefined,
      ingredients: undefined,
      preparationMode: undefined,
      image: undefined,
      category: undefined,
      level: undefined
    } as data
  }
  private gerarFormulario(): void{
    this.cadastroReceita = this.fb.group({
      nome: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(256)]],
      ingredientes: [null, [Validators.required, Validators.minLength(5)]],
      modoPreparo: [null, [Validators.required, Validators.minLength(5)]],
      categoria: [null, [Validators.required]],
      level: [null, [Validators.required]]
    })
  }
}
