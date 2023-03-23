/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AtoLiberacaoService } from './atoLiberacao.service';

describe('Service: AtoLiberacao', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AtoLiberacaoService]
    });
  });

  it('should ...', inject([AtoLiberacaoService], (service: AtoLiberacaoService) => {
    expect(service).toBeTruthy();
  }));
});
