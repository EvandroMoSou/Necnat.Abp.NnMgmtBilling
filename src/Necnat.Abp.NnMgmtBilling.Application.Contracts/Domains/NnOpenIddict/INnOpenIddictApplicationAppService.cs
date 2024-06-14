using System;
using Volo.Abp.Application.Services;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public interface INnOpenIddictApplicationAppService :
        ICrudAppService<
            NnOpenIddictApplicationDto,
            Guid,
            NnOpenIddictApplicationResultRequestDto>
    {

    }
}
