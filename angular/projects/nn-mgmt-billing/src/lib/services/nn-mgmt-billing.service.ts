import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class NnMgmtBillingService {
  apiName = 'NnMgmtBilling';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/NnMgmtBilling/sample' },
      { apiName: this.apiName }
    );
  }
}
