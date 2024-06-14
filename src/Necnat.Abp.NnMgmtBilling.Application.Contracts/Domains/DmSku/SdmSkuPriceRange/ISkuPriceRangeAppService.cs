using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public interface ISkuPriceRangeAppService :
        ICrudAppService<
            SkuPriceRangeDto,
            Guid,
            SkuPriceRangeResultRequestDto>
    {
        Task<List<SkuPriceRangeDto>> GetListBySkuIdAsync(Guid skuId);
    }
}
