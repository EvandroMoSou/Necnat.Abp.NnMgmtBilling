using Necnat.Abp.NnLibCommon.Entities;
using Necnat.Abp.NnLibCommon.Enums;
using System;
using System.Text.Json.Serialization;
using Volo.Abp.Domain.Entities.Auditing;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class SkuScope : FullAuditedAggregateRoot<Guid>, IGetSetEntity<Guid>
    {
        public new Guid Id { get; set; }
        public Guid SkuId { get; set; }
        public string ApplicationName { get; set; } = string.Empty;
        public HttpRequestMethod? HttpMethod { get; set; }
        public string? Url { get; set; }
        public bool IsBillable { get; set; }

        [JsonIgnore]
        public Sku Sku { get; set; } = null!;
    }
}
