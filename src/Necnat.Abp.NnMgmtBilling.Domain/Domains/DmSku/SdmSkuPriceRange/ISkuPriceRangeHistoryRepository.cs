using Necnat.Abp.NnLibCommon.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public interface ISkuPriceRangeHistoryRepository : IHistoryRepository<SkuPriceRangeHistory, Guid, SkuPriceRange>
    {
        Task<List<SkuPriceRange>> GetListEntityBySkuIdAsync(DateTime changeTimeDesc, Guid skuId);
    }
}
