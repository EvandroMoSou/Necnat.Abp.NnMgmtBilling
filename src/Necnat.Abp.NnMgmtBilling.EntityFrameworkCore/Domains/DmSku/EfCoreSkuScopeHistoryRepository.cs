using EntityFrameworkCore.Triggered;
using Microsoft.EntityFrameworkCore;
using Necnat.Abp.NnLibCommon.Repositories;
using Necnat.Abp.NnLibCommon.Utils;
using Necnat.Abp.NnMgmtBilling.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class EfCoreSkuScopeTemporalRepository : EfCoreTemporalRepository<NnMgmtBillingDbContext, SkuScopeTemporal, Guid, SkuScope>, ISkuScopeTemporalRepository
    {
        public EfCoreSkuScopeTemporalRepository(IDbContextProvider<NnMgmtBillingDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task<List<SkuScope>> GetListBySkuIdAsync(DateTime period, Guid skuId)
        {
            var dbSet = await GetDbSetAsync();
            var temporalList = await dbSet.Where(x => x.SkuId == skuId && x.PeriodStart <= period && (x.PeriodEnd == null || x.PeriodEnd > period)).ToListAsync();
            return MapToEntity(temporalList);
        }
    }
}
