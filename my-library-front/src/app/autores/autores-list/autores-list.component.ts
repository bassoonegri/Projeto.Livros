import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service'; // Caminho para o serviço
import { Autor } from '../../models/autor.model'; // Caminho para o modelo

@Component({
  selector: 'app-livros-list',
  templateUrl: './autores-list.component.html',
  styleUrls: ['./autores-list.component.css']
})
export class AutoresListComponent implements OnInit {
  autores: Autor[] = [];

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.loadAutores();
  }

  loadAutores(): void {
    this.apiService.getAutores().subscribe({
      next: (data: Autor[]) => {
        this.autores = data;
      },
      error: (err) => {
        console.error('Erro ao carregar autores', err);
      }
    });
  }

  deleteAutor(codAu: number): void {
    if (confirm('Tem certeza que deseja excluir este autor?')) {
      this.apiService.deleteLivro(codAu).subscribe({
        next: () => {
          this.autores = this.autores.filter(l => l.codAu !== codAu);
        },
        error: (err) => {
          console.error('Erro ao excluir Autor', err);
        }
      });
    }
  }
}
