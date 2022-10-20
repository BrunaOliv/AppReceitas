import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PaginacaoAvaliacaoRequisicao } from 'src/app/model/PaginacaoAvaliacaoRequisicao';
import { PaginacaoAvaliacaoResultado } from 'src/app/model/PaginacaoAvaliacaoResultado';

const url = 'http://localhost:5147/api/Evaluation/';

@Injectable({
  providedIn: 'root'
})
export class AvaliacaoService {

constructor(private http: HttpClient) { }

obterAvaliacoesPorIdReceita(paginacaoAvaliacaoRequisicao: PaginacaoAvaliacaoRequisicao): Observable<PaginacaoAvaliacaoResultado>{
  const queryParams: HttpParams = this.aplicarParametros(paginacaoAvaliacaoRequisicao);
  return this.http.get<PaginacaoAvaliacaoResultado>(`${url}/Recipe/evaluations`, {params: queryParams});
}

aplicarParametros(paginacaoAvaliacaoRequisicao: PaginacaoAvaliacaoRequisicao): HttpParams{
  let queryParams = new HttpParams();

  queryParams = queryParams.append('PageSize', paginacaoAvaliacaoRequisicao.pageSize);
  queryParams = queryParams.append('PageIndex', paginacaoAvaliacaoRequisicao.pageIndex);
  queryParams = queryParams.append('FilterEvaluation.Id', paginacaoAvaliacaoRequisicao.filterEvaluation.id);

  if(paginacaoAvaliacaoRequisicao.filterEvaluation?.EvaluationType){
    queryParams = queryParams.append('FilterEvaluation.EvaluationType', paginacaoAvaliacaoRequisicao.filterEvaluation.EvaluationType);
  }

  return queryParams;
}
}
