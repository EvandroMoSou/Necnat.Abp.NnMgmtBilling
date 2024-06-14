using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Necnat.Abp.NnMgmtBilling;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(NnMgmtBillingDomainSharedModule)
)]
public class NnMgmtBillingDomainModule : AbpModule
{

}
