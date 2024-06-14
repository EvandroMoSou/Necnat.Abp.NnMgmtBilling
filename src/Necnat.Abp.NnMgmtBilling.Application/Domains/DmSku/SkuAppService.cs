using Microsoft.Extensions.Localization;
using Necnat.Abp.NnLibCommon.Localization;
using Necnat.Abp.NnLibCommon.Services;
using Necnat.Abp.NnMgmtBilling.Permissions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class SkuAppService : NecnatAppService<Sku, SkuDto, Guid, SkuResultRequestDto, ISkuRepository>, ISkuAppService
    {
        protected readonly ISkuHistoryRepository _skuHistoryRepository;
        protected readonly ISkuPriceRangeHistoryRepository _skuPriceRangeHistoryRepository;
        protected readonly ISkuPriceRangeRepository _skuPriceRangeRepository;
        protected readonly ISkuScopeHistoryRepository _skuScopeHistoryRepository;
        protected readonly ISkuScopeRepository _skuScopeRepository;

        public SkuAppService(
            IStringLocalizer<NnLibCommonResource> necnatLocalizer,
            ISkuRepository repository,
            ISkuHistoryRepository skuHistoryRepository,
            ISkuPriceRangeHistoryRepository skuPriceRangeHistoryRepository,
            ISkuPriceRangeRepository skuPriceRangeRepository,
            ISkuScopeHistoryRepository skuScopeHistoryRepository,
            ISkuScopeRepository skuScopeRepository) : base(necnatLocalizer, repository)
        {
            _skuHistoryRepository = skuHistoryRepository;
            _skuPriceRangeHistoryRepository = skuPriceRangeHistoryRepository;
            _skuPriceRangeRepository = skuPriceRangeRepository;
            _skuScopeHistoryRepository = skuScopeHistoryRepository;
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

            if (!string.IsNullOrWhiteSpace(input.NameContains))
                q = q.Where(x => x.Name.Contains(input.NameContains));

            if (input.IsActive != null)
                q = q.Where(x => x.IsActive == input.IsActive);

            return q;
        }

        public async Task<SkuDto> GetHistoryDetailedAsync(DateTime time, Guid id)
        {
            await CheckGetPolicyAsync();

            var entityHistory = await _skuHistoryRepository.FindEntityAsync(time, id);
            if (entityHistory == null)
                throw new EntityNotFoundException(typeof(Sku), id);

            entityHistory.SkuPriceRangeList = await _skuPriceRangeHistoryRepository.GetListEntityAsync(time, entityHistory.SkuPriceRangeList.Select(x => x.Id).ToList());
            entityHistory.SkuScopeList = await _skuScopeHistoryRepository.GetListEntityAsync(time, entityHistory.SkuScopeList.Select(x => x.Id).ToList());

            return await MapToGetOutputDtoAsync(entityHistory);
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
