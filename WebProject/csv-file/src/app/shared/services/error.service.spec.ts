import { TestBed } from '@angular/core/testing';

import { ErrorService } from './error.service';

describe('ErrorService', () => {
  let service: ErrorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ErrorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should trigger event', done => {
    const service: ErrorService = TestBed.inject(ErrorService);
    service.stateAlert().subscribe(res => {
      expect(res).toBeTruthy();
      done();
    });
    service.chageStateAlert({
      type: 'info',
      title: 'info',
      message: 'info'
    });
  });
});
