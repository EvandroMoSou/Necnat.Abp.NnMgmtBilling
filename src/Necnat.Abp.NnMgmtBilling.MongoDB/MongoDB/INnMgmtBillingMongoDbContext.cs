using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Necnat.Abp.NnMgmtBilling.MongoDB;

[ConnectionStringName(NnMgmtBillingDbProperties.ConnectionStringName)]
public interface INnMgmtBillingMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
