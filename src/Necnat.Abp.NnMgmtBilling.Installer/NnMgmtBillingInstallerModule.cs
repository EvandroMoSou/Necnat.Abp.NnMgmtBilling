using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Necnat.Abp.NnMgmtBilling;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class NnMgmtBillingInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<NnMgmtBillingInstallerModule>();
        });
    }
}
