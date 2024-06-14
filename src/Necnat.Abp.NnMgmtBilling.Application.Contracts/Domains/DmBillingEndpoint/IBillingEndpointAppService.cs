using Necnat.Abp.NnMgmtBilling.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public interface IBillingEndpointAppService :
        ICrudAppService<
            BillingEndpointDto,
            Guid,
            BillingEndpointResultRequestDto>
    {
        Task<List<RequestCountModel>> GetListEndpointApplicationRequestCountModelByClientIdFromEndpointsAsync(string clientId);
    }
}
