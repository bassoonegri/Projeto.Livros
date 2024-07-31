import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Livro } from '../models/livro.model';
import { Autor } from '../models/autor.model';
import { Assunto } from '../models/assunto.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private baseUrl = 'https://localhost:7237/api'; // Substitua pela URL da sua API

  constructor(private http: HttpClient) { }

  // Livros
  getLivro(id: number): Observable<Livro> {
    return this.http.get<Livro>(`${this.baseUrl}/livro/${id}`);
  }

  getLivros(): Observable<Livro[]> {
    return this.http.get<Livro[]>(`${this.baseUrl}/livro`);
  }

  createLivro(livro: Livro): Observable<Livro> {
    return this.http.post<Livro>(`${this.baseUrl}/livro`, livro);
  }

  updateLivro(livro: Livro): Observable<Livro> {
    return this.http.put<Livro>(`${this.baseUrl}/livro/${livro.codl}`, livro);
  }

  deleteLivro(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/livro/${id}`);
  }

  // Autores
  getAutor(id: number): Observable<Autor> {
    return this.http.get<Autor>(`${this.baseUrl}/autor/${id}`);
  }

  getAutores(): Observable<Autor[]> {
    return this.http.get<Autor[]>(`${this.baseUrl}/autor`);
  }

  createAutor(autor: Autor): Observable<Autor> {
    return this.http.post<Autor>(`${this.baseUrl}/autor`, autor);
  }

  updateAutor(autor: Autor): Observable<Autor> {
    return this.http.put<Autor>(`${this.baseUrl}/autor/${autor.codAu}`, autor);
  }

  deleteAutor(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/autor/${id}`);
  }

  // Assuntos
  getAssunto(id: number): Observable<Assunto> {
    return this.http.get<Assunto>(`${this.baseUrl}/assunto/${id}`);
  }

  getAssuntos(): Observable<Assunto[]> {
    return this.http.get<Assunto[]>(`${this.baseUrl}/assunto`);
  }

  createAssunto(assunto: Assunto): Observable<Assunto> {
    return this.http.post<Assunto>(`${this.baseUrl}/assunto`, assunto);
  }

  updateAssunto(assunto: Assunto): Observable<Assunto> {
    return this.http.put<Assunto>(`${this.baseUrl}/assunto/${assunto.codAs}`, assunto);
  }

  deleteAssunto(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/assunto/${id}`);
  }
}
