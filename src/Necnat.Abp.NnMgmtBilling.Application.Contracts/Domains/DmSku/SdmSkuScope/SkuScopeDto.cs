using Necnat.Abp.NnLibCommon.Enums;
using System;
using Volo.Abp.Application.Dtos;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class SkuScopeDto : EntityDto<Guid>
    {
        public Guid? SkuId { get; set; }
        public string? ApplicationName { get; set; }
        public HttpRequestMethod? HttpMethod { get; set; }
        public string? Url { get; set; }
        public bool? IsBillable { get; set; }
    }
}