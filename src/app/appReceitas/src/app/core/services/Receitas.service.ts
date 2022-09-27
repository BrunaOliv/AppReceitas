import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { PaginacaoRequisicao } from 'src/app/model/PaginacaoRequisicao';
import { data, Receita } from 'src/app/model/Receita';

const url = 'http://localhost:5147/api/Recipe';
const urlPost= "http://localhost:5147/api/Recipe";

@Injectable({
  providedIn: 'root'
})
export class ReceitasService {

constructor(private http: HttpClient) { }

obterTodasReceitas(paginacaoRequisicao: PaginacaoRequisicao): Observable<Receita>{
  return this.http.get<Receita>(url, {
    params: {
      PageSize: paginacaoRequisicao.pageSize,
      PageIndex: paginacaoRequisicao.pageIndex
    }
  })
}

  salvar(data : data): Observable<data>{
    console.log(data)
    return this.http.post<data>(url, data);
  }
}
