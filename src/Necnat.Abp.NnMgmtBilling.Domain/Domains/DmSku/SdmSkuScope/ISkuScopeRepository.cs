using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public interface ISkuScopeRepository : IRepository<SkuScope, Guid>
    {
        Task<List<SkuScope>> GetListBySkuIdAsync(Guid skuId);
    }
}
