using Microsoft.EntityFrameworkCore;
using Necnat.Abp.NnMgmtBilling.Domains;
using Volo.Abp.AuditLogging;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.OpenIddict.Applications;

namespace Necnat.Abp.NnMgmtBilling.EntityFrameworkCore;

[ConnectionStringName(NnMgmtBillingDbProperties.ConnectionStringName)]
public interface INnMgmtBillingDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */

    //Identity
    DbSet<IdentityUser> Users { get; }
    DbSet<IdentityRole> Roles { get; }
    DbSet<IdentityClaimType> ClaimTypes { get; }
    DbSet<OrganizationUnit> OrganizationUnits { get; }
    DbSet<IdentitySecurityLog> SecurityLogs { get; }
    DbSet<IdentityLinkUser> LinkUsers { get; }
    DbSet<IdentityUserDelegation> UserDelegations { get; }
    DbSet<IdentityUserRole> UserRoles { get; }

    //Others
    DbSet<AuditLog> AuditLogs { get; }
    DbSet<OpenIddictApplication> OpenIddictApplications { get; }


    //BillingManagement
    DbSet<BillingClient> BillingClient { get; }
    DbSet<BillingContract> BillingContract { get; }
    DbSet<BillingContractHistory> BillingContractHistory { get; }
    DbSet<BillingEndpoint> BillingEndpoint { get; }
    DbSet<Sku> Sku { get; }
    DbSet<SkuHistory> SkuHistory { get; }
    DbSet<SkuPriceRange> SkuPriceRange { get; }
    DbSet<SkuPriceRangeHistory> SkuPriceRangeHistory { get; }
    DbSet<SkuScope> SkuScope { get; }
    DbSet<SkuScopeHistory> SkuScopeHistory { get; }
}
