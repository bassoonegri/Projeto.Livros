export class LivroValor {
  livroCodl: number;
  tipoVendaCodTv: number;
  valor: number;

  constructor(livroCodl?: number, tipoVendaCodTv?: number, valor?: number) {
    this.livroCodl = livroCodl || 0;
    this.tipoVendaCodTv = tipoVendaCodTv || 0;
    this.valor = valor || 0;
  }
}
