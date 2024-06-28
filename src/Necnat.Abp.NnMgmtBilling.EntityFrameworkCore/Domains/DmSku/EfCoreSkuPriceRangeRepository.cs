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
    public class EfCoreSkuPriceRangeRepository : EfCoreRepository<INnMgmtBillingDbContext, SkuPriceRange, Guid>, ISkuPriceRangeRepository
    {
        public EfCoreSkuPriceRangeRepository(IDbContextProvider<INnMgmtBillingDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task<List<SkuPriceRange>> GetListBySkuIdAsync(Guid skuId)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.Where(x => x.SkuId == skuId).ToListAsync();
        }
    }
}
