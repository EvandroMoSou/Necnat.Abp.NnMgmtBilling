using Necnat.Abp.NnLibCommon.Repositories;
using Necnat.Abp.NnMgmtBilling.EntityFrameworkCore;
using System;
using Volo.Abp.EntityFrameworkCore;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class EfCoreSkuTemporalRepository : EfCoreTemporalRepository<NnMgmtBillingDbContext, SkuTemporal, Guid, Sku>, ISkuTemporalRepository
    {
        public EfCoreSkuTemporalRepository(IDbContextProvider<NnMgmtBillingDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }


    }
}
