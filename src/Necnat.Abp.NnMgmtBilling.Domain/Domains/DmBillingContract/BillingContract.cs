using Necnat.Abp.NnLibCommon.Entities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Volo.Abp.Domain.Entities.Auditing;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class BillingContract : AuditedAggregateRoot<Guid>, IGetSetEntity<Guid>
    {
        public new Guid Id { get; set; }
        public Guid BillingClientId { get; set; }
        public string Code { get; set; } = string.Empty;
        public DateTime SkuReferenceTime { get; set; }
        public DateTime EffectiveTime { get; set; }
        public Guid? AcceptanceUserId { get; set; }
        public DateTime? AcceptanceTime { get; set; }
        public bool IsActive { get; set; }

        [JsonIgnore]
        public BillingClient BillingClient { get; set; } = null!;
        public virtual List<Sku> SkuList { get; set; } = [];
    }
}