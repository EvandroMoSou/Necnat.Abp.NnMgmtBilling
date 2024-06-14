using Necnat.Abp.NnMgmtBilling.EntityFrameworkCore;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.OpenIddict.Applications;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class EfCoreNnOpenIddictApplicationRepository : EfCoreRepository<NnMgmtBillingDbContext, OpenIddictApplication, Guid>, INnOpenIddictApplicationRepository
    {
        public EfCoreNnOpenIddictApplicationRepository(IDbContextProvider<NnMgmtBillingDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
