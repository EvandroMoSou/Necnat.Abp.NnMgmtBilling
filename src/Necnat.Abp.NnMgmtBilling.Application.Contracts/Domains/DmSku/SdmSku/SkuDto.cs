using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class SkuDto : EntityDto<Guid>
    {
        public string? Name { get; set; }
        public bool? IsActive { get; set; }

        public List<SkuPriceRangeDto>? SkuPriceRangeList { get; set; }
        public List<SkuScopeDto>? SkuScopeList { get; set; }
    }
}
