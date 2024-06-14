using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Necnat.Abp.NnMgmtBilling;

[DependsOn(
    typeof(NnMgmtBillingDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class NnMgmtBillingApplicationContractsModule : AbpModule
{

}
