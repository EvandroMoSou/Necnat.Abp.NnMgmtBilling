using Microsoft.Extensions.Localization;
using Necnat.Abp.NnLibCommon.Localization;
using Necnat.Abp.NnLibCommon.Services;
using Necnat.Abp.NnMgmtBilling.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Users;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class SkuScopeAppService : NecnatAppService<SkuScope, SkuScopeDto, Guid, SkuScopeResultRequestDto, ISkuScopeRepository>, ISkuScopeAppService
    {
        public SkuScopeAppService(
            ICurrentUser currentUser,
            IStringLocalizer<NnLibCommonResource> necnatLocalizer,
            ISkuScopeRepository repository) : base(currentUser, necnatLocalizer, repository)
        {
        }

        protected override async Task<IQueryable<SkuScope>> CreateFilteredQueryAsync(SkuScopeResultRequestDto input)
        {
            ThrowIfIsNotNull(SkuScopeValidator.Validate(input, _necnatLocalizer));

            var q = await ReadOnlyRepository.GetQueryableAsync();

            if (input.IdList != null)
                q = q.Where(x => input.IdList.Contains(x.Id));

            if (input.SkuId != null)
                q = q.Where(x => x.SkuId == input.SkuId);

            if (!string.IsNullOrWhiteSpace(input.ApplicationNameContains))
                q = q.Where(x => x.ApplicationName.Contains(input.ApplicationNameContains));

            if (input.HttpMethod != null)
                q = q.Where(x => x.HttpMethod != null && x.HttpMethod == input.HttpMethod);

            if (!string.IsNullOrWhiteSpace(input.UrlContains))
                q = q.Where(x => x.Url != null && x.Url.Contains(input.UrlContains));

            if (input.IsBillable != null)
                q = q.Where(x => x.IsBillable == input.IsBillable);

            return q;
        }

        public async Task<List<SkuScopeDto>> GetListBySkuIdAsync(Guid skuId)
        {
            var lEntity = await Repository.GetListBySkuIdAsync(skuId);
            return ObjectMapper.Map<List<SkuScope>, List<SkuScopeDto>>(lEntity);
        }

        protected override Task<SkuScopeDto> CheckCreateInputAsync(SkuScopeDto input)
        {
            ThrowIfIsNotNull(SkuScopeValidator.Validate(input, _necnatLocalizer));
            return Task.FromResult(input);
        }

        protected override Task<SkuScopeDto> CheckUpdateInputAsync(SkuScopeDto input)
        {
            ThrowIfIsNotNull(SkuScopeValidator.Validate(input, _necnatLocalizer));
            return Task.FromResult(input);
        }
    }
}
