import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';
import { Autor } from '../models/autor.model';

@Component({
  selector: 'app-autores',
  templateUrl: './autores.component.html',
  styleUrls: ['./autores.component.css']
})
export class AutoresComponent implements OnInit {
  autor: Autor = { codAu: 0, nome: '' };
  autores: Autor[] = [];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.loadAutores();
  }

  loadAutores(): void {
    this.apiService.getAutores().subscribe(data => this.autores = data);
  }

  onSubmit(): void {
    if (this.autor.codAu) {
      this.apiService.updateAutor(this.autor).subscribe(() => this.loadAutores());
    } else {
      this.apiService.createAutor(this.autor).subscribe(() => this.loadAutores());
    }
    this.resetForm();
  }

  editAutor(autor: Autor): void {
    this.autor = { ...autor };
  }

  deleteAutor(codAu: number): void {
    this.apiService.deleteAutor(codAu).subscribe(() => this.loadAutores());
  }

  resetForm(): void {
    this.autor = { codAu: 0, nome: '' };
  }
}
