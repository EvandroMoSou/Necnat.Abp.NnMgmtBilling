using Necnat.Abp.NnLibCommon.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public interface ISkuScopeHistoryRepository : IHistoryRepository<SkuScopeHistory, Guid, SkuScope>
    {
        Task<List<SkuScope>> GetListEntityBySkuIdAsync(DateTime changeTimeDesc, Guid skuId);
    }
}
