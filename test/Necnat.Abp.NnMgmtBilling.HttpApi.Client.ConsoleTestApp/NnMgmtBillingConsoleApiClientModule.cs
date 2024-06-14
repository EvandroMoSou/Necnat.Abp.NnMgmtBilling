using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Necnat.Abp.NnMgmtBilling;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(NnMgmtBillingHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class NnMgmtBillingConsoleApiClientModule : AbpModule
{

}
