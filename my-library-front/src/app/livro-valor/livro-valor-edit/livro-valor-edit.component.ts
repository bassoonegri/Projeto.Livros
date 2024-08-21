import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LivroValor } from '../../models/livroValor.model';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-livro-valor-edit',
  templateUrl: './livro-valor-edit.component.html',
  styleUrls: ['./livro-valor-edit.component.css']
})
export class LivroValorEditComponent implements OnInit {
  livroValor: LivroValor = new LivroValor();
  livros: any[] = [];  
  tiposVenda: any[] = [];  
  livroCodl: number = 0;
  tipoVendaCodTv: number= 0;

  constructor(
    private apiService: ApiService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {

    const livroCodlParam = this.route.snapshot.paramMap.get('livroCodl');
    const tipoVendaCodTvParam = this.route.snapshot.paramMap.get('tipoVendaCodTv');
  
    this.livroCodl = livroCodlParam ? +livroCodlParam : 0;
    this.tipoVendaCodTv = tipoVendaCodTvParam ? +tipoVendaCodTvParam : 0;

    this.loadLivroValor();
    this.loadLivros();
    this.loadTiposVenda();
  }

  loadLivroValor() {
    this.apiService.getLivroValor(this.livroCodl, this.tipoVendaCodTv).subscribe(data => {
      this.livroValor = data;
    });
  }

  loadLivros() {
    this.apiService.getLivros().subscribe(data => {
      this.livros = data;
    });
  }

  loadTiposVenda() {
    this.apiService.getTiposVenda().subscribe(data => {
      this.tiposVenda = data;
    });
  }

  onSubmit() {
    this.apiService.updateLivroValor(this.livroValor).subscribe(() => {
      this.router.navigate(['/livro-valor']);
    });
  }
}
