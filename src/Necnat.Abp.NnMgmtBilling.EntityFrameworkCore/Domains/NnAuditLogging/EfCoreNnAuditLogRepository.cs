using Microsoft.EntityFrameworkCore;
using Necnat.Abp.NnLibCommon.Enums;
using Necnat.Abp.NnMgmtBilling.EntityFrameworkCore;
using Necnat.Abp.NnMgmtBilling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class EfCoreNnAuditLogRepository : EfCoreRepository<NnMgmtBillingDbContext, AuditLog, Guid>, INnAuditLogRepository
    {
        public EfCoreNnAuditLogRepository(IDbContextProvider<NnMgmtBillingDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        //public async Task<List<RequestCountModel>> GetListGroupedRequestCountByClientIdAndExecutionTimeBetweenAsync(string clientId, DateTime executionTimeStart, DateTime executionTimeEnd)
        //{
        //    var dbSet = await GetDbSetAsync();
        //    var q = dbSet
        //        .Where(x => x.ClientId == clientId
        //        && x.ExecutionTime >= executionTimeStart
        //        && x.ExecutionTime <= executionTimeEnd
        //        && x.HttpStatusCode < 500);

        //    return await q.GroupBy(x => x.ApplicationName).Select(x => new RequestCountModel { ApplicationName = x.Key, RequestCount = x.Count() }).ToListAsync();
        //}

        public async Task<List<RequestCountModel>> GetListRequestCountByClientIdAndExecutionTimeBetweenAsync(string clientId, DateTime executionTimeStart, DateTime executionTimeEnd)
        {
            var dbSet = await GetDbSetAsync();
            var q = dbSet
                .Where(x => x.ClientId == clientId
                && x.ExecutionTime >= executionTimeStart
                && x.ExecutionTime <= executionTimeEnd
                && x.HttpStatusCode < 500);

            return await q.GroupBy(x => new { x.ApplicationName, x.HttpMethod, x.Url }).Select(x => new RequestCountModel
            {
                ApplicationName = x.Key.ApplicationName,
                HttpMethod = (HttpRequestMethod)int.Parse(x.Key.HttpMethod),
                Url = x.Key.Url,
                RequestCount = x.Count()
            }).ToListAsync();
        }
    }
}
