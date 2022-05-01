import { TestBed } from '@angular/core/testing';

import { CsvFilesStoreService } from './csv-files-store.service';

describe('CsvFilesStoreService', () => {
  let service: CsvFilesStoreService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CsvFilesStoreService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
