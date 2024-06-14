import { TestBed } from '@angular/core/testing';
import { NnMgmtBillingService } from './services/nn-mgmt-billing.service';
import { RestService } from '@abp/ng.core';

describe('NnMgmtBillingService', () => {
  let service: NnMgmtBillingService;
  const mockRestService = jasmine.createSpyObj('RestService', ['request']);
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        {
          provide: RestService,
          useValue: mockRestService,
        },
      ],
    });
    service = TestBed.inject(NnMgmtBillingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
