using Necnat.Abp.NnMgmtBilling.EntityFrameworkCore;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.OpenIddict.Applications;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class EfCoreNnOpenIddictApplicationRepository : EfCoreRepository<INnMgmtBillingDbContext, OpenIddictApplication, Guid>, INnOpenIddictApplicationRepository
    {
        public EfCoreNnOpenIddictApplicationRepository(IDbContextProvider<INnMgmtBillingDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
