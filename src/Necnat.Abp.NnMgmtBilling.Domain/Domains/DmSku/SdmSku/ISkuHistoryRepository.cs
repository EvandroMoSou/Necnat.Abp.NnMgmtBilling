using Necnat.Abp.NnLibCommon.Repositories;
using System;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public interface ISkuHistoryRepository : IHistoryRepository<SkuHistory, Guid, Sku>
    {

    }
}
