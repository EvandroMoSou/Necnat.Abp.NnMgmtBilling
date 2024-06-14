using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;

namespace Necnat.Abp.NnMgmtBilling.MongoDB;

[DependsOn(
    typeof(NnMgmtBillingApplicationTestModule),
    typeof(NnMgmtBillingMongoDbModule)
)]
public class NnMgmtBillingMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = MongoDbFixture.GetRandomConnectionString();
        });
    }
}
