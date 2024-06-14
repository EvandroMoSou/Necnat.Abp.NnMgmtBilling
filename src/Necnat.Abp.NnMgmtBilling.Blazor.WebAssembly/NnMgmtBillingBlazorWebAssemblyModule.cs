using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace Necnat.Abp.NnMgmtBilling.Blazor.WebAssembly;

[DependsOn(
    typeof(NnMgmtBillingBlazorModule),
    typeof(NnMgmtBillingHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class NnMgmtBillingBlazorWebAssemblyModule : AbpModule
{

}
