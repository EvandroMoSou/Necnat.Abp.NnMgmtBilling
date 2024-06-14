using Microsoft.EntityFrameworkCore;
using Necnat.Abp.NnMgmtBilling.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class EfCoreBillingContractRepository : EfCoreRepository<NnMgmtBillingDbContext, BillingContract, Guid>, IBillingContractRepository
    {
        protected readonly ISkuHistoryRepository _skuHistoryRepository;
        protected readonly ISkuPriceRangeHistoryRepository _skuPriceRangeHistoryRepository;
        protected readonly ISkuScopeHistoryRepository _skuScopeHistoryRepository;

        public EfCoreBillingContractRepository(
            IDbContextProvider<NnMgmtBillingDbContext> dbContextProvider,
            ISkuHistoryRepository skuHistoryRepository,
            ISkuPriceRangeHistoryRepository skuPriceRangeHistoryRepository,
            ISkuScopeHistoryRepository skuScopeHistoryRepository) : base(dbContextProvider)
        {
            _skuHistoryRepository = skuHistoryRepository;
            _skuPriceRangeHistoryRepository = skuPriceRangeHistoryRepository;
            _skuScopeHistoryRepository = skuScopeHistoryRepository;
        }

        #region Sku

        public async Task<List<Sku>> CreateSkuAsync(Guid id, List<Guid> lSkuId, bool autosave = false)
        {
            var dbContext = await GetDbContextAsync();
            var enity = await dbContext.BillingContract.Where(x => x.Id == id).Include(x => x.SkuList).FirstOrDefaultAsync() ?? throw new EntityNotFoundException(typeof(BillingContract), id);

            enity.SkuList.AddRange(await dbContext.Sku.Where(x => lSkuId.Contains(x.Id)).ToListAsync());

            if (autosave)
                await dbContext.SaveChangesAsync();

            return enity.SkuList;
        }

        #endregion
    }
}
