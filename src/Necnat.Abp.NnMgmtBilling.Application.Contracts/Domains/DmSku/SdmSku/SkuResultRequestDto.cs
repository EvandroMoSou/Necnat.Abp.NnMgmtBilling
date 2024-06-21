using Necnat.Abp.NnLibCommon.Dtos;
using System;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class SkuResultRequestDto : IdListOptionalPagedAndSortedResultRequestDto<Guid>
    {
        public string? NameContains { get; set; }
        public bool? IsActive { get; set; }
    }
}
