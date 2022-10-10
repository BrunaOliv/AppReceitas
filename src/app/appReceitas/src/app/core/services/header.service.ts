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
  this.iniciarListagem.next(iniciar)
}

getiniciarListagem(): Observable<boolean>{
  return this.iniciarListagem.asObservable();
}
}
