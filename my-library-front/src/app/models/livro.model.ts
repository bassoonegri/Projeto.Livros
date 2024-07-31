export interface Livro {
    codigo: number;
    titulo: string;
    editora: string;
    edicao: number;
    anoPublicacao: string;
  }
  
  export interface CreateLivroRequest {
    titulo: string;
    editora: string;
    edicao: number;
    anoPublicacao: string;
  }
  
  export interface UpdateLivroRequest {
    codl: number;
    titulo: string;
    editora: string;
    edicao: number;
    anoPublicacao: string;
  }
  