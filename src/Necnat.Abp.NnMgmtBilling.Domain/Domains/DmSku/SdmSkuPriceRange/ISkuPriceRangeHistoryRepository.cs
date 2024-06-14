using Necnat.Abp.NnLibCommon.Repositories;
using System;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public interface ISkuPriceRangeHistoryRepository : IHistoryRepository<SkuPriceRangeHistory, Guid, SkuPriceRange>
    {

    }
}
