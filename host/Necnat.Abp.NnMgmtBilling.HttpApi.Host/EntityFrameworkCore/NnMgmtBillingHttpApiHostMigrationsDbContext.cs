using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Necnat.Abp.NnMgmtBilling.EntityFrameworkCore;

public class NnMgmtBillingHttpApiHostMigrationsDbContext : AbpDbContext<NnMgmtBillingHttpApiHostMigrationsDbContext>
{
    public NnMgmtBillingHttpApiHostMigrationsDbContext(DbContextOptions<NnMgmtBillingHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureNnMgmtBilling();
    }
}
