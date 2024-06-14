using Necnat.Abp.NnLibCommon.Repositories;
using Necnat.Abp.NnMgmtBilling.EntityFrameworkCore;
using System;
using Volo.Abp.EntityFrameworkCore;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class EfCoreSkuPriceRangeHistoryRepository : EfCoreHistoryRepository<NnMgmtBillingDbContext, SkuPriceRangeHistory, Guid, SkuPriceRange>, ISkuPriceRangeHistoryRepository
    {
        public EfCoreSkuPriceRangeHistoryRepository(IDbContextProvider<NnMgmtBillingDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
