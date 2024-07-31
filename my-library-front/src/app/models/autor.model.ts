export interface Autor {
    codAu: number;
    nome: string;
  }
  
  export interface CreateAutorRequest {
    nome: string;
  }
  
  export interface UpdateAutorRequest {
    codAu: number;
    nome: string;
  }
  