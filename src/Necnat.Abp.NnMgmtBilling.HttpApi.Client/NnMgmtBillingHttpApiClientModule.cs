using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Necnat.Abp.NnMgmtBilling;

[DependsOn(
    typeof(NnMgmtBillingApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class NnMgmtBillingHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(NnMgmtBillingApplicationContractsModule).Assembly,
            NnMgmtBillingRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<NnMgmtBillingHttpApiClientModule>();
        });

    }
}
