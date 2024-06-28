using Microsoft.Extensions.Localization;
using Necnat.Abp.NnLibCommon.Localization;
using Necnat.Abp.NnLibCommon.Services;
using Necnat.Abp.NnMgmtBilling.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp.OpenIddict.Applications;
using Volo.Abp.Users;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class BillingClientAppService : NecnatAppService<BillingClient, BillingClientDto, Guid, BillingClientResultRequestDto, IBillingClientRepository>, IBillingClientAppService
    {
        public BillingClientAppService(
            ICurrentUser currentUser,
            IStringLocalizer<NnLibCommonResource> necnatLocalizer,
            IBillingClientRepository repository) : base(currentUser, necnatLocalizer, repository)
        {
            GetPolicyName = NnMgmtBillingPermissions.PrmBillingClient.Default;
            GetListPolicyName = NnMgmtBillingPermissions.PrmBillingClient.Default;
            CreatePolicyName = NnMgmtBillingPermissions.PrmBillingClient.Create;
            UpdatePolicyName = NnMgmtBillingPermissions.PrmBillingClient.Update;
            DeletePolicyName = NnMgmtBillingPermissions.PrmBillingClient.Delete;
        }

        protected override async Task<IQueryable<BillingClient>> CreateFilteredQueryAsync(BillingClientResultRequestDto input)
        {
            ThrowIfIsNotNull(BillingClientValidator.Validate(input, _necnatLocalizer));

            var q = await ReadOnlyRepository.GetQueryableAsync();

            if (!string.IsNullOrWhiteSpace(input.NameContains))
                q = q.Where(x => x.Name.Contains(input.NameContains));

            if (input.IsActive != null)
                q = q.Where(x => x.IsActive == input.IsActive);

            return q;
        }

        protected override Task<BillingClientDto> CheckCreateInputAsync(BillingClientDto input)
        {
            ThrowIfIsNotNull(BillingClientValidator.Validate(input, _necnatLocalizer));
            return Task.FromResult(input);
        }

        protected override Task<BillingClientDto> CheckUpdateInputAsync(BillingClientDto input)
        {
            ThrowIfIsNotNull(BillingClientValidator.Validate(input, _necnatLocalizer));
            return Task.FromResult(input);
        }

        #region User

        public async Task<List<IdentityUserDto>> GetUsersAsync(Guid id)
        {
            await CheckGetPolicyAsync();

            var lEntity = await Repository.GetUsersAsync(id);
            return ObjectMapper.Map<List<IdentityUser>, List<IdentityUserDto>>(lEntity);
        }

        public async Task<List<IdentityUserDto>> CreateUserAsync(Guid id, Guid userId)
        {
            await CheckUpdatePolicyAsync();

            var lEntity = await Repository.InsertUserAsync(id, userId);
            return ObjectMapper.Map<List<IdentityUser>, List<IdentityUserDto>>(lEntity);
        }

        public async Task<List<IdentityUserDto>> DeleteUserAsync(Guid id, Guid userId)
        {
            await CheckUpdatePolicyAsync();

            var lEntity = await Repository.DeleteUserAsync(id, userId);
            return ObjectMapper.Map<List<IdentityUser>, List<IdentityUserDto>>(lEntity);
        }

        #endregion

        #region OpenIddictApplication

        public async Task<List<NnOpenIddictApplicationDto>> GetOpenIddictApplicationsAsync(Guid id)
        {
            await CheckGetPolicyAsync();

            var lEntity = await Repository.GetOpenIddictApplicationsAsync(id);
            return ObjectMapper.Map<List<OpenIddictApplication>, List<NnOpenIddictApplicationDto>>(lEntity);
        }

        public async Task<List<NnOpenIddictApplicationDto>> CreateOpenIddictApplicationAsync(Guid id, Guid openIddictApplicationId)
        {
            await CheckUpdatePolicyAsync();

            var lEntity = await Repository.InsertOpenIddictApplicationAsync(id, openIddictApplicationId);
            return ObjectMapper.Map<List<OpenIddictApplication>, List<NnOpenIddictApplicationDto>>(lEntity);
        }

        public async Task<List<NnOpenIddictApplicationDto>> DeleteOpenIddictApplicationAsync(Guid id, Guid openIddictApplicationId)
        {
            await CheckUpdatePolicyAsync();

            var lEntity = await Repository.DeleteOpenIddictApplicationAsync(id, openIddictApplicationId);
            return ObjectMapper.Map<List<OpenIddictApplication>, List<NnOpenIddictApplicationDto>>(lEntity);
        }

        #endregion
    }
}
