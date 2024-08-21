
import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';
import { LivroValor } from '../models/livroValor.model';
import { Router } from '@angular/router';
import { LivroValorResponse } from '../models/livroValorResponse.model';

@Component({
  selector: 'app-livro-valor',
  templateUrl: './livro-valor.component.html',
  styleUrls: ['./livro-valor.component.css']
})
export class LivroValorComponent implements OnInit {
  livroValores: LivroValorResponse[] = [];
  selectedLivroValor?: LivroValor;

  constructor(private apiService: ApiService, private router: Router) { }

  ngOnInit(): void {
    this.loadLivroValores();
  }

  loadLivroValores(): void {
    this.apiService.getAllLivroValor().subscribe( 
      (data) =>
      { 
        this.livroValores = data;
      },
      error => console.error('Erro ao carregar os valores dos livros', error)
    );
  }

  selectLivroValor(livroValor: LivroValor): void {
    this.selectedLivroValor = livroValor;
  }

  createLivroValor(livroValor: LivroValor): void {
    this.apiService.createLivroValor(livroValor).subscribe(
      (data) => {
        // this.livroValores.push(data);
        this.selectedLivroValor = undefined;
      },
      error => console.error('Erro ao criar o valor do livro', error)
    );
  }

  editLivroValor(item: LivroValor) {
    this.router.navigate(['/livro-valor/edit', item.livroCodl, item.tipoVendaCodTv]);
  }

  deleteLivroValor(item: LivroValor) {
    if (confirm('Tem certeza que deseja excluir este valor?')) {
      this.apiService.deleteLivroValor(item.livroCodl, item.tipoVendaCodTv).subscribe(() => {
        this.loadLivroValores(); // Atualiza a lista após exclusão
      });
    }
  }
}
