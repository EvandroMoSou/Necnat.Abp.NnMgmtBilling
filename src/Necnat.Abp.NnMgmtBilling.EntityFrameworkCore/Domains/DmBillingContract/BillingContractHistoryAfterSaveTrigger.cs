using Necnat.Abp.NnLibCommon.Repositories;
using System;
using Volo.Abp.Timing;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class BillingContractTemporalAfterSaveTrigger : TemporalAfterSaveTrigger<BillingContract, BillingContractTemporal, Guid, IBillingContractTemporalRepository>
    {
        public BillingContractTemporalAfterSaveTrigger(ITemporalRepository<BillingContractTemporal, Guid, BillingContract> historyRepository, IClock clock) : base(historyRepository, clock)
        {
        }
    }
}
