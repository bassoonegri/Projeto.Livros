import { TestBed } from '@angular/core/testing';

import { LivroValorService } from './livro-valor.service';

describe('LivroValorService', () => {
  let service: LivroValorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LivroValorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
