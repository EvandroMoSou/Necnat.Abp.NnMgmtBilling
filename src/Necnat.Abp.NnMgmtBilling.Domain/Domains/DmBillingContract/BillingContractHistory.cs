using Necnat.Abp.NnLibCommon.Entities;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class BillingContractHistory : Entity<Guid>, IEntityHistory<Guid>, IHasExtraProperties
    {
        public virtual Guid BaseId { get; set; }
        public virtual int ChangeType { get; set; }
        public virtual DateTime ChangeTime { get; set; }

        public Guid? BillingClientId { get; set; }
        public string? Code { get; set; } = string.Empty;
        public DateTime? EffectiveTime { get; set; }
        public Guid? AcceptanceUserId { get; set; }
        public DateTime? AcceptanceTime { get; set; }
        public bool? IsActive { get; set; }

        public virtual ExtraPropertyDictionary ExtraProperties { get; set; } = new ExtraPropertyDictionary();
        public virtual string? ConcurrencyStamp { get; set; }
        public virtual DateTime? CreationTime { get; set; }
        public virtual Guid? CreatorId { get; set; }
        public virtual DateTime? LastModificationTime { get; set; }
        public virtual Guid? LastModifierId { get; set; }
    }
}
