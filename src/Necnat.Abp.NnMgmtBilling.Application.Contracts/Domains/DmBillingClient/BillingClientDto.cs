using System;
using Volo.Abp.Application.Dtos;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class BillingClientDto : EntityDto<Guid>
    {
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
    }
}
