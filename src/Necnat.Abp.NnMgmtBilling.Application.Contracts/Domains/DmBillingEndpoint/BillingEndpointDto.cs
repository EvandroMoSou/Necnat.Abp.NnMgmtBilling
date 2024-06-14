using System;
using Volo.Abp.Application.Dtos;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class BillingEndpointDto : EntityDto<Guid>
    {
        public string? DisplayName { get; set; }
        public string? Endpoint { get; set; }
        public bool? IsActive { get; set; }
    }
}
