using Necnat.Abp.NnLibCommon.Dtos;
using System;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class NnOpenIddictApplicationResultRequestDto : IdListOptionalPagedAndSortedResultRequestDto<Guid>
    {
        public string? ClientIdContains { get; set; }
        public string? ClientIdOrDisplayNameContains { get; set; }
        public string? DisplayNameContains { get; set; }
    }
}
