using Necnat.Abp.NnLibCommon.Repositories;
using System;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public interface ISkuScopeHistoryRepository : IHistoryRepository<SkuScopeHistory, Guid, SkuScope>
    {

    }
}
