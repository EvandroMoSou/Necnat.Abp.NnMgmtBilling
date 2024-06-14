using Necnat.Abp.NnLibCommon.Enums;
using System.Net.Http;

namespace Necnat.Abp.NnMgmtBilling.Models
{
    public class RequestCountModel
    {
        public string? EndpointDisplayName { get; set; }
        public string? ApplicationName { get; set; }
        public HttpRequestMethod? HttpMethod { get; set; }
        public string? Url { get; set; }
        public int? RequestCount { get; set; }
    }
}
