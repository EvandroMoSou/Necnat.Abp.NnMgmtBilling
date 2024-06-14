using Necnat.Abp.NnLibCommon.Repositories;
using Necnat.Abp.NnMgmtBilling.EntityFrameworkCore;
using System;
using Volo.Abp.EntityFrameworkCore;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class EfCoreBillingContractHistoryRepository : EfCoreHistoryRepository<NnMgmtBillingDbContext, BillingContractHistory, Guid, BillingContract>, IBillingContractHistoryRepository
    {
        public EfCoreBillingContractHistoryRepository(IDbContextProvider<NnMgmtBillingDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
