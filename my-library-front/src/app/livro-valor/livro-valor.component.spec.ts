import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LivroValorComponent } from './livro-valor.component';

describe('LivroValorComponent', () => {
  let component: LivroValorComponent;
  let fixture: ComponentFixture<LivroValorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LivroValorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LivroValorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
