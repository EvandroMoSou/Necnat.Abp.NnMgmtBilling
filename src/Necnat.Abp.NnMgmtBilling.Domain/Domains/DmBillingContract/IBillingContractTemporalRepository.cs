using Necnat.Abp.NnLibCommon.Repositories;
using System;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public interface IBillingContractTemporalRepository : ITemporalRepository<BillingContractTemporal, Guid, BillingContract>
    {

    }
}
