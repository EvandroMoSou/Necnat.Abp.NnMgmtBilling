using Necnat.Abp.NnLibCommon.Dtos;
using Necnat.Abp.NnLibCommon.Enums;
using System;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class SkuScopeResultRequestDto : OptionalPagedAndSortedResultRequestDto
    {
        public Guid? SkuId { get; set; }
        public string? ApplicationNameContains { get; set; }
        public HttpRequestMethod? HttpMethod { get; set; }
        public string? UrlContains { get; set; }
        public bool? IsBillable { get; set; }
        public bool? IsActive { get; set; }
    }
}
