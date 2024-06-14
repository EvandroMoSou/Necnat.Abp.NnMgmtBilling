using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public interface ISkuScopeAppService :
        ICrudAppService<
            SkuScopeDto,
            Guid,
            SkuScopeResultRequestDto>
    {
        Task<List<SkuScopeDto>> GetListBySkuIdAsync(Guid skuId);
    }
}
