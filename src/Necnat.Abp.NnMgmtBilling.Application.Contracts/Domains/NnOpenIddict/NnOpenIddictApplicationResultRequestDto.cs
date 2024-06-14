using Necnat.Abp.NnLibCommon.Dtos;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class NnOpenIddictApplicationResultRequestDto : OptionalPagedAndSortedResultRequestDto
    {
        public string? ClientIdContains { get; set; }
        public string? ClientIdOrDisplayNameContains { get; set; }
        public string? DisplayNameContains { get; set; }
    }
}
