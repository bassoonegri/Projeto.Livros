import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../../services/api.service';
import { LivroValor } from '../../models/livroValor.model';
import { TipoVenda } from 'src/app/models/tipoVenda.model';
import { Livro } from 'src/app/models/livro.model';

@Component({
  selector: 'app-livro-valor-create',
  templateUrl: './livro-valor-create.component.html',
  styleUrls: ['./livro-valor-create.component.css']
})
export class LivroValorCreateComponent {
  livroValor: LivroValor = new LivroValor();
  tiposVenda: TipoVenda[] = [];
  livros: Livro[] = [];

  constructor(private apiService: ApiService, private router: Router) {}

  ngOnInit(): void {
    this.loadTiposVenda();
    this.loadLivros();
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
    this.apiService.createLivroValor(this.livroValor).subscribe(() => {
      this.router.navigate(['/livro-valor']);
    });
  }
}
