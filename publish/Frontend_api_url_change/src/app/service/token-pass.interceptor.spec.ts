import { TestBed } from '@angular/core/testing';

import { TokenPassInterceptor } from './token-pass.interceptor';

describe('TokenPassInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      TokenPassInterceptor
      ]
  }));

  it('should be created', () => {
    const interceptor: TokenPassInterceptor = TestBed.inject(TokenPassInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
