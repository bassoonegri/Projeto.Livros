import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LivrosRelatorioComponent } from './livros-relatorio.component';

describe('LivrosRelatorioComponent', () => {
  let component: LivrosRelatorioComponent;
  let fixture: ComponentFixture<LivrosRelatorioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LivrosRelatorioComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LivrosRelatorioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
