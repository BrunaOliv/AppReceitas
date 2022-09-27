import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HeaderService {

constructor() { }

private filtrarPorCategoria = new BehaviorSubject<string>('');

setFiltroCategoria(categoria: string): void{
  this.filtrarPorCategoria.next(categoria)
}

getFiltroCategoria(): Observable<string>{
  return this.filtrarPorCategoria.asObservable();
}

}
