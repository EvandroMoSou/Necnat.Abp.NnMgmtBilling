using Microsoft.Extensions.Localization;
using Necnat.Abp.NnLibCommon.Extensions;
using Necnat.Abp.NnLibCommon.Validators;
using System.Collections.Generic;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public static class BillingEndpointValidator
    {
        public static List<string>? Validate(BillingEndpointDto dto, IStringLocalizer stringLocalizer)
        {
            var lError = new List<string>();

            lError.AddIfNotIsNullOrWhiteSpace(ValidateDisplayName(dto.DisplayName, stringLocalizer));
            lError.AddIfNotIsNullOrWhiteSpace(ValidateEndpoint(dto.Endpoint, stringLocalizer));

            if (lError.Count > 0)
                return lError;

            return null;
        }

        public static string? ValidateDisplayName(string? value, IStringLocalizer stringLocalizer)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Format(stringLocalizer[ValidationMessages.Required], BillingEndpointConsts.DisplayNameDisplay);

            if (value!.Length > BillingEndpointConsts.MaxDisplayNameLength)
                return string.Format(stringLocalizer[ValidationMessages.MaxLength], BillingEndpointConsts.DisplayNameDisplay, BillingEndpointConsts.MaxDisplayNameLength);

            return null;
        }

        public static string? ValidateEndpoint(string? value, IStringLocalizer stringLocalizer)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Format(stringLocalizer[ValidationMessages.Required], BillingEndpointConsts.EndpointDisplay);

            if (value!.Length > BillingEndpointConsts.MaxEndpointLength)
                return string.Format(stringLocalizer[ValidationMessages.MaxLength], BillingEndpointConsts.EndpointDisplay, BillingEndpointConsts.MaxEndpointLength);

            return null;
        }

        public static string? ValidateIsActive(bool? value, IStringLocalizer stringLocalizer)
        {
            if (value == null)
                return string.Format(stringLocalizer[ValidationMessages.Required], BillingEndpointConsts.IsActiveDisplay);

            return null;
        }

        public static List<string>? Validate(BillingEndpointResultRequestDto resultRequestDto, IStringLocalizer stringLocalizer)
        {
            var lError = new List<string>();

            if (lError.Count > 0)
                return lError;

            return null;
        }
    }
}
