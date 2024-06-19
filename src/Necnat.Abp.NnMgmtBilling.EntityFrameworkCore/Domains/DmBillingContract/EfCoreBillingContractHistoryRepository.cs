using Necnat.Abp.NnLibCommon.Repositories;
using Necnat.Abp.NnMgmtBilling.EntityFrameworkCore;
using System;
using Volo.Abp.EntityFrameworkCore;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class EfCoreBillingContractTemporalRepository : EfCoreTemporalRepository<NnMgmtBillingDbContext, BillingContractTemporal, Guid, BillingContract>, IBillingContractTemporalRepository
    {
        public EfCoreBillingContractTemporalRepository(IDbContextProvider<NnMgmtBillingDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
