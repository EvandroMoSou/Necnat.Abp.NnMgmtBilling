using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public interface IBillingClientAppService :
        ICrudAppService<
            BillingClientDto,
            Guid,
            BillingClientResultRequestDto>
    {
        Task<List<IdentityUserDto>> GetUsersAsync(Guid id);
        Task<List<IdentityUserDto>> CreateUserAsync(Guid id, Guid userId);
        Task<List<IdentityUserDto>> DeleteUserAsync(Guid id, Guid userId);
        Task<List<NnOpenIddictApplicationDto>> GetOpenIddictApplicationsAsync(Guid id);
        Task<List<NnOpenIddictApplicationDto>> CreateOpenIddictApplicationAsync(Guid id, Guid openIddictApplicationId);
        Task<List<NnOpenIddictApplicationDto>> DeleteOpenIddictApplicationAsync(Guid id, Guid openIddictApplicationId);
    }
}
