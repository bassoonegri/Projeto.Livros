import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service'; // Caminho para o serviço
import { Livro } from '../../models/livro.model'; // Caminho para o modelo

@Component({
  selector: 'app-livros-list',
  templateUrl: './livros-list.component.html',
  styleUrls: ['./livros-list.component.css']
})
export class LivrosListComponent implements OnInit {
  livros: Livro[] = [];

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.loadLivros();
  }

  loadLivros(): void {
    this.apiService.getLivros().subscribe({
      next: (data: Livro[]) => {
        this.livros = data;
      },
      error: (err) => {
        console.error('Erro ao carregar livros', err);
      }
    });
  }

  deleteLivro(codl: number): void {
    if (confirm('Tem certeza que deseja excluir este livro?')) {
      this.apiService.deleteLivro(codl).subscribe({
        next: () => {
          this.livros = this.livros.filter(l => l.codl !== codl);
        },
        error: (err) => {
          console.error('Erro ao excluir livro', err);
        }
      });
    }
  }
}
