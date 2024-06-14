using Microsoft.Extensions.Localization;
using Necnat.Abp.NnLibCommon.Enums;
using Necnat.Abp.NnLibCommon.Extensions;
using Necnat.Abp.NnLibCommon.Validators;
using System;
using System.Collections.Generic;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public static class SkuScopeValidator
    {
        public static List<string>? Validate(SkuScopeDto dto, IStringLocalizer stringLocalizer)
        {
            var lError = new List<string>();

            lError.AddIfNotIsNullOrWhiteSpace(ValidateSkuId(dto.SkuId, stringLocalizer));
            lError.AddIfNotIsNullOrWhiteSpace(ValidateApplicationName(dto.ApplicationName, stringLocalizer));
            lError.AddIfNotIsNullOrWhiteSpace(ValidateUrl(dto.Url, stringLocalizer));
            lError.AddIfNotIsNullOrWhiteSpace(ValidateHttpMethodAndUrl(dto.HttpMethod, dto.Url, stringLocalizer));
            lError.AddIfNotIsNullOrWhiteSpace(ValidateIsBillable(dto.IsBillable, stringLocalizer));

            if (lError.Count > 0)
                return lError;

            return null;
        }

        public static string? ValidateSkuId(Guid? value, IStringLocalizer stringLocalizer)
        {
            if (value == null || value == default)
                return string.Format(stringLocalizer[ValidationMessages.Required], SkuPriceRangeConsts.SkuIdDisplay);

            return null;
        }

        public static string? ValidateApplicationName(string? value, IStringLocalizer stringLocalizer)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Format(stringLocalizer[ValidationMessages.Required], SkuScopeConsts.ApplicationNameDisplay);

            if (value!.Length > SkuScopeConsts.MaxApplicationNameLength)
                return string.Format(stringLocalizer[ValidationMessages.MaxLength], SkuScopeConsts.ApplicationNameDisplay, SkuScopeConsts.MaxApplicationNameLength);

            return null;
        }

        public static string? ValidateUrl(string? value, IStringLocalizer stringLocalizer)
        {
            if (value == null)
                return null;

            if (value!.Length > SkuScopeConsts.MaxUrlLength)
                return string.Format(stringLocalizer[ValidationMessages.MaxLength], SkuScopeConsts.UrlDisplay, SkuScopeConsts.MaxUrlLength);

            return null;
        }

        public static string? ValidateHttpMethodAndUrl(HttpRequestMethod? httpMethodValue, string? urlValue, IStringLocalizer stringLocalizer)
        {
            if (httpMethodValue != null && string.IsNullOrWhiteSpace(urlValue))
                return string.Format(stringLocalizer[ValidationMessages.OneFilledTwoRequired], SkuScopeConsts.HttpMethodDisplay, SkuScopeConsts.UrlDisplay);

            return null;
        }

        public static string? ValidateIsBillable(bool? value, IStringLocalizer stringLocalizer)
        {
            if (value == null)
                return string.Format(stringLocalizer[ValidationMessages.Required], SkuScopeConsts.IsBillableDisplay);

            return null;
        }

        #region ResultRequestDto

        public static List<string>? Validate(SkuScopeResultRequestDto resultRequestDto, IStringLocalizer stringLocalizer)
        {
            var lError = new List<string>();

            lError.AddIfNotIsNullOrWhiteSpace(ValidateSkuId(resultRequestDto.SkuId, stringLocalizer));

            if (lError.Count > 0)
                return lError;

            return null;
        }

        #endregion
    }
}
