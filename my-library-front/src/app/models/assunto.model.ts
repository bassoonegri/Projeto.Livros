export interface Assunto {
  codAs: number;
  descricao: string;
}

export interface CreateAssuntoRequest {
  descricao: string;
}

export interface UpdateAssuntoRequest {
  codAs: number;
  descricao: string;
}
