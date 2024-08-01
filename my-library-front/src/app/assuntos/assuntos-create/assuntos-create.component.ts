import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ApiService } from '../../services/api.service';
import { Assunto } from '../../models/assunto.model';

@Component({
  selector: 'app-assuntos-create',
  templateUrl: './assuntos-create.component.html',
  styleUrls: ['./assuntos-create.component.css']
})
export class AssuntosCreateComponent implements OnInit {
  assunto: Assunto = { codAs:0, descricao: '' };
  isEdit: boolean = false;
  assuntoId: number | null = null;
  successMessage: string | null = null;
  errorMessage: string | null = null;

  constructor(
    private apiService: ApiService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.assuntoId = +this.route.snapshot.paramMap.get('id')!;

    if (this.assuntoId) {
      this.isEdit = true;
      this.apiService.getAssunto(this.assuntoId).subscribe(
        (assunto) => this.assunto = assunto,
        (error) => {
          this.errorMessage = 'Erro ao carregar o assunto.';
          console.error('Erro ao carregar assunto', error);
        }
      );
    }
  }

  onSubmit(form: NgForm): void {
    if (form.invalid) {
      return;
    }

    if (this.isEdit) {
      this.apiService.updateAssunto(this.assunto).subscribe(
        () => {
          this.successMessage = 'Assunto atualizado com sucesso!';
          this.router.navigate(['/assuntos']);
        },
        (error) => {
          this.errorMessage = 'Erro ao atualizar o assunto.';
          console.error('Erro ao atualizar assunto', error);
        }
      );
    } else {
      this.apiService.createAssunto(this.assunto).subscribe(
        () => {
          this.successMessage = 'Assunto criado com sucesso!';
          this.router.navigate(['/assuntos']);
        },
        (error) => {
          this.errorMessage = 'Erro ao criar o assunto.';
          console.error('Erro ao criar assunto', error);
        }
      );
    }
  }
}
