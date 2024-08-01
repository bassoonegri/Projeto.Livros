import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router'; 
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LivrosComponent } from './livros/livros.component';
import { AutoresComponent } from './autores/autores.component';
import { AssuntosComponent } from './assuntos/assuntos.component';
import { FormsModule } from '@angular/forms'; 
import { HttpClientModule } from '@angular/common/http';
import { AssuntosListComponent } from './assuntos/assuntos-list/assuntos-list.component';
import { AssuntosCreateComponent } from './assuntos/assuntos-create/assuntos-create.component';
import { AutoresCreateComponent } from './autores/autores-create/autores-create.component';
import { AutoresListComponent } from './autores/autores-list/autores-list.component';
import { LivrosListComponent } from './livros/livros-list/livros-list.component';
import { LivrosCreateComponent } from './livros/livros-create/livros-create.component';
import { LivrosRelatorioComponent } from './reports/livros-relatorio/livros-relatorio.component'; 


const routes: Routes = [
  { path: '', component: HomeComponent },

  { path: 'livros', component: LivrosListComponent },
  { path: 'livros/create', component: LivrosCreateComponent },
  { path: 'livros/edit/:id', component: LivrosCreateComponent },

  { path: 'autores', component: AutoresListComponent },  
  { path: 'autores/create', component: AutoresCreateComponent },
  { path: 'autores/edit/:id', component: AutoresCreateComponent },

  { path: 'assuntos', component: AssuntosListComponent },
  { path: 'assuntos/create', component: AssuntosCreateComponent },
  { path: 'assuntos/edit/:id', component: AssuntosCreateComponent },

  { path: 'relatorios', component: LivrosRelatorioComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    
    AutoresComponent,
    AutoresCreateComponent,
    AutoresListComponent,

    AssuntosComponent,
    AssuntosListComponent,
    AssuntosCreateComponent,

    LivrosComponent,
    LivrosListComponent,
    LivrosCreateComponent,
    LivrosRelatorioComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule, 
    RouterModule.forRoot(routes) // Configuração das rotas
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
