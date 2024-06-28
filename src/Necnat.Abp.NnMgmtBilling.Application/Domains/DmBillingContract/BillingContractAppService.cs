using Microsoft.Extensions.Localization;
using Necnat.Abp.NnLibCommon.Localization;
using Necnat.Abp.NnLibCommon.Services;
using Necnat.Abp.NnMgmtBilling.Permissions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Users;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class BillingContractAppService : NecnatAppService<BillingContract, BillingContractDto, Guid, BillingContractResultRequestDto, IBillingContractRepository>, IBillingContractAppService
    {
        public BillingContractAppService(
            ICurrentUser currentUser,
            IStringLocalizer<NnLibCommonResource> necnatLocalizer,
            IBillingContractRepository repository) : base(currentUser, necnatLocalizer, repository)
        {
            GetPolicyName = NnMgmtBillingPermissions.PrmBillingContract.Default;
            GetListPolicyName = NnMgmtBillingPermissions.PrmBillingContract.Default;
            CreatePolicyName = NnMgmtBillingPermissions.PrmBillingContract.Create;
            UpdatePolicyName = NnMgmtBillingPermissions.PrmBillingContract.Update;
            DeletePolicyName = NnMgmtBillingPermissions.PrmBillingContract.Delete;
        }

        protected override async Task<IQueryable<BillingContract>> CreateFilteredQueryAsync(BillingContractResultRequestDto input)
        {
            ThrowIfIsNotNull(BillingContractValidator.Validate(input, _necnatLocalizer));

            var q = await ReadOnlyRepository.GetQueryableAsync();

            if (input.BillingClientId != null)
                q = q.Where(x => x.BillingClientId == input.BillingClientId);

            if (!string.IsNullOrWhiteSpace(input.CodeContains))
                q = q.Where(x => x.Code.Contains(input.CodeContains));

            if (input.EffectiveTime != null)
                q = q.Where(x => x.EffectiveTime == input.EffectiveTime);

            if (input.IsActive != null)
                q = q.Where(x => x.IsActive == input.IsActive);

            return q;
        }

        #region Create

        protected override Task<BillingContractDto> CheckCreateInputAsync(BillingContractDto input)
        {
            ThrowIfIsNotNull(BillingContractValidator.Validate(input, _necnatLocalizer));

            if (input.AcceptanceUserId != null || input.AcceptanceTime != null)
                throw new UserFriendlyException(L["A contract cannot be created with acceptance data filled in."]);

            return Task.FromResult(input);
        }

        protected override async Task<BillingContract> CheckCreateInsertedEntityAsync(BillingContract insertedEntity, BillingContractDto? input = null)
        {
            if(input != null && input.SkuIdList != null && input.SkuIdList.Count > 0)
            {
                var lSku = await Repository.CreateSkuAsync(insertedEntity.Id, input.SkuIdList);
                insertedEntity.SkuList = lSku;
            }

            return insertedEntity;
        }

        #endregion

        #region Update

        protected override Task<BillingContractDto> CheckUpdateInputAsync(BillingContractDto input)
        {
            ThrowIfIsNotNull(BillingContractValidator.Validate(input, _necnatLocalizer));
            if (input.SkuIdList != null)
                throw new UserFriendlyException(L["A contract that has already been created cannot change its skus. Send and empty list."]);

            return Task.FromResult(input);
        }

        protected override Task<BillingContract> CheckUpdateDbEntityAsync(BillingContract dbEntity, BillingContractDto? input = null)
        {
            if (dbEntity.AcceptanceUserId != null || dbEntity.AcceptanceTime != null)
                throw new UserFriendlyException(L["A contract that has already been accepted cannot be changed. Please create a new contract."]);

            return Task.FromResult(dbEntity);
        }

        #endregion

        #region Delete

        protected override Task<BillingContract> CheckDeleteDbEntityAsync(BillingContract dbEntity)
        {
            if (dbEntity.AcceptanceUserId != null || dbEntity.AcceptanceTime != null)
                throw new UserFriendlyException(L["A contract that has already been accepted cannot be deleted."]);

            return Task.FromResult(dbEntity);
        }

        #endregion
    }
}