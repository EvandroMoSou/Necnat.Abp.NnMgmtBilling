using Necnat.Abp.NnLibCommon.Repositories;
using Necnat.Abp.NnMgmtBilling.EntityFrameworkCore;
using System;
using Volo.Abp.EntityFrameworkCore;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class EfCoreSkuHistoryRepository : EfCoreHistoryRepository<NnMgmtBillingDbContext, SkuHistory, Guid, Sku>, ISkuHistoryRepository
    {
        public EfCoreSkuHistoryRepository(IDbContextProvider<NnMgmtBillingDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }


    }
}
