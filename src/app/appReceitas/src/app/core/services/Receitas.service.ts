import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Receita } from 'src/app/model/Receita';

const url = 'http://localhost:5147/api/Recipe'

@Injectable({
  providedIn: 'root'
})
export class ReceitasService {

constructor(private http: HttpClient) { }

obterTodasReceitas(): Observable<Receita>{
  return this.http.get<Receita>(url);
  }
}
