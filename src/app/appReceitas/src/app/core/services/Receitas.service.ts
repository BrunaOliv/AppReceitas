import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { PaginacaoRequisicao } from 'src/app/model/PaginacaoRequisicao';
import { data, Receita } from 'src/app/model/Receita';

const url = 'http://localhost:5147/api/Recipe';

@Injectable({
  providedIn: 'root'
})
export class ReceitasService {

constructor(private http: HttpClient) { }

obterTodasReceitas(paginacaoRequisicao: PaginacaoRequisicao): Observable<Receita>{
  console.log(paginacaoRequisicao)
  const queryParams: HttpParams = this.aplicarParametros(paginacaoRequisicao)

  return this.http.get<Receita>(url, {params: queryParams})
}

  aplicarParametros(paginacaoRequisicao: PaginacaoRequisicao): HttpParams{
    let queryParams = new HttpParams();
    if(paginacaoRequisicao.filter?.categoria)
        queryParams = queryParams.append('Filter.Category', paginacaoRequisicao.filter.categoria);

    if(paginacaoRequisicao.filter?.nome)
        queryParams = queryParams.append('Filter.NameRecipe', paginacaoRequisicao.filter.nome);

    queryParams = queryParams.append('PageSize', paginacaoRequisicao.pageSize);
    queryParams = queryParams.append('PageIndex', paginacaoRequisicao.pageIndex);
    return queryParams;
  }
  
  salvar(data : data): Observable<data>{
    return this.http.post<data>(url, data);
  }
}
