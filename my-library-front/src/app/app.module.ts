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


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'livros', component: LivrosListComponent },
  { path: 'autores', component: AutoresListComponent },
  { path: 'assuntos', component: AssuntosListComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LivrosComponent,
    AutoresComponent,
    AssuntosComponent,
    AssuntosListComponent,
    AssuntosCreateComponent,
    AutoresCreateComponent,
    AutoresListComponent,
    LivrosListComponent,
    LivrosCreateComponent
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
