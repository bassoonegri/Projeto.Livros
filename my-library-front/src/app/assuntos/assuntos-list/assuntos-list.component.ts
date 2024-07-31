import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service'; // Caminho para o serviço
import { Assunto} from '../../models/assunto.model'; // Caminho para o modelo

@Component({
  selector: 'app-assuntos-list',
  templateUrl: './assuntos-list.component.html',
  styleUrls: ['./assuntos-list.component.css']
})
export class AssuntosListComponent implements OnInit {
  assuntos: Assunto[] = [];

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.loadAssuntos();
  }

  loadAssuntos(): void {
    this.apiService.getAssuntos().subscribe({
      next: (data: Assunto[]) => {
        this.assuntos = data;
      },
      error: (err) => {
        console.error('Erro ao carregar assuntos', err);
      }
    });
  }

  deleteAssunto(codAs: number): void {
    if (confirm('Tem certeza que deseja excluir este assunto?')) {
      this.apiService.deleteAssunto(codAs).subscribe({
        next: () => {
          this.assuntos = this.assuntos.filter(a => a.codAs !== codAs);
        },
        error: (err) => {
          console.error('Erro ao excluir assunto', err);
        }
      });
    }
  }
}
