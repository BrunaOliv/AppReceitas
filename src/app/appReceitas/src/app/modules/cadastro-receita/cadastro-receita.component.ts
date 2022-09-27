import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CategoriaService } from 'src/app/core/services/categoria.service';
import { LevelService } from 'src/app/core/services/level.service';
import { ReceitasService } from 'src/app/core/services/Receitas.service';
import { Categoria } from 'src/app/model/Categoria';
import { Level } from 'src/app/model/Level';
import { data } from 'src/app/model/Receita';

@Component({
  selector: 'app-cadastro-receita',
  templateUrl: './cadastro-receita.component.html',
  styleUrls: ['./cadastro-receita.component.scss']
})
export class CadastroReceitaComponent implements OnInit {

  constructor(
              private serviceCategoria: CategoriaService,
              private fb: FormBuilder,
              private serviceLevel: LevelService,
              private serviceReceitas: ReceitasService) {
                this.gerarFormulario();
               }

  categorias: Categoria[] = [];
  levels: Level[] = [];
  levelSelecionado?: string;
  cadastroReceita!: FormGroup;
  
  ngOnInit() {
    this.obterCategorias();
    this.obterLevels();
    this.carregarFormulario(this.gerarReceita());
  }

  carregarFormulario(receita: data){
    this.cadastroReceita = this.fb.group({
      name: [receita.name, [Validators.required, Validators.minLength(3), Validators.maxLength(256)]],
      ingredients: [receita.ingredients, [Validators.required, Validators.minLength(5)]],
      preparationMode: [receita.preparationMode, [Validators.required, Validators.minLength(5)]],
      categoryId: [receita.category, [Validators.required]],
      levelId: [receita.level, [Validators.required]],
      image: [receita.image, [Validators.required]]
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

    } as data
  }
  private gerarFormulario(): void{
    this.cadastroReceita = this.fb.group({
      name: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(256)]],
      ingredients: [null, [Validators.required, Validators.minLength(5)]],
      preparationMode: [null, [Validators.required, Validators.minLength(5)]],
      categoryId: [null, [Validators.required]],
      levelId: [null, [Validators.required]]
    })
  }

  obterLevels() : void{
    this.serviceLevel.obterTodosLevels().subscribe(data =>{
      this.levels = data;
      console.log(this.levels)
    })
  }

  submit() : void{
    const receita = this.cadastroReceita.getRawValue() as data;
    this.salvar(receita)
  }

  salvar(data: data): void{
    this.serviceReceitas.salvar(data).subscribe();
  }

  selectedFile: any = null;

onFileSelected(event: any): void {
    this.selectedFile = event.target.files[0] ?? null;
}
}
