import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service'; // Importe o serviço correto

@Component({
  selector: 'app-assuntos-list',
  templateUrl: './assuntos-list.component.html',
  styleUrls: ['./assuntos-list.component.css']
})
export class AssuntosListComponent implements OnInit {
  assuntos: any[] = []; // Substitua `any` pelo tipo correto
  successMessage: string | null = null;
  errorMessage: string | null = null;

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.loadAssuntos();
  }

  loadAssuntos() {
    this.apiService.getAssuntos().subscribe(
      (data) => {
        this.assuntos = data;
      },
      (error) => {
        this.errorMessage = 'Erro ao carregar os assuntos.';
        console.error('Erro ao carregar assuntos:', error);
      }
    );
  }

  deleteAssunto(codAs: number) {
    this.apiService.deleteAssunto(codAs).subscribe(
      () => {
        this.successMessage = 'Assunto excluído com sucesso!';
        this.loadAssuntos(); // Recarregue a lista após exclusão
      },
      (error) => {
        this.errorMessage = 'Erro ao excluir o assunto.';
        console.error('Erro ao excluir assunto:', error);
      }
    );
  }
}
