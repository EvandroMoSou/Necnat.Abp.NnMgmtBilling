using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.OpenIddict.Applications;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public interface IBillingClientRepository : IRepository<BillingClient, Guid>
    {
        Task<bool> AnyUserIdAndClientIdAsync(Guid userId, string clientId);
        Task<List<IdentityUser>> GetUsersAsync(Guid id);
        Task<List<IdentityUser>> CreateUserAsync(Guid id, Guid userId, bool autosave = false);
        Task<List<IdentityUser>> DeleteUserAsync(Guid id, Guid userId, bool autosave = false);
        Task<List<OpenIddictApplication>> GetOpenIddictApplicationsAsync(Guid id);
        Task<List<OpenIddictApplication>> CreateOpenIddictApplicationAsync(Guid id, Guid openIddictApplicationId, bool autosave = false);
        Task<List<OpenIddictApplication>> DeleteOpenIddictApplicationAsync(Guid id, Guid openIddictApplicationId, bool autosave = false);
    }
}