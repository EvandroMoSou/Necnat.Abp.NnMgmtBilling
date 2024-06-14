import { Component, OnInit } from '@angular/core';
import { NnMgmtBillingService } from '../services/nn-mgmt-billing.service';

@Component({
  selector: 'lib-nn-mgmt-billing',
  template: ` <p>nn-mgmt-billing works!</p> `,
  styles: [],
})
export class NnMgmtBillingComponent implements OnInit {
  constructor(private service: NnMgmtBillingService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
