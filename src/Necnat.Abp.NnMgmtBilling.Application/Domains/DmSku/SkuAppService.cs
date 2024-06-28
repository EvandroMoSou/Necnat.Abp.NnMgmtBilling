using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Necnat.Abp.NnLibCommon.Localization;
using Necnat.Abp.NnLibCommon.Services;
using Necnat.Abp.NnMgmtBilling.Permissions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Users;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class SkuAppService : NecnatAppService<Sku, SkuDto, Guid, SkuResultRequestDto, ISkuRepository>, ISkuAppService
    {
        protected readonly ISkuTemporalRepository _skuTemporalRepository;
        protected readonly ISkuPriceRangeTemporalRepository _skuPriceRangeTemporalRepository;
        protected readonly ISkuPriceRangeRepository _skuPriceRangeRepository;
        protected readonly ISkuScopeTemporalRepository _skuScopeTemporalRepository;
        protected readonly ISkuScopeRepository _skuScopeRepository;

        public SkuAppService(
            ICurrentUser currentUser,
            IStringLocalizer<NnLibCommonResource> necnatLocalizer,
            ISkuRepository repository,
            ISkuTemporalRepository skuTemporalRepository,
            ISkuPriceRangeTemporalRepository skuPriceRangeTemporalRepository,
            ISkuPriceRangeRepository skuPriceRangeRepository,
            ISkuScopeTemporalRepository skuScopeTemporalRepository,
            ISkuScopeRepository skuScopeRepository) : base(currentUser, necnatLocalizer, repository)
        {
            _skuTemporalRepository = skuTemporalRepository;
            _skuPriceRangeTemporalRepository = skuPriceRangeTemporalRepository;
            _skuPriceRangeRepository = skuPriceRangeRepository;
            _skuScopeTemporalRepository = skuScopeTemporalRepository;
            _skuScopeRepository = skuScopeRepository;

            GetPolicyName = NnMgmtBillingPermissions.PrmSku.Default;
            GetListPolicyName = NnMgmtBillingPermissions.PrmSku.Default;
            CreatePolicyName = NnMgmtBillingPermissions.PrmSku.Create;
            UpdatePolicyName = NnMgmtBillingPermissions.PrmSku.Update;
            DeletePolicyName = NnMgmtBillingPermissions.PrmSku.Delete;
        }

        protected override async Task<IQueryable<Sku>> CreateFilteredQueryAsync(SkuResultRequestDto input)
        {
            ThrowIfIsNotNull(SkuValidator.Validate(input, _necnatLocalizer));

            var q = await ReadOnlyRepository.GetQueryableAsync();

            if (input.IdList != null)
                q = q.Where(x => input.IdList.Contains(x.Id));

            if (!string.IsNullOrWhiteSpace(input.NameContains))
                q = q.Where(x => x.Name.Contains(input.NameContains));

            if (input.IsActive != null)
                q = q.Where(x => x.IsActive == input.IsActive);

            return q;
        }

        [HttpPost]
        public async Task<SkuDto> GetTemporalDetailedAsync(DateTimeOffset time, Guid id)
        {
            await CheckGetPolicyAsync();

            var entityTemporal = await _skuTemporalRepository.FindByIdAsync(time.DateTime, id);
            if (entityTemporal == null)
                throw new EntityNotFoundException(typeof(Sku), id);

            entityTemporal.SkuPriceRangeList = await _skuPriceRangeTemporalRepository.GetListBySkuIdAsync(time.DateTime, id);
            entityTemporal.SkuScopeList = await _skuScopeTemporalRepository.GetListBySkuIdAsync(time.DateTime, id);

            return await MapToGetOutputDtoAsync(entityTemporal);
        }

        protected override Task<SkuDto> CheckCreateInputAsync(SkuDto input)
        {
            ThrowIfIsNotNull(SkuValidator.Validate(input, _necnatLocalizer));
            return Task.FromResult(input);
        }

        protected override Task<SkuDto> CheckUpdateInputAsync(SkuDto input)
        {
            ThrowIfIsNotNull(SkuValidator.Validate(input, _necnatLocalizer));
            return Task.FromResult(input);
        }
    }
}
