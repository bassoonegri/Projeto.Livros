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
import { FooterComponent } from './footer/footer.component';
import { LivroValorComponent } from './livro-valor/livro-valor.component'; 
import { LivroValorCreateComponent } from './livro-valor/livro-valor-create/livro-valor-create.component';
import { LivroValorEditComponent } from './livro-valor/livro-valor-edit/livro-valor-edit.component';
import { CurrencyMaskModule } from 'ng2-currency-mask';


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
  
  { path: 'livro-valor', component: LivroValorComponent },
  { path: 'livro-valor/create', component: LivroValorCreateComponent },
  { path: 'livro-valor/edit/:livroCodl/:tipoVendaCodTv', component: LivroValorEditComponent },
 

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
    
    LivroValorComponent,
    LivroValorCreateComponent,
    LivroValorEditComponent,

    LivrosComponent,
    LivrosListComponent,
    LivrosCreateComponent,
    LivrosRelatorioComponent,
    FooterComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule, 
    CurrencyMaskModule,
    RouterModule.forRoot(routes) // Configuração das rotas
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
