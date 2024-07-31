import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';
import { Livro } from '../models/livro.model';

@Component({
  selector: 'app-livros',
  templateUrl: './livros.component.html',
  styleUrls: ['./livros.component.css']
})
export class LivrosComponent implements OnInit {
  livro: Livro = { codl: 0, titulo: '', editora: '', edicao: 0, anoPublicacao: '' };
  livros: Livro[] = [];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.loadLivros();
  }

  loadLivros(): void {
    this.apiService.getLivros().subscribe(data => this.livros = data);
  }

  onSubmit(): void {
    if (this.livro.codl) {
      this.apiService.updateLivro(this.livro).subscribe(() => this.loadLivros());
    } else {
      this.apiService.createLivro(this.livro).subscribe(() => this.loadLivros());
    }
    this.resetForm();
  }

  editLivro(livro: Livro): void {
    this.livro = { ...livro };
  }

  deleteLivro(id: number): void {
    this.apiService.deleteLivro(id).subscribe(() => this.loadLivros());
  }

  resetForm(): void {
    this.livro = { codl: 0, titulo: '', editora: '', edicao: 0, anoPublicacao: '' };
  }
}
