using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Necnat.Abp.NnMgmtBilling.MongoDB;

public static class NnMgmtBillingMongoDbContextExtensions
{
    public static void ConfigureNnMgmtBilling(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
