import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Avaliação } from 'src/app/model/Avaliação';

const url = 'http://localhost:5147/api/Evaluation';

@Injectable({
  providedIn: 'root'
})
export class AvaliacaoService {

constructor(private http: HttpClient) { }

salvar(data : Avaliação): Observable<Avaliação>{
  return this.http.post<Avaliação>(url, data);
}
}
