using Microsoft.EntityFrameworkCore;
using Necnat.Abp.NnLibCommon.Repositories;
using Necnat.Abp.NnMgmtBilling.Domains;
using System;

namespace Necnat.Abp.NnMgmtBilling.EntityFrameworkCore
{
    public static class NnMgmtBillingDbContextOptionsBuilderExtensions
    {
        public static void ConfigureBillingManagement(
            this DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseTriggers(triggerOptions =>
            {
                triggerOptions.AddTrigger<HistoryAfterSaveTrigger<BillingContract, BillingContractHistory, Guid, IBillingContractHistoryRepository>>();
                triggerOptions.AddTrigger<HistoryAfterSaveTrigger<Sku, SkuHistory, Guid, ISkuHistoryRepository>>();
                triggerOptions.AddTrigger<HistoryAfterSaveTrigger<SkuPriceRange, SkuPriceRangeHistory, Guid, ISkuPriceRangeHistoryRepository>>();
                triggerOptions.AddTrigger<HistoryAfterSaveTrigger<SkuScope, SkuScopeHistory, Guid, ISkuScopeHistoryRepository>>();
            });
        }
    }
}
