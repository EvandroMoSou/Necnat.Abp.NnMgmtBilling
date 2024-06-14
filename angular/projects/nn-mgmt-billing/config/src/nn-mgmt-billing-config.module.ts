import { ModuleWithProviders, NgModule } from '@angular/core';
import { NN_MGMT_BILLING_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class NnMgmtBillingConfigModule {
  static forRoot(): ModuleWithProviders<NnMgmtBillingConfigModule> {
    return {
      ngModule: NnMgmtBillingConfigModule,
      providers: [NN_MGMT_BILLING_ROUTE_PROVIDERS],
    };
  }
}
