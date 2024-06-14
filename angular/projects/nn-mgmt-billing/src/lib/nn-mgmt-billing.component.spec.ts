import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { NnMgmtBillingComponent } from './components/nn-mgmt-billing.component';
import { NnMgmtBillingService } from '@necnat.Abp/nn-mgmt-billing';
import { of } from 'rxjs';

describe('NnMgmtBillingComponent', () => {
  let component: NnMgmtBillingComponent;
  let fixture: ComponentFixture<NnMgmtBillingComponent>;
  const mockNnMgmtBillingService = jasmine.createSpyObj('NnMgmtBillingService', {
    sample: of([]),
  });
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [NnMgmtBillingComponent],
      providers: [
        {
          provide: NnMgmtBillingService,
          useValue: mockNnMgmtBillingService,
        },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NnMgmtBillingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
