import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, ReplaySubject } from 'rxjs';
import { BlobService } from 'src/app/core/services/blob.service';
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
              private serviceReceitas: ReceitasService,
              private _snackBar: MatSnackBar,
              private blobService: BlobService,
              private activetedRoute: ActivatedRoute,
              private router: Router,) {
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
      console.log(this.levels)
    })
  }

  submit() : void{
    this.cadastroReceita.markAllAsTouched();
    if(this.cadastroReceita.invalid)
      return
    const receita = this.cadastroReceita.getRawValue() as data;

    if(this.id){
      this.editar(receita);
      return
    }

    receita.image = this.filename

    this.salvar(receita)
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
    this.cadastroReceita.markAsUntouched();
    this.filename = '';
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
    }
    this.file = files;
    console.log(files)
    this.uploadImagem(files)
  }

  uploadImagem(files:any) {
    const formData = new FormData();
    if (!files) {
      return
    }
    formData.append('file', files[0]);

    this.serviceReceitas
      .upload(formData)
      .subscribe((event: any) =>{
        this.filename = event.body?.urlImage;
        console.log(this.filename);
      });
    }

    carregarReceita(): void{
      this.serviceReceitas.obterReceitaPorId(this.id).subscribe((receita : data) => {
        this.carregarFormulario(receita)
        this.filename = receita.image
      })
    }

    editar(receita: data): void{
      this.serviceReceitas.editarReceita(this.id, receita).subscribe(() => {
        this.router.navigateByUrl('');
        this._snackBar.open('Editado com sucesso', 'x', {
          horizontalPosition: 'end',
          verticalPosition: 'top',
          duration: 1500,
          panelClass: ['green-snackbar']
        })
        })
    }

    getUrlImagem():string{
      if(this.filename != undefined && this.filename != '')
        return `url(${this.filename})`

    return `url(${this.imagemDefault})`
    }

    base64Output! : string;
    ImagePreview!: any;

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
    return result;
  }
}
