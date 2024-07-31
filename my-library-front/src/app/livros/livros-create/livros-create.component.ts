import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ApiService } from '../../services/api.service';  
import { Livro, CreateLivroRequest, UpdateLivroRequest } from '../../models/livro.model';  

@Component({
  selector: 'app-livros-create',
  templateUrl: './livros-create.component.html',
  styleUrls: ['./livros-create.component.css']
})
export class LivrosCreateComponent implements OnInit {
  livro: Livro = {
    codigo: 0,
    titulo: '',
    editora: '',
    edicao: 0,
    anoPublicacao: ''
  };
  isEdit: boolean = false;
  livroId: number | null = null;
  successMessage: string | null = null;  
  errorMessage: string | null = null;  

  constructor(
    private livroService: ApiService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.livroId = +this.route.snapshot.paramMap.get('id')!;

    if (this.livroId) {
      this.isEdit = true;
      this.livroService.getLivro(this.livroId).subscribe(
        (livro) => (this.livro = livro),
        (error) => console.error('Erro ao carregar livro', error)
      );
    }
  }

  onSubmit(form: NgForm): void {
    if (this.isEdit) {
      this.livroService.updateLivro(this.livro).subscribe(
        () => {
          this.successMessage = 'Livro atualizado com sucesso!';
          setTimeout(() => this.router.navigate(['/livros']), 2000);
        },
        (error) => {
          this.errorMessage = 'Erro ao atualizar livro';
          console.error('Erro ao atualizar livro', error);
        }
      );
    } else {
      this.livroService.createLivro(this.livro).subscribe(
        () => {
          this.successMessage = 'Livro criado com sucesso!';
          setTimeout(() => this.router.navigate(['/livros']), 2000);
        },
        (error) => {
          this.errorMessage = 'Erro ao criar livro';
          console.error('Erro ao criar livro', error);
        }
      );
    }
  }
}
