
export interface LivroValorResponse {
    livroCodl: number;
    livroTitulo: string; // Adicionado para incluir o título do Livro

    tipoVendaCodTv: number;
    tipoVendaDescricao: string; // Adicionado para incluir a descrição do TipoVenda
    valor: number;

    imageUrl: string; // Adicione esta propriedade para a URL da imagem

    
  }
  