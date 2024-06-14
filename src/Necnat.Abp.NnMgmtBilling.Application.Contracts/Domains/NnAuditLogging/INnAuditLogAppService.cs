using Necnat.Abp.NnMgmtBilling.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public interface INnAuditLogAppService :
        ICrudAppService<
            NnAuditLogDto,
            Guid,
            NnAuditLogResultRequestDto>
    {
        //Task<List<RequestCountModel>> GetListGroupedRequestCountByClientIdAndExecutionTimeBetweenAsync(ClientIdAndExecutionTimeInput input);
        Task<List<RequestCountModel>> GetListRequestCountByClientIdAndExecutionTimeBetweenAsync(ClientIdAndExecutionTimeInput input);        
    }
}
