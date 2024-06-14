using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public interface ISkuAppService :
        ICrudAppService<
            SkuDto,
            Guid,
            SkuResultRequestDto>
    {
        Task<SkuDto> GetHistoryDetailedAsync(DateTime time, Guid id);
    }
}