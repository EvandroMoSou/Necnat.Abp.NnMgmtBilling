using Necnat.Abp.NnMgmtBilling.EntityFrameworkCore;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class EfCoreSkuRepository : EfCoreRepository<INnMgmtBillingDbContext, Sku, Guid>, ISkuRepository
    {
        public EfCoreSkuRepository(IDbContextProvider<INnMgmtBillingDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
