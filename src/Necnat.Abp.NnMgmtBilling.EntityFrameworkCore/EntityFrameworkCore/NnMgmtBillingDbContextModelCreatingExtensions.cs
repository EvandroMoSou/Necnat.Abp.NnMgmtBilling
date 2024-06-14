using Microsoft.EntityFrameworkCore;
using Necnat.Abp.NnMgmtBilling.Domains;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Necnat.Abp.NnMgmtBilling.EntityFrameworkCore;

public static class NnMgmtBillingDbContextModelCreatingExtensions
{
    public static void ConfigureNnMgmtBilling(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(NnMgmtBillingDbProperties.DbTablePrefix + "Questions", NnMgmtBillingDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */

        builder.Entity<BillingClient>(b =>
        {
            b.ToTable(NnMgmtBillingDbProperties.DbTablePrefix + "BillingClient",
                NnMgmtBillingDbProperties.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name).HasMaxLength(BillingClientConsts.MaxNameLength);
            b.Property(x => x.IsActive).IsRequired();

            b.HasMany(o => o.IdentityUserList).WithMany();
            b.HasMany(o => o.OpenIddictApplicationList).WithMany();
        });

        builder.Entity<BillingContract>(b =>
        {
            b.UseTpcMappingStrategy().ToTable(NnMgmtBillingDbProperties.DbTablePrefix + "BillingContract",
                NnMgmtBillingDbProperties.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Code).IsRequired().HasMaxLength(BillingContractConsts.MaxCodeLength);
            b.Property(x => x.SkuReferenceTime).IsRequired();
            b.Property(x => x.EffectiveTime).IsRequired();
            b.Property(x => x.IsActive).IsRequired();

            b.HasOne(o => o.BillingClient).WithMany(x => x.BillingContractList).HasForeignKey(x => x.BillingClientId).OnDelete(DeleteBehavior.Cascade);
            b.HasMany(o => o.SkuList).WithMany();

            b.HasIndex(u => u.Code).IsUnique();
        });

        builder.Entity<BillingContractHistory>(b =>
        {
            b.ToTable(NnMgmtBillingDbProperties.DbTablePrefix + "BillingContractHistory",
                NnMgmtBillingDbProperties.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Code).HasMaxLength(BillingContractConsts.MaxCodeLength);
            b.Property(x => x.ConcurrencyStamp).HasMaxLength(ConcurrencyStampConsts.MaxLength);

            b.HasIndex(u => new { u.BaseId, u.ChangeTime });
        });

        builder.Entity<BillingEndpoint>(b =>
        {
            b.ToTable(NnMgmtBillingDbProperties.DbTablePrefix + "BillingEndpoint",
                NnMgmtBillingDbProperties.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.DisplayName).HasMaxLength(BillingEndpointConsts.MaxDisplayNameLength);
            b.Property(x => x.Endpoint).IsRequired().HasMaxLength(BillingEndpointConsts.MaxEndpointLength);
            b.Property(x => x.IsActive).IsRequired();
        });

        builder.Entity<Sku>(b =>
        {
            b.ToTable(NnMgmtBillingDbProperties.DbTablePrefix + "Sku",
                NnMgmtBillingDbProperties.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name).IsRequired().HasMaxLength(SkuConsts.MaxNameLength);
            b.Property(x => x.IsActive).IsRequired();
        });

        builder.Entity<SkuHistory>(b =>
        {
            b.ToTable(NnMgmtBillingDbProperties.DbTablePrefix + "SkuHistory",
                NnMgmtBillingDbProperties.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name).HasMaxLength(SkuConsts.MaxNameLength);
            b.Property(x => x.ConcurrencyStamp).HasMaxLength(ConcurrencyStampConsts.MaxLength);

            b.HasIndex(u => new { u.BaseId, u.ChangeTime });
        });

        builder.Entity<SkuPriceRange>(b =>
        {
            b.ToTable(NnMgmtBillingDbProperties.DbTablePrefix + "SkuPriceRange",
                NnMgmtBillingDbProperties.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Price).IsRequired().HasPrecision(12, 8);

            b.HasOne(o => o.Sku).WithMany(x => x.SkuPriceRangeList).HasForeignKey(x => x.SkuId).OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<SkuPriceRangeHistory>(b =>
        {
            b.ToTable(NnMgmtBillingDbProperties.DbTablePrefix + "SkuPriceRangeHistory",
                NnMgmtBillingDbProperties.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Price).HasPrecision(12, 8);
            b.Property(x => x.ConcurrencyStamp).HasMaxLength(ConcurrencyStampConsts.MaxLength);

            b.HasIndex(u => new { u.BaseId, u.ChangeTime });
        });

        builder.Entity<SkuScope>(b =>
        {
            b.ToTable(NnMgmtBillingDbProperties.DbTablePrefix + "SkuScope",
                NnMgmtBillingDbProperties.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.ApplicationName).IsRequired().HasMaxLength(SkuScopeConsts.MaxApplicationNameLength);
            b.Property(x => x.Url).HasMaxLength(SkuScopeConsts.MaxUrlLength);
            b.Property(x => x.IsBillable).IsRequired();

            b.HasOne(o => o.Sku).WithMany(x => x.SkuScopeList).HasForeignKey(x => x.SkuId).OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<SkuScopeHistory>(b =>
        {
            b.ToTable(NnMgmtBillingDbProperties.DbTablePrefix + "SkuScopeHistory",
                NnMgmtBillingDbProperties.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.ApplicationName).HasMaxLength(SkuScopeConsts.MaxApplicationNameLength);
            b.Property(x => x.Url).HasMaxLength(SkuScopeConsts.MaxUrlLength);
            b.Property(x => x.ConcurrencyStamp).HasMaxLength(ConcurrencyStampConsts.MaxLength);

            b.HasIndex(u => new { u.BaseId, u.ChangeTime });
        });
    }
}
