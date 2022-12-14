import { HttpClient, HttpEvent, HttpParams, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { PaginacaoRequisicao } from 'src/app/model/PaginacaoRequisicao';
import { data, Receita } from 'src/app/model/Receita';

const url = 'http://localhost:5147/api/Recipe';
const urlImage = 'http://localhost:5147/api/Recipe/upload';

@Injectable({
  providedIn: 'root'
})
export class ReceitasService {

constructor(private http: HttpClient) { }

obterTodasReceitas(paginacaoRequisicao: PaginacaoRequisicao): Observable<Receita>{
  const queryParams: HttpParams = this.aplicarParametros(paginacaoRequisicao)

  return this.http.get<Receita>(url, {params: queryParams})
}

  aplicarParametros(paginacaoRequisicao: PaginacaoRequisicao): HttpParams{
    let queryParams = new HttpParams();
    if(paginacaoRequisicao.filter?.categoria)
        queryParams = queryParams.append('Filter.Category', paginacaoRequisicao.filter.categoria);

    if(paginacaoRequisicao.filter?.nome)
        queryParams = queryParams.append('Filter.NameRecipe', paginacaoRequisicao.filter.nome);

    if(paginacaoRequisicao.filter?.level)
      queryParams = queryParams.append('Filter.Level', paginacaoRequisicao.filter.level);

    queryParams = queryParams.append('PageSize', paginacaoRequisicao.pageSize);
    queryParams = queryParams.append('PageIndex', paginacaoRequisicao.pageIndex);
    return queryParams;
  }
  
  salvar(data : data): Observable<data>{
    return this.http.post<data>(url, data);
  }

  obterReceitaPorId(id: number): Observable<data>{
    return this.http.get<data>(`${url}/${id}`)
  }

  deletarReceita(id: number): Observable<data>{
    return this.http.delete<data>(url, {params: {id : id}});
  }

  editarReceita(id: number, receita: data): Observable<data>{
    return this.http.put<data>(url, receita, {params: {id: id}})
  }

  upload(file: any): Observable<HttpEvent<any>>{
    const req = new HttpRequest('POST', 'http://localhost:5147/api/Recipe/upload', file, {
      responseType: 'json'
    });
    return this.http.request(req);
  }
}
