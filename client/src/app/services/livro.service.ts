import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { LivroDto } from '../Dto/livro.dto';

@Injectable({
  providedIn: 'root'
})


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

export class LivroService {

  url = 'https://localhost:5001/api/livro';

  constructor(private http: HttpClient) {  
  }

  Get(): Observable<LivroDto[]> {
    return this.http.get<LivroDto[]>(this.url);
  }

  GetById(id: string): Observable<LivroDto> {
    return this.http.get<LivroDto>(`${this.url}/${id}`);
  }

  Post(livro: LivroDto): Observable<any> {
    return this.http.post<LivroDto>(this.url, livro, httpOptions);
  }

  Put(livro: LivroDto): Observable<any> {
    return this.http.put<LivroDto>(this.url, livro, httpOptions);
  }

  Delete(id: string): Observable<any> {
    return this.http.delete<string>(`${this.url}/${id}`, httpOptions);
  }
}
