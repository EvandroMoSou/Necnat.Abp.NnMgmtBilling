using Necnat.Abp.NnLibCommon.Dtos;
using System;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class SkuPriceRangeResultRequestDto : IdListOptionalPagedAndSortedResultRequestDto<Guid>
    {
        public Guid? SkuId { get; set; }
        public int? UpToRequestCount { get; set; }
        public decimal? Price { get; set; }
        public bool? IsActive { get; set; }
    }
}
