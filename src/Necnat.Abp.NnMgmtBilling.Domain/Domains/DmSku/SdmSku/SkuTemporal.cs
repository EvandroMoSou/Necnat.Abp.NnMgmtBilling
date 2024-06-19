using Necnat.Abp.NnLibCommon.Entities;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class SkuTemporal : Entity<Guid>, IEntityTemporal<Guid>, IHasExtraProperties
    {
        public DateTime PeriodStart { get; set; }
        public DateTime? PeriodEnd { get; set; }

        public new Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public virtual ExtraPropertyDictionary ExtraProperties { get; set; } = new ExtraPropertyDictionary();
        public virtual string? ConcurrencyStamp { get; set; }
        public virtual DateTime? CreationTime { get; set; }
        public virtual Guid? CreatorId { get; set; }
        public virtual DateTime? LastModificationTime { get; set; }
        public virtual Guid? LastModifierId { get; set; }
        public virtual bool? IsDeleted { get; set; }
        public virtual Guid? DeleterId { get; set; }
        public virtual DateTime? DeletionTime { get; set; }
    }
}
