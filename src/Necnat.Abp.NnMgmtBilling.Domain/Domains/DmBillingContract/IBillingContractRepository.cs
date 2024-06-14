using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public interface IBillingContractRepository : IRepository<BillingContract, Guid>
    {
        Task<List<Sku>> CreateSkuAsync(Guid id, List<Guid> lSkuId, bool autosave = false);
    }
}
