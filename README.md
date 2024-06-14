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
