import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ApiService } from '../../services/api.service';  
import { Livro, CreateLivroRequest, UpdateLivroRequest } from '../../models/livro.model';  
import { Autor } from 'src/app/models/autor.model';
import { Assunto } from 'src/app/models/assunto.model';
import { LivroAutorModel } from 'src/app/models/livro-autor.model';
import { LivroAssuntoModel } from 'src/app/models/livro-assunto.model';

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
    anoPublicacao: '',
    LivroAutores: [],
    LivroAssuntos: []
  };

  autores: Autor[] = [];
  assuntos: Assunto[] = [];

  selectedAutor: number | null = null;
  selectedAssunto: number | null = null;
  
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
    this.loadAutores();
    this.loadAssuntos();
    this.livroId = +this.route.snapshot.paramMap.get('id')!;
  
    if (this.livroId) {
      this.isEdit = true;
      this.livroService.getLivro(this.livroId).subscribe(
        (livro) => {
          //console.log("livro: ",livro);
          this.livro = livro;
          this.setSelectedAutores();
          this.setSelectedAssuntos();
        },
        (error) => console.error('Erro ao carregar livro', error)
      );
    }
  }
  
  setSelectedAutores(): void {
    console.log(this.livro.LivroAssuntos);
    this.selectedAutor = this.livro.LivroAutores.length > 0 ? this.livro.LivroAutores[0].autorCodAu : null;
  }
  
  setSelectedAssuntos(): void {
    this.selectedAssunto = this.livro.LivroAssuntos.length > 0 ? this.livro.LivroAssuntos[0].assuntoCodAs : null;
  }
  

  loadAutores(): void {
    this.livroService.getAutores().subscribe({
      next: (autores) => (this.autores = autores),
      error: (err) => console.error(err)
    });
  }

  loadAssuntos(): void {
    this.livroService.getAssuntos().subscribe({
      next: (assuntos) => (this.assuntos = assuntos),
      error: (err) => console.error(err)
    });
  }

  addAutor(): void {
    const autor = this.autores.find(a => a.codAu === this.selectedAutor);
    if (autor && !this.livro.LivroAutores.some(a => a.autorCodAu === autor.codAu)) {
      this.livro.LivroAutores.push({ livroCodl: this.livro.codigo, autorCodAu: autor.codAu, autor: autor });
    }
  }
  
  addAssunto(): void {
    const assunto = this.assuntos.find(a => a.codAs === this.selectedAssunto);
    if (assunto && !this.livro.LivroAssuntos.some(a => a.assuntoCodAs === assunto.codAs)) {
      this.livro.LivroAssuntos.push({ livroCodl: this.livro.codigo, assuntoCodAs: assunto.codAs, assunto: assunto });
    }
  }  

  removeAutor(autor: LivroAutorModel): void {
    this.livro.LivroAutores = this.livro.LivroAutores.filter(a => a.autorCodAu !== autor.autorCodAu);
  } 

  removeAssunto(assunto: LivroAssuntoModel): void {
    this.livro.LivroAssuntos = this.livro.LivroAssuntos.filter(a => a.assuntoCodAs !== assunto.assuntoCodAs);
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
