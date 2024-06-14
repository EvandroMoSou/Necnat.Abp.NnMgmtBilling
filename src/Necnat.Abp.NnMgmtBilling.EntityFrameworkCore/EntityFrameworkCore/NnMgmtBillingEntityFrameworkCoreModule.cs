using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Necnat.Abp.NnMgmtBilling.EntityFrameworkCore;

[DependsOn(
    typeof(NnMgmtBillingDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class NnMgmtBillingEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<NnMgmtBillingDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}
