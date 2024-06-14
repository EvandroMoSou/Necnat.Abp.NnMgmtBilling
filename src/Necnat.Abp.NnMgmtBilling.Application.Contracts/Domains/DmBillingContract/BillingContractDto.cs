using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class BillingContractDto : EntityDto<Guid>
    {
        public virtual Guid? BillingClientId { get; set; }
        public virtual string? Code { get; set; }
        public virtual DateTimeOffset? SkuReferenceTime { get; set; }
        public virtual DateTimeOffset? EffectiveTime { get; set; }
        public virtual Guid? AcceptanceUserId { get; set; }
        public virtual DateTimeOffset? AcceptanceTime { get; set; }
        public virtual bool? IsActive { get; set; }

        public virtual List<Guid>? SkuIdList { get; set; }
    }
}
