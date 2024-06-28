using Microsoft.Extensions.Localization;
using Necnat.Abp.NnLibCommon.Localization;
using Necnat.Abp.NnLibCommon.Services;
using Necnat.Abp.NnMgmtBilling.Permissions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.OpenIddict.Applications;
using Volo.Abp.Users;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class NnOpenIddictApplicationAppService : NecnatAppService<OpenIddictApplication, NnOpenIddictApplicationDto, Guid, NnOpenIddictApplicationResultRequestDto, INnOpenIddictApplicationRepository>, INnOpenIddictApplicationAppService
    {
        public NnOpenIddictApplicationAppService(
            ICurrentUser currentUser, 
            IStringLocalizer<NnLibCommonResource> necnatLocalizer,
            INnOpenIddictApplicationRepository repository) : base(currentUser, necnatLocalizer, repository)
        {
            GetPolicyName = NnMgmtBillingPermissions.PrmNnOpenIddictApplication.Default;
            GetListPolicyName = NnMgmtBillingPermissions.PrmNnOpenIddictApplication.Default;
            CreatePolicyName = NnMgmtBillingPermissions.PrmNnOpenIddictApplication.Create;
            UpdatePolicyName = NnMgmtBillingPermissions.PrmNnOpenIddictApplication.Update;
            DeletePolicyName = NnMgmtBillingPermissions.PrmNnOpenIddictApplication.Delete;
        }

        protected override async Task<IQueryable<OpenIddictApplication>> CreateFilteredQueryAsync(NnOpenIddictApplicationResultRequestDto input)
        {
            var q = await ReadOnlyRepository.GetQueryableAsync();

            if (input.IdList != null)
                q = q.Where(x => input.IdList.Contains(x.Id));

            if (!string.IsNullOrWhiteSpace(input.ClientIdContains))
                q = q.Where(x => x.ClientId.Contains(input.ClientIdContains));

            if (!string.IsNullOrWhiteSpace(input.ClientIdOrDisplayNameContains))
                q = q.Where(x => x.ClientId.Contains(input.ClientIdOrDisplayNameContains) || x.DisplayName.Contains(input.ClientIdOrDisplayNameContains));

            if (!string.IsNullOrWhiteSpace(input.DisplayNameContains))
                q = q.Where(x => x.DisplayName.Contains(input.DisplayNameContains));

            return q;
        }

        [RemoteService(false)]
        public override Task<NnOpenIddictApplicationDto> CreateAsync(NnOpenIddictApplicationDto input)
        {
            //return base.CreateAsync(input);
            throw new NotImplementedException();
        }

        [RemoteService(false)]
        public override Task<NnOpenIddictApplicationDto> UpdateAsync(Guid id, NnOpenIddictApplicationDto input)
        {
            //return base.UpdateAsync(id, input);
            throw new NotImplementedException();
        }

        [RemoteService(false)]
        public override Task DeleteAsync(Guid id)
        {
            //return base.DeleteAsync(id);
            throw new NotImplementedException();
        }
    }
}
