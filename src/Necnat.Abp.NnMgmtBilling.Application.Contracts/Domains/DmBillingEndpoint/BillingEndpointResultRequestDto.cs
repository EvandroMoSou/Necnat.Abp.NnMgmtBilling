using Necnat.Abp.NnLibCommon.Dtos;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class BillingEndpointResultRequestDto : OptionalPagedAndSortedResultRequestDto
    {
        public string? DisplayNameContains { get; set; }
        public string? EndpointContains { get; set; }
        public bool? IsActive { get; set; }
    }
}
