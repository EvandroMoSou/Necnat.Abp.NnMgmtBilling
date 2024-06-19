using Microsoft.EntityFrameworkCore;
using Necnat.Abp.NnLibCommon.Repositories;
using Necnat.Abp.NnMgmtBilling.Domains;
using System;

namespace Necnat.Abp.NnMgmtBilling.EntityFrameworkCore
{
    public static class NnMgmtBillingDbContextOptionsBuilderExtensions
    {
        public static void ConfigureNnMgmtBilling(
            this DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseTriggers(triggerOptions =>
            {
                triggerOptions.AddTrigger<TemporalAfterSaveTrigger<BillingContract, BillingContractTemporal, Guid, IBillingContractTemporalRepository>>();
                triggerOptions.AddTrigger<TemporalAfterSaveTrigger<Sku, SkuTemporal, Guid, ISkuTemporalRepository>>();
                triggerOptions.AddTrigger<TemporalAfterSaveTrigger<SkuPriceRange, SkuPriceRangeTemporal, Guid, ISkuPriceRangeTemporalRepository>>();
                triggerOptions.AddTrigger<TemporalAfterSaveTrigger<SkuScope, SkuScopeTemporal, Guid, ISkuScopeTemporalRepository>>();
            });
        }
    }
}
