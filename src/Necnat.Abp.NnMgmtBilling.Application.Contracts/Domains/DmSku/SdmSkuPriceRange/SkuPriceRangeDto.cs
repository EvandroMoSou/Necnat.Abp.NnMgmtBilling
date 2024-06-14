using System;
using Volo.Abp.Application.Dtos;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class SkuPriceRangeDto : EntityDto<Guid>
    {
        public Guid? SkuId { get; set; }
        public int? UpToRequestCount { get; set; }
        public decimal? Price { get; set; }    
    }
}
