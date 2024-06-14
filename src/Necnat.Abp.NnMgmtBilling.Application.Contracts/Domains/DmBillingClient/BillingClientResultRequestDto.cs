using Necnat.Abp.NnLibCommon.Dtos;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class BillingClientResultRequestDto : OptionalPagedAndSortedResultRequestDto
    {
        public string? NameContains { get; set; }
        public bool? IsActive { get; set; }
    }
}
