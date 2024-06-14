using Volo.Abp.Modularity;

namespace Necnat.Abp.NnMgmtBilling;

[DependsOn(
    typeof(NnMgmtBillingDomainModule),
    typeof(NnMgmtBillingTestBaseModule)
)]
public class NnMgmtBillingDomainTestModule : AbpModule
{

}
