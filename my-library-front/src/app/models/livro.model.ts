import { LivroAssuntoModel } from "./livro-assunto.model";
import { LivroAutorModel } from "./livro-autor.model";

export interface Livro {
    codigo: number;
    titulo: string;
    editora: string;
    edicao: number;
    anoPublicacao: string;
    Autores: LivroAutorModel[];
    Assuntos: LivroAssuntoModel[];
  }
  
  export interface CreateLivroRequest {
    titulo: string;
    editora: string;
    edicao: number;
    anoPublicacao: string;
    LivroAutores: LivroAutorModel[];
    LivroAssuntos: LivroAssuntoModel[];
  }
  
  export interface UpdateLivroRequest {
    codl: number;
    titulo: string;
    editora: string;
    edicao: number;
    anoPublicacao: string;
    LivroAutores: LivroAutorModel[];
    LivroAssuntos: LivroAssuntoModel[];
  }
  