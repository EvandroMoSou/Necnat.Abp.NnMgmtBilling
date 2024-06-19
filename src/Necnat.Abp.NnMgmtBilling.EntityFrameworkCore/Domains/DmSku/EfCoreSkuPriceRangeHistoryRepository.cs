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
    public class EfCoreSkuPriceRangeHistoryRepository : EfCoreHistoryRepository<NnMgmtBillingDbContext, SkuPriceRangeHistory, Guid, SkuPriceRange>, ISkuPriceRangeHistoryRepository
    {
        public EfCoreSkuPriceRangeHistoryRepository(IDbContextProvider<NnMgmtBillingDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task<List<SkuPriceRange>> GetListEntityBySkuIdAsync(DateTime changeTimeDesc, Guid skuId)
        {
            var dbSet = await GetDbSetAsync();
            var historyList = await dbSet.Where(x => x.SkuId == skuId && x.ChangeTime <= changeTimeDesc).OrderByDescending(x => x.ChangeTime).ToListAsync();

            var list = new List<SkuPriceRange>();
            foreach (var history in historyList)
            {
                if (history == null || history.ChangeType == (int)ChangeType.Deleted)
                    continue;

                var entity = JsonUtil.CloneTo<SkuPriceRangeHistory, SkuPriceRange>(history);
                entity.Id = history.BaseId;
                list.Add(entity);
            }

            return list;
        }

    }
}
