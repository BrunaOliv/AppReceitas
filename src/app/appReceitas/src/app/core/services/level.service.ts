import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Level } from 'src/app/model/Level';

  
const url = "http://localhost:5147/api/Level";

@Injectable({
  providedIn: 'root'
})

export class LevelService {
constructor(private http: HttpClient) { }

  obterTodosLevels(): Observable<Level[]>{
    return this.http.get<Level[]>(url);
  }
}
