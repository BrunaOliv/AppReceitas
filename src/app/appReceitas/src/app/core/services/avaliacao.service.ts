import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const url = 'http://localhost:5147/api/Evaluation';

@Injectable({
  providedIn: 'root'
})
export class AvaliacaoService {

constructor(private http: HttpClient) { }

salvar(data : any): Observable<any>{
  return this.http.post<any>(url, data);
}
}
