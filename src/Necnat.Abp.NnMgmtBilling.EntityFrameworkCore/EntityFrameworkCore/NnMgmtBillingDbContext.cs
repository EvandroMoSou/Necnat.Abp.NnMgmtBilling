using Microsoft.EntityFrameworkCore;
using Necnat.Abp.NnMgmtBilling.Domains;
using Volo.Abp.AuditLogging;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.Applications;

namespace Necnat.Abp.NnMgmtBilling.EntityFrameworkCore;

[ConnectionStringName(NnMgmtBillingDbProperties.ConnectionStringName)]
public class NnMgmtBillingDbContext : AbpDbContext<NnMgmtBillingDbContext>, INnMgmtBillingDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentityUserRole> UserRoles { get; set; }

    //Others
    public DbSet<AuditLog> AuditLogs { get; set; }
    public DbSet<OpenIddictApplication> OpenIddictApplications { get; set; }

    //BillingManagement

    public DbSet<BillingClient> BillingClient { get; set; }
    public DbSet<BillingContract> BillingContract { get; set; }
    public DbSet<BillingContractHistory> BillingContractHistory { get; set; }
    public DbSet<BillingEndpoint> BillingEndpoint { get; set; }
    public DbSet<Sku> Sku { get; set; }
    public DbSet<SkuHistory> SkuHistory { get; set; }
    public DbSet<SkuPriceRange> SkuPriceRange { get; set; }
    public DbSet<SkuPriceRangeHistory> SkuPriceRangeHistory { get; set; }
    public DbSet<SkuScope> SkuScope { get; set; }
    public DbSet<SkuScopeHistory> SkuScopeHistory { get; set; }

    public NnMgmtBillingDbContext(DbContextOptions<NnMgmtBillingDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureIdentity();
        builder.ConfigureNnMgmtBilling();
    }
}
