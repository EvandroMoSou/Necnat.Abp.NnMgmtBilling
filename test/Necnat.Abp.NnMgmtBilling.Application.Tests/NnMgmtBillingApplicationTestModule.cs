using Volo.Abp.Modularity;

namespace Necnat.Abp.NnMgmtBilling;

[DependsOn(
    typeof(NnMgmtBillingApplicationModule),
    typeof(NnMgmtBillingDomainTestModule)
    )]
public class NnMgmtBillingApplicationTestModule : AbpModule
{

}
