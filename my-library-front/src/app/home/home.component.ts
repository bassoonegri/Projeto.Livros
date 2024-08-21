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
      image: 'assets/livros.jpg', 
      route: '/livros'
    },
    {
      title: 'Autores',
      description: 'Gerencie seus autores',
      image: 'assets/autores.jpg',
      route: '/autores'
    },
    {
      title: 'Assuntos',
      description: 'Gerencie seus assuntos',
      image: 'assets/assuntos.jpg',
      route: '/assuntos'
    },
    {
      title: 'Valor dos Livros',
      description: 'Gerencie os valores dos livros',
      image: 'assets/valor-dos-livros.jpg',  
      route: '/livro-valor'  
    },
    {
      title: 'Relatórios',
      description: 'Visualize e imprima relatórios',
      image: 'assets/relatorios.jpg', 
      route: '/relatorios'
    }
  ];

  constructor(private router: Router) {}

  navigateTo(route: string) {
    this.router.navigate([route]);
  }
}
