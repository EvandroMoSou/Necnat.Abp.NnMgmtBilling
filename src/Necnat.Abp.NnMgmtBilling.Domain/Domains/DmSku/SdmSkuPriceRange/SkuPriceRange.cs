using Necnat.Abp.NnLibCommon.Entities;
using System;
using System.Text.Json.Serialization;
using Volo.Abp.Domain.Entities.Auditing;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class SkuPriceRange : FullAuditedAggregateRoot<Guid>, IGetSetEntity<Guid>
    {
        public new Guid Id { get; set; }
        public Guid SkuId { get; set; }
        public int? UpToRequestCount { get; set; }
        public decimal Price { get; set; }

        [JsonIgnore]
        public Sku Sku { get; set; } = null!;
    }
}
