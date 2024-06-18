Add Packages from:

- Necnat.Abp.NnLibCommon.*
- Necnat.Abp.NnMgmtBilling.*

Add DependsOn Modules from:

- Necnat.Abp.NnLibCommon.*
- Necnat.Abp.NnMgmtBilling.*

On EntityFrameworkCore DbContext Add:

[ReplaceDbContext(typeof(INnLibCommonDbContext))]
[ReplaceDbContext(typeof(INnMgmtBillingDbContext))]

INnLibCommonDbContext
INnMgmtBillingDbContext

builder.ConfigureNnLibCommon();
builder.ConfigureNnMgmtBilling();

On HttpApiHostModule Add:

options.ConventionalControllers.Create(typeof(NnLibCommonApplicationModule).Assembly);
options.ConventionalControllers.Create(typeof(NnMgmtBillingApplicationModule).Assembly);

On EntityFrameworkCoreModule:

        Configure<AbpDbContextOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also NnTesteMigrationsDbContextFactory for EF Core tooling. */

            options.Configure(configureOptions =>
            {
                configureOptions.UseSqlServer();
                configureOptions.DbContextOptions.ConfigureBillingManagement();
            });
        });
