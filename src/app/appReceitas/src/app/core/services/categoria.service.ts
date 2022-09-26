import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Categoria } from 'src/app/model/Categoria';

const url = 'http://localhost:5147/api/Category'

@Injectable({
  providedIn: 'root'
})
export class CategoriaService {

constructor(private http: HttpClient) { }

  obterTodasCategorias(): Observable<Categoria[]>{
    return this.http.get<Categoria[]>(url);
  }
}
