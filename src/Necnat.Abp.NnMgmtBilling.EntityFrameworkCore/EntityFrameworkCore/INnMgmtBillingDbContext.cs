using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Necnat.Abp.NnMgmtBilling.EntityFrameworkCore;

[ConnectionStringName(NnMgmtBillingDbProperties.ConnectionStringName)]
public interface INnMgmtBillingDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
