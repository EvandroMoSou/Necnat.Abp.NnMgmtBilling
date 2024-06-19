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
    public class EfCoreSkuScopeHistoryRepository : EfCoreHistoryRepository<NnMgmtBillingDbContext, SkuScopeHistory, Guid, SkuScope>, ISkuScopeHistoryRepository
    {
        public EfCoreSkuScopeHistoryRepository(IDbContextProvider<NnMgmtBillingDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task<List<SkuScope>> GetListEntityBySkuIdAsync(DateTime changeTimeDesc, Guid skuId)
        {
            var dbSet = await GetDbSetAsync();
            var historyList = await dbSet.Where(x => x.SkuId == skuId && x.ChangeTime <= changeTimeDesc).OrderByDescending(x => x.ChangeTime).ToListAsync();

            var list = new List<SkuScope>();
            foreach (var history in historyList)
            {
                if (history == null || history.ChangeType == (int)ChangeType.Deleted)
                    continue;

                var entity = JsonUtil.CloneTo<SkuScopeHistory, SkuScope>(history);
                entity.Id = history.BaseId;
                list.Add(entity);
            }

            return MapToEntity(historyList);
        }

    }
}
