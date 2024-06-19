using Necnat.Abp.NnLibCommon.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public interface ISkuScopeTemporalRepository : ITemporalRepository<SkuScopeTemporal, Guid, SkuScope>
    {
        Task<List<SkuScope>> GetListEntityBySkuIdAsync(DateTime changeTimeDesc, Guid skuId);
    }
}
