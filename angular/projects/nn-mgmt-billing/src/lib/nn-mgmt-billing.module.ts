import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NnMgmtBillingComponent } from './components/nn-mgmt-billing.component';
import { NnMgmtBillingRoutingModule } from './nn-mgmt-billing-routing.module';

@NgModule({
  declarations: [NnMgmtBillingComponent],
  imports: [CoreModule, ThemeSharedModule, NnMgmtBillingRoutingModule],
  exports: [NnMgmtBillingComponent],
})
export class NnMgmtBillingModule {
  static forChild(): ModuleWithProviders<NnMgmtBillingModule> {
    return {
      ngModule: NnMgmtBillingModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<NnMgmtBillingModule> {
    return new LazyModuleFactory(NnMgmtBillingModule.forChild());
  }
}
