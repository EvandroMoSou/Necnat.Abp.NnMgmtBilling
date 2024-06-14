using Necnat.Abp.NnLibCommon.Dtos;
using System;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class BillingContractResultRequestDto : OptionalPagedAndSortedResultRequestDto
    {
        public Guid? BillingClientId { get; set; }
        public string? CodeContains { get; set; }
        public DateTimeOffset? EffectiveTime { get; set; }
        public bool? IsActive { get; set; }
    }
}
