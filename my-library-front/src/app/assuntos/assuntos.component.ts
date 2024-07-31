import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';
import { Assunto } from '../models/assunto.model';

@Component({
  selector: 'app-assuntos',
  templateUrl: './assuntos.component.html',
  styleUrls: ['./assuntos.component.css']
})
export class AssuntosComponent implements OnInit {
  assunto: Assunto = { codAs: 0, descricao: '' };
  assuntos: Assunto[] = [];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.loadAssuntos();
  }

  loadAssuntos(): void {
    this.apiService.getAssuntos().subscribe(data => this.assuntos = data);
  }

  onSubmit(): void {
    if (this.assunto.codAs) {
      this.apiService.updateAssunto(this.assunto).subscribe(() => this.loadAssuntos());
    } else {
      this.apiService.createAssunto(this.assunto).subscribe(() => this.loadAssuntos());
    }
    this.resetForm();
  }

  editAssunto(assunto: Assunto): void {
    this.assunto = { ...assunto };
  }

  deleteAssunto(codAs: number): void {
    this.apiService.deleteAssunto(codAs).subscribe(() => this.loadAssuntos());
  }

  resetForm(): void {
    this.assunto = { codAs: 0, descricao: '' };
  }
}
