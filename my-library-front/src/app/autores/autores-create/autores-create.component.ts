import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ApiService } from '../../services/api.service';  
import { Autor, CreateAutorRequest, UpdateAutorRequest } from '../../models/autor.model';  

@Component({
  selector: 'app-autores-create',
  templateUrl: './autores-create.component.html',
  styleUrls: ['./autores-create.component.css']
})
export class AutoresCreateComponent implements OnInit {
  autor: Autor = {
    codAu: 0,
    nome: ''
  };
  isEdit: boolean = false;
  autorId: number | null = null;

  constructor(
    private autorService: ApiService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.autorId = +this.route.snapshot.paramMap.get('id')!;

    if (this.autorId) {
      this.isEdit = true;
      this.autorService.getAutor(this.autorId).subscribe(
        (autor) => (this.autor = autor),
        (error) => console.error('Erro ao carregar autor', error)
      );
    }
  }

  onSubmit(form: NgForm): void {
    if (form.invalid) {
      return;
    }

    if (this.isEdit) {
      this.autorService.updateAutor(this.autor).subscribe(
        () => this.router.navigate(['/autores']),
        (error) => console.error('Erro ao atualizar autor', error)
      );
    } else {
      this.autorService.createAutor(this.autor).subscribe(
        () => this.router.navigate(['/autores']),
        (error) => console.error('Erro ao criar autor', error)
      );
    }
  }
}
