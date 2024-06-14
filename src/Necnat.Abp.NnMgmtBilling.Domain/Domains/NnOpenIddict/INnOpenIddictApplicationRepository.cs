using System;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.OpenIddict.Applications;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public interface INnOpenIddictApplicationRepository : IRepository<OpenIddictApplication, Guid>
    {

    }
}