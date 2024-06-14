using Necnat.Abp.NnLibCommon.Repositories;
using Necnat.Abp.NnMgmtBilling.EntityFrameworkCore;
using System;
using Volo.Abp.EntityFrameworkCore;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class EfCoreSkuScopeHistoryRepository : EfCoreHistoryRepository<NnMgmtBillingDbContext, SkuScopeHistory, Guid, SkuScope>, ISkuScopeHistoryRepository
    {
        public EfCoreSkuScopeHistoryRepository(IDbContextProvider<NnMgmtBillingDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
