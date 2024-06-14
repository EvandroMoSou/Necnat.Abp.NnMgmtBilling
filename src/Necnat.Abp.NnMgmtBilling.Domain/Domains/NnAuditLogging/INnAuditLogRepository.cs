using Necnat.Abp.NnMgmtBilling.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Repositories;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public interface INnAuditLogRepository : IRepository<AuditLog, Guid>
    {
        //Task<List<RequestCountModel>> GetListGroupedRequestCountByClientIdAndExecutionTimeBetweenAsync(string clientId, DateTime executionTimeStart, DateTime executionTimeEnd);
        Task<List<RequestCountModel>> GetListRequestCountByClientIdAndExecutionTimeBetweenAsync(string clientId, DateTime executionTimeStart, DateTime executionTimeEnd);
    }
}
