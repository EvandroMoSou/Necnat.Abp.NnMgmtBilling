using System;
using Volo.Abp.Domain.Repositories;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public interface IBillingEndpointRepository : IRepository<BillingEndpoint, Guid>
    {

    }
}
