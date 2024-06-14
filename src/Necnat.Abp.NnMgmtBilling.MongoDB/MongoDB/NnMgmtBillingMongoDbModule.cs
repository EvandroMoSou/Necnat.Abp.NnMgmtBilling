using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Necnat.Abp.NnMgmtBilling.MongoDB;

[DependsOn(
    typeof(NnMgmtBillingDomainModule),
    typeof(AbpMongoDbModule)
    )]
public class NnMgmtBillingMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<NnMgmtBillingMongoDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
        });
    }
}
