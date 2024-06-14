using Microsoft.Extensions.Localization;
using Necnat.Abp.NnLibCommon.Validators;
using System;
using System.Collections.Generic;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public static class NnAuditLogValidator
    {
        public static List<string>? Validate(ClientIdAndExecutionTimeInput input, IStringLocalizer stringLocalizer)
        {
            var lError = new List<string>();

            if (string.IsNullOrWhiteSpace(input.ClientId))
                lError.Add(string.Format(stringLocalizer[ValidationMessages.Required], nameof(input.ClientId)));

            if (input.ExecutionTimeStart == null || input.ExecutionTimeStart == default || input.ExecutionTimeStart == DateTime.MinValue)
                lError.Add(string.Format(stringLocalizer[ValidationMessages.Required], nameof(input.ExecutionTimeStart)));

            if (input.ExecutionTimeEnd == null || input.ExecutionTimeEnd == default || input.ExecutionTimeEnd == DateTime.MinValue)
                lError.Add(string.Format(stringLocalizer[ValidationMessages.Required], nameof(input.ExecutionTimeEnd)));

            if (lError.Count > 0)
                return lError;

            return null;
        }
    }
}
