import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../../services/api.service';  
import { Livro } from '../../models/livro.model';  

@Component({
  selector: 'app-livros-list',
  templateUrl: './livros-list.component.html',
  styleUrls: ['./livros-list.component.css']
})
export class LivrosListComponent implements OnInit {
  livros: Livro[] = [];
  successMessage: string | null = null;
  errorMessage: string | null = null;

  constructor(private livroService: ApiService, private router: Router) {}

  ngOnInit(): void {
    this.loadLivros();
  }

  loadLivros(): void {
    this.livroService.getLivros().subscribe(
      (livros) => {  
        this.livros = livros
      },
      (error) => console.error('Erro ao carregar livros', error)
    );
  }

  deleteLivro(codigo: number): void {
    if (confirm('Tem certeza de que deseja excluir este livro?')) {
      this.livroService.deleteLivro(codigo).subscribe(
        () => {
          this.successMessage = 'Livro excluído com sucesso!';
          this.loadLivros(); 
        },
        (error) => {
          this.errorMessage = 'Erro ao excluir livro';
          console.error('Erro ao excluir livro', error);
        }
      );
    }
  }
}
