using Microsoft.EntityFrameworkCore;
using Necnat.Abp.NnMgmtBilling.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class EfCoreSkuScopeRepository : EfCoreRepository<NnMgmtBillingDbContext, SkuScope, Guid>, ISkuScopeRepository
    {
        public EfCoreSkuScopeRepository(IDbContextProvider<NnMgmtBillingDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task<List<SkuScope>> GetListBySkuIdAsync(Guid skuId)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.Where(x => x.SkuId == skuId).ToListAsync();
        }
    }
}
