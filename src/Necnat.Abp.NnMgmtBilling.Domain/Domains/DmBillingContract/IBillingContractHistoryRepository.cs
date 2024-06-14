using Necnat.Abp.NnLibCommon.Repositories;
using System;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public interface IBillingContractHistoryRepository : IHistoryRepository<BillingContractHistory, Guid, BillingContract>
    {

    }
}
