using Localization.Resources.AbpUi;
using Necnat.Abp.NnMgmtBilling.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Necnat.Abp.NnMgmtBilling;

[DependsOn(
    typeof(NnMgmtBillingApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class NnMgmtBillingHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(NnMgmtBillingHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<NnMgmtBillingResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
