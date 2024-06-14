using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Necnat.Abp.NnMgmtBilling.MongoDB;

[ConnectionStringName(NnMgmtBillingDbProperties.ConnectionStringName)]
public class NnMgmtBillingMongoDbContext : AbpMongoDbContext, INnMgmtBillingMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureNnMgmtBilling();
    }
}
