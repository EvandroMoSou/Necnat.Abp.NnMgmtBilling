using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace Necnat.Abp.NnMgmtBilling;

[DependsOn(
    typeof(NnMgmtBillingDomainModule),
    typeof(NnMgmtBillingApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class NnMgmtBillingApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<NnMgmtBillingApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<NnMgmtBillingApplicationModule>(validate: true);
        });
    }
}
