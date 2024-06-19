using Necnat.Abp.NnLibCommon.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public interface ISkuPriceRangeTemporalRepository : ITemporalRepository<SkuPriceRangeTemporal, Guid, SkuPriceRange>
    {
        Task<List<SkuPriceRange>> GetListEntityBySkuIdAsync(DateTime changeTimeDesc, Guid skuId);
    }
}
