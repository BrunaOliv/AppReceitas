import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { CategoriaService } from 'src/app/core/services/categoria.service';
import { HeaderService } from 'src/app/core/services/header.service';
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
              private serviceReceitas: ReceitasService,
              private _snackBar: MatSnackBar,
              private activetedRoute: ActivatedRoute,
              private router: Router,
              private headerService: HeaderService) {
                this.gerarFormulario();
               }

  categorias: Categoria[] = [];
  levels: Level[] = [];
  levelSelecionado?: string;
  cadastroReceita!: FormGroup;
  filename: any = null;
  imageSource: any = null;
  urlBlob:string = "https://appreceitas.blob.core.windows.net/appreceitas/";
  file:any = null;
  id!: number;
  selectFile?: any = null;
  imagemDefault: string = "assets/image/default-image.jpg";
  receita!: data;
  base64Output! : string;
  ImagePreview!: any;

  get form(){
    return this.cadastroReceita.controls;
  }

  ngOnInit() {
    this.obterCategorias();
    this.obterLevels();
    this.id = this.activetedRoute.snapshot.params['id'];

    if(this.id){
      this.carregarReceita();
      return
    }

    this.carregarFormulario(this.gerarReceita());
  }

  carregarFormulario(receita: data){
    this.cadastroReceita = this.fb.group({
      id:[receita.id],
      name: [receita.name, [Validators.required, Validators.minLength(3), Validators.maxLength(256)]],
      ingredients: [receita.ingredients, [Validators.required, Validators.minLength(5)]],
      preparationMode: [receita.preparationMode, [Validators.required, Validators.minLength(5)]],
      categoryId: [receita.categoryId, [Validators.required]],
      levelId: [receita.levelId, [Validators.required]],
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
    return{} as data
  }

  private gerarFormulario(): void{
    this.cadastroReceita = this.fb.group({
      name: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(256)]],
      ingredients: [null, [Validators.required, Validators.minLength(5)]],
      preparationMode: [null, [Validators.required, Validators.minLength(5)]],
      categoryId: [null, [Validators.required]],
      levelId: [null, [Validators.required]],
      image: [null, [Validators.required]]
    })
  }

  obterLevels() : void{
    this.serviceLevel.obterTodosLevels().subscribe(data =>{
      this.levels = data;
    })
  }

  async submit(){
    this.cadastroReceita.markAllAsTouched();

    if(this.cadastroReceita.invalid)
      return

    this.receita = this.cadastroReceita.getRawValue() as data;

    if(this.receita.image != this.filename){
      this.uploadImagem(this.file);
      return;
    }

    this.gravarAlteracoes();
  }

  salvar(data: data): void{
    this.serviceReceitas.salvar(data).subscribe(() => {
      this._snackBar.open('Salvo com sucesso', 'x', {
        horizontalPosition: 'end',
        verticalPosition: 'top',
        duration: 1000,
        panelClass: ['green-snackbar']
      })
    }, err => {
      this._snackBar.open('Erro ao salvar', 'x', {
        horizontalPosition: 'end',
        verticalPosition: 'top',
        duration: 1000,
        panelClass: ['red-snackbar']
      })
    });
    this.reiniciarForm();
  }

  reiniciarForm(): void{
    this.cadastroReceita.reset();
    this.ImagePreview = null;
    this.filename = null;

    if(this.id){
      this.iniciarPaginaIncial();
    }
  }

  temErro(control: AbstractControl, errorName: string):boolean{
    return control.hasError(errorName);
  }

  validacaoErros(control: AbstractControl, errorName: string):boolean{
    if((control.dirty || control.touched) && this.temErro(control, errorName)){
      return true
    }
    return false
  }

  setFilename(files: any) {
    if (files[0]) {
      this.filename = files[0].name;
      this.file = files;
      this.convertFile(files[0]).subscribe(base64 =>{
        this.base64Output = base64;
      })
    }
    return
  }

  uploadImagem(files:any){
    const formData = new FormData();

    formData.append('file', files[0]);

      this.serviceReceitas
      .upload(formData)
      .subscribe((event: any) => {
          this.receita.image = event.body?.urlImage;
          
          if(event.body?.urlImage){
            this.gravarAlteracoes();
          }
      });
    }

    gravarAlteracoes(): void{
      if(this.id){
        this.editar(this.receita);
        return;
      }

      this.salvar(this.receita);
    }

    carregarReceita(): void{
      this.serviceReceitas.obterReceitaPorId(this.id).subscribe((receita : data) => {
        this.carregarFormulario(receita)
        this.filename = receita.image
      })
    }

  editar(receita: data): void{
    this.serviceReceitas.editarReceita(this.id, receita).subscribe(() => {
      this.iniciarPaginaIncial();
      this._snackBar.open('Editado com sucesso', 'x', {
        horizontalPosition: 'end',
        verticalPosition: 'top',
        duration: 1500,
        panelClass: ['green-snackbar']
      })
    })
  }

  getUrlImagem():string{
    if(this.ImagePreview )
      return `url(${this.ImagePreview })`;
      
    if(this.id)
      return `url(${this.filename})`;

    return `url(${this.imagemDefault})`;
    }

  onFileSelected(event: any) {
    if(event.target.files[0]){
      this.convertFile(event.target.files[0]).subscribe(base64 => {
        this.base64Output = base64;
      });
    }
    return
  }

  convertFile(file : File) : Observable<string> {
    let result: any;
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => {this.ImagePreview = reader.result};
    return this.ImagePreview;
  }

  iniciarPaginaIncial(): void{
    this.headerService.setFiltroCategoria('');
    this.headerService.setIniciarLitagem(true);
    this.router.navigate(['']);
  }
}
