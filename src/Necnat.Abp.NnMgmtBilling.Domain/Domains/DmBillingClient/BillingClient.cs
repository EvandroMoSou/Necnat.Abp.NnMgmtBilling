using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.OpenIddict.Applications;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class BillingClient : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public virtual List<IdentityUser> IdentityUserList { get; set; } = [];
        public virtual List<OpenIddictApplication> OpenIddictApplicationList { get; set; } = [];
        public virtual List<BillingContract> BillingContractList { get; set; } = [];
    }
}
