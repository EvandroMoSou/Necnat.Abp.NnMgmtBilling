using Necnat.Abp.NnLibCommon.Entities;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class Sku : FullAuditedAggregateRoot<Guid>, IGetSetEntity<Guid>
    {
        public new Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public virtual List<SkuScope> SkuScopeList { get; set; } = [];
        public virtual List<SkuPriceRange> SkuPriceRangeList { get; set; } = [];
    }
}
