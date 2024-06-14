using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Necnat.Abp.NnMgmtBilling.EntityFrameworkCore;

[ConnectionStringName(NnMgmtBillingDbProperties.ConnectionStringName)]
public class NnMgmtBillingDbContext : AbpDbContext<NnMgmtBillingDbContext>, INnMgmtBillingDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public NnMgmtBillingDbContext(DbContextOptions<NnMgmtBillingDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureNnMgmtBilling();
    }
}
