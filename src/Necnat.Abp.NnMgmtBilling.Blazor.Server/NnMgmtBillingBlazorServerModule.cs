using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace Necnat.Abp.NnMgmtBilling.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(NnMgmtBillingBlazorModule)
    )]
public class NnMgmtBillingBlazorServerModule : AbpModule
{

}
