// src/app/livros-relatorio/livros-relatorio.component.ts
import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { Livro } from '../../models/livro.model';

@Component({
  selector: 'app-livros-relatorio',
  templateUrl: './livros-relatorio.component.html',
  styleUrls: ['./livros-relatorio.component.css']
})
export class LivrosRelatorioComponent implements OnInit {
  livros: Livro[] = [];
  isLoading = true;
  errorMessage: string | null = null;

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.apiService.getLivros().subscribe(
      (livros) => {
        this.livros = livros;
        this.isLoading = false;
      },
      (error) => {
        this.errorMessage = 'Erro ao carregar livros.';
        this.isLoading = false;
      }
    );
  }

  print(): void {
    window.print();
  }
}
