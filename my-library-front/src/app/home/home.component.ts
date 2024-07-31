import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  cards = [
    {
      title: 'Livros',
      description: 'Gerencie seus livros',
      image: 'assets/livros.jpg', // Substitua com o caminho real da imagem
      route: '/livros'
    },
    {
      title: 'Autores',
      description: 'Gerencie seus autores',
      image: 'assets/autores.jpg', // Substitua com o caminho real da imagem
      route: '/autores'
    },
    {
      title: 'Assuntos',
      description: 'Gerencie seus assuntos',
      image: 'assets/assuntos.jpg', // Substitua com o caminho real da imagem
      route: '/assuntos'
    }
  ];

  constructor(private router: Router) {}

  navigateTo(route: string) {
    this.router.navigate([route]);
  }
}
