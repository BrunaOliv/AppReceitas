import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BlobService {

constructor(private http: HttpClient) { }

upload(formData: FormData) {
  console.log(formData)
  return this.http.post<{ path: string }>(
    'http://localhost:5147/api/Recipe/image',
    formData
  );
}
}
