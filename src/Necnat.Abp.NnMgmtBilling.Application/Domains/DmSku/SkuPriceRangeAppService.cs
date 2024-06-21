using Microsoft.Extensions.Localization;
using Necnat.Abp.NnLibCommon.Localization;
using Necnat.Abp.NnLibCommon.Services;
using Necnat.Abp.NnMgmtBilling.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class SkuPriceRangeAppService : NecnatAppService<SkuPriceRange, SkuPriceRangeDto, Guid, SkuPriceRangeResultRequestDto, ISkuPriceRangeRepository>, ISkuPriceRangeAppService
    {
        public SkuPriceRangeAppService(IStringLocalizer<NnLibCommonResource> necnatLocalizer,
            ISkuPriceRangeRepository repository) : base(necnatLocalizer, repository)
        {
            GetPolicyName = NnMgmtBillingPermissions.PrmSkuPriceRange.Default;
            GetListPolicyName = NnMgmtBillingPermissions.PrmSkuPriceRange.Default;
            CreatePolicyName = NnMgmtBillingPermissions.PrmSkuPriceRange.Create;
            UpdatePolicyName = NnMgmtBillingPermissions.PrmSkuPriceRange.Update;
            DeletePolicyName = NnMgmtBillingPermissions.PrmSkuPriceRange.Delete;
        }

        protected override async Task<IQueryable<SkuPriceRange>> CreateFilteredQueryAsync(SkuPriceRangeResultRequestDto input)
        {
            ThrowIfIsNotNull(SkuPriceRangeValidator.Validate(input, _necnatLocalizer));

            var q = await ReadOnlyRepository.GetQueryableAsync();

            if (input.IdList != null)
                q = q.Where(x => input.IdList.Contains(x.Id));

            if (input.SkuId != null)
                q = q.Where(x => x.SkuId == input.SkuId);

            if (input.UpToRequestCount != null)
                q = q.Where(x => x.UpToRequestCount == input.UpToRequestCount);

            if (input.Price != null)
                q = q.Where(x => x.Price == input.Price);

            return q;
        }

        public async Task<List<SkuPriceRangeDto>> GetListBySkuIdAsync(Guid skuId)
        {
            var lEntity = await Repository.GetListBySkuIdAsync(skuId);
            return ObjectMapper.Map<List<SkuPriceRange>, List<SkuPriceRangeDto>>(lEntity);
        }

        protected override Task<SkuPriceRangeDto> CheckCreateInputAsync(SkuPriceRangeDto input)
        {
            ThrowIfIsNotNull(SkuPriceRangeValidator.Validate(input, _necnatLocalizer));
            return Task.FromResult(input);
        }

        protected override Task<SkuPriceRangeDto> CheckUpdateInputAsync(SkuPriceRangeDto input)
        {
            ThrowIfIsNotNull(SkuPriceRangeValidator.Validate(input, _necnatLocalizer));
            return Task.FromResult(input);
        }
    }
}
