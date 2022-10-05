import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HeaderService {

constructor() { }

private filtrarPorCategoria = new BehaviorSubject<string>('');

private iniciarListagem = new BehaviorSubject<boolean>(false);

setFiltroCategoria(categoria: string): void{
  this.filtrarPorCategoria.next(categoria)
}

getFiltroCategoria(): Observable<string>{
  return this.filtrarPorCategoria.asObservable();
}

setIniciarLitagem(iniciar: boolean): void{
  console.log('entrou service set')
  this.iniciarListagem.next(iniciar)
}

getiniciarListagem(): Observable<boolean>{
  console.log('entrou service get')
  return this.iniciarListagem.asObservable();
}
}
