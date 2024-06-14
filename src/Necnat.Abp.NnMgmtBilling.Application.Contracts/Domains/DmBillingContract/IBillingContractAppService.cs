using System;
using Volo.Abp.Application.Services;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public interface IBillingContractAppService :
        ICrudAppService<
            BillingContractDto,
            Guid,
            BillingContractResultRequestDto>
    {

    }
}
