using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public interface ISkuPriceRangeRepository : IRepository<SkuPriceRange, Guid>
    {
        Task<List<SkuPriceRange>> GetListBySkuIdAsync(Guid skuId);
    }
}
