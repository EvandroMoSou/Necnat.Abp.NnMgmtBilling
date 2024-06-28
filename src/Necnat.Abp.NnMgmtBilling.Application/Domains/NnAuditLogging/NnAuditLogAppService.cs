using Microsoft.Extensions.Localization;
using Necnat.Abp.NnLibCommon.Localization;
using Necnat.Abp.NnLibCommon.Services;
using Necnat.Abp.NnMgmtBilling.Models;
using Necnat.Abp.NnMgmtBilling.Permissions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AuditLogging;
using Volo.Abp.Users;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class NnAuditLogAppService : NecnatAppService<AuditLog, NnAuditLogDto, Guid, NnAuditLogResultRequestDto, INnAuditLogRepository>, INnAuditLogAppService
    {
        public NnAuditLogAppService(
            ICurrentUser currentUser, 
            IStringLocalizer<NnLibCommonResource> necnatLocalizer,
            INnAuditLogRepository repository) : base(currentUser, necnatLocalizer, repository)
        {
            GetPolicyName = NnMgmtBillingPermissions.PrmNnAuditLog.Default;
            GetListPolicyName = NnMgmtBillingPermissions.PrmNnAuditLog.Default;
            CreatePolicyName = NnMgmtBillingPermissions.PrmNnAuditLog.Create;
            UpdatePolicyName = NnMgmtBillingPermissions.PrmNnAuditLog.Update;
            DeletePolicyName = NnMgmtBillingPermissions.PrmNnAuditLog.Delete;
        }

        //public async Task<List<RequestCountModel>> GetListGroupedRequestCountByClientIdAndExecutionTimeBetweenAsync(ClientIdAndExecutionTimeInput input)
        //{
        //    await CheckGetListPolicyAsync();
        //    ThrowIfIsNotNull(NnAuditLogValidator.Validate(input, _necnatLocalizer));

        //    return await Repository.GetListGroupedRequestCountByClientIdAndExecutionTimeBetweenAsync(input.ClientId!, (DateTime)input.ExecutionTimeStart!, (DateTime)input.ExecutionTimeEnd!);
        //}

        public async Task<List<RequestCountModel>> GetListRequestCountByClientIdAndExecutionTimeBetweenAsync(ClientIdAndExecutionTimeInput input)
        {
            await CheckGetListPolicyAsync();
            ThrowIfIsNotNull(NnAuditLogValidator.Validate(input, _necnatLocalizer));

            return await Repository.GetListRequestCountByClientIdAndExecutionTimeBetweenAsync(input.ClientId!, (DateTime)input.ExecutionTimeStart!, (DateTime)input.ExecutionTimeEnd!);
        }

        [RemoteService(false)]
        public override Task<PagedResultDto<NnAuditLogDto>> GetListAsync(NnAuditLogResultRequestDto input)
        {
            //return base.GetListAsync(input);
            throw new NotImplementedException();
        }

        [RemoteService(false)]
        public override Task<NnAuditLogDto> CreateAsync(NnAuditLogDto input)
        {
            //return base.CreateAsync(input);
            throw new NotImplementedException();
        }

        [RemoteService(false)]
        public override Task<NnAuditLogDto> UpdateAsync(Guid id, NnAuditLogDto input)
        {
            //return base.UpdateAsync(id, input);
            throw new NotImplementedException();
        }

        [RemoteService(false)]
        public override Task DeleteAsync(Guid id)
        {
            //return base.DeleteAsync(id);
            throw new NotImplementedException();
        }
    }
}
