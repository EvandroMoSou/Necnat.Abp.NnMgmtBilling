using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Necnat.Abp.NnLibCommon.Extensions;
using Necnat.Abp.NnLibCommon.Localization;
using Necnat.Abp.NnLibCommon.Services;
using Necnat.Abp.NnMgmtBilling.Models;
using Necnat.Abp.NnMgmtBilling.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.Users;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class BillingEndpointAppService : NecnatAppService<BillingEndpoint, BillingEndpointDto, Guid, BillingEndpointResultRequestDto, IBillingEndpointRepository>, IBillingEndpointAppService
    {
        protected readonly IBillingClientRepository _billingClientRepository;
        protected readonly ICurrentUser _currentUser;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public BillingEndpointAppService(IStringLocalizer<NnLibCommonResource> necnatLocalizer,
            IBillingEndpointRepository repository,
            IBillingClientRepository billingClientRepository,
            ICurrentUser currentUser,
            IHttpContextAccessor httpContextAccessor) : base(necnatLocalizer, repository)
        {
            _billingClientRepository = billingClientRepository;
            _currentUser = currentUser;
            _httpContextAccessor = httpContextAccessor;

            GetPolicyName = NnMgmtBillingPermissions.PrmBillingEndpoint.Default;
            GetListPolicyName = NnMgmtBillingPermissions.PrmBillingEndpoint.Default;
            CreatePolicyName = NnMgmtBillingPermissions.PrmBillingEndpoint.Create;
            UpdatePolicyName = NnMgmtBillingPermissions.PrmBillingEndpoint.Update;
            DeletePolicyName = NnMgmtBillingPermissions.PrmBillingEndpoint.Delete;
        }

        protected override async Task<IQueryable<BillingEndpoint>> CreateFilteredQueryAsync(BillingEndpointResultRequestDto input)
        {
            ThrowIfIsNotNull(BillingEndpointValidator.Validate(input, _necnatLocalizer));

            var q = await ReadOnlyRepository.GetQueryableAsync();

            if (!string.IsNullOrWhiteSpace(input.DisplayNameContains))
                q = q.Where(x => x.DisplayName.Contains(input.DisplayNameContains));

            if (!string.IsNullOrWhiteSpace(input.EndpointContains))
                q = q.Where(x => x.Endpoint.Contains(input.EndpointContains));

            return q;
        }

        public async Task<List<RequestCountModel>> GetListEndpointApplicationRequestCountModelByClientIdFromEndpointsAsync(string clientId)
        {
            await CheckGetListPolicyAsync();

            if (!await _billingClientRepository.AnyUserIdAndClientIdAsync((Guid)_currentUser.Id!, clientId))
                throw new UnauthorizedAccessException();

            var l = new List<RequestCountModel>();

            var lBillingEndpoint = await Repository.GetListAsync();
            foreach (var iBillingEndpoint in lBillingEndpoint)
            {
                List<RequestCountModel> lBillingRequestCount;
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {await _httpContextAccessor.HttpContext.GetTokenAsync("access_token")}");
                    var httpResponseMessage = await client.PostAsJsonAsync($"{iBillingEndpoint.Endpoint}/api/app/nn-audit-log/request-count-by-client-id-and-execution-time-between", new ClientIdAndExecutionTimeInput { ClientId = clientId, ExecutionTimeStart = DateTime.UtcNow.FirstDayOfMonth(), ExecutionTimeEnd = DateTime.UtcNow.LastDayOfMonth() });
                    lBillingRequestCount = JsonSerializer.Deserialize<List<RequestCountModel>>(await httpResponseMessage.Content.ReadAsStringAsync())!;
                }

                foreach (var iBillingRequestCount in lBillingRequestCount)
                {
                    var billingRequestCount = l
                        .Where(x => x.EndpointDisplayName == iBillingEndpoint.DisplayName
                            && x.ApplicationName == iBillingRequestCount.ApplicationName).FirstOrDefault();

                    if (billingRequestCount != null)
                    {
                        billingRequestCount.RequestCount += iBillingRequestCount.RequestCount;
                        continue;
                    }

                    l.Add(new RequestCountModel
                    {
                        EndpointDisplayName = iBillingEndpoint.DisplayName,
                        ApplicationName = iBillingRequestCount.ApplicationName,
                        RequestCount = iBillingRequestCount.RequestCount
                    });
                }
            }

            return l;
        }

        protected override Task<BillingEndpointDto> CheckCreateInputAsync(BillingEndpointDto input)
        {
            ThrowIfIsNotNull(BillingEndpointValidator.Validate(input, _necnatLocalizer));
            return Task.FromResult(input);
        }

        protected override Task<BillingEndpointDto> CheckUpdateInputAsync(BillingEndpointDto input)
        {
            ThrowIfIsNotNull(BillingEndpointValidator.Validate(input, _necnatLocalizer));
            return Task.FromResult(input);
        }
    }
}
