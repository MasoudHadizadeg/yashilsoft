import { TestBed } from '@angular/core/testing';

import { ReportDataService } from './report-data.service';

describe('ReportDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ReportDataService = TestBed.get(ReportDataService);
    expect(service).toBeTruthy();
  });
});
