import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { data, Receita } from 'src/app/model/Receita';

const url = 'http://localhost:5147/api/Recipe';
const urlPost= "http://localhost:5147/api/Recipe";

@Injectable({
  providedIn: 'root'
})
export class ReceitasService {

constructor(private http: HttpClient) { }

obterTodasReceitas(): Observable<Receita>{
  return this.http.get<Receita>(url);
  }

  salvar(data : data): Observable<data>{
    console.log(data)
    return this.http.post<data>(url, data);
  }
}
