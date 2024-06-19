using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Necnat.Abp.NnLibCommon.Entities;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class BillingContractTemporal : Entity<Guid>, IEntityTemporal<Guid>, IHasExtraProperties
    {
        public DateTime PeriodStart { get; set; }
        public DateTime? PeriodEnd { get; set; }

        public new Guid Id { get; set; }
        public Guid BillingClientId { get; set; }
        public string Code { get; set; } = string.Empty;
        public DateTime SkuReferenceTime { get; set; }
        public DateTime EffectiveTime { get; set; }
        public Guid? AcceptanceUserId { get; set; }
        public DateTime? AcceptanceTime { get; set; }
        public bool IsActive { get; set; }

        public virtual ExtraPropertyDictionary ExtraProperties { get; set; } = new ExtraPropertyDictionary();
        public virtual string? ConcurrencyStamp { get; set; }
        public virtual DateTime? CreationTime { get; set; }
        public virtual Guid? CreatorId { get; set; }
        public virtual DateTime? LastModificationTime { get; set; }
        public virtual Guid? LastModifierId { get; set; }
    }
}
