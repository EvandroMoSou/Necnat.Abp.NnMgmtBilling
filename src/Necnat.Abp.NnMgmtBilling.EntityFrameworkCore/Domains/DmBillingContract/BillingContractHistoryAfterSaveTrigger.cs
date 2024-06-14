using Necnat.Abp.NnLibCommon.Repositories;
using System;
using Volo.Abp.Timing;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class BillingContractHistoryAfterSaveTrigger : HistoryAfterSaveTrigger<BillingContract, BillingContractHistory, Guid, IBillingContractHistoryRepository>
    {
        public BillingContractHistoryAfterSaveTrigger(IHistoryRepository<BillingContractHistory, Guid, BillingContract> historyRepository, IClock clock) : base(historyRepository, clock)
        {
        }
    }
}
