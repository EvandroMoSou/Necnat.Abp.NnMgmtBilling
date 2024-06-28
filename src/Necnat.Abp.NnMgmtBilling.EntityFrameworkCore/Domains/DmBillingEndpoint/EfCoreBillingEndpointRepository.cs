using Necnat.Abp.NnMgmtBilling.EntityFrameworkCore;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class EfCoreBillingEndpointRepository : EfCoreRepository<INnMgmtBillingDbContext, BillingEndpoint, Guid>, IBillingEndpointRepository
    {
        public EfCoreBillingEndpointRepository(IDbContextProvider<INnMgmtBillingDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
