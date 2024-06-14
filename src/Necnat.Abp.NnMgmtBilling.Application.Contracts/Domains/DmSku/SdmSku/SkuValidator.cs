using Microsoft.Extensions.Localization;
using Necnat.Abp.NnLibCommon.Extensions;
using Necnat.Abp.NnLibCommon.Validators;
using System.Collections.Generic;
using System.Linq;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public static class SkuValidator
    {
        public static List<string>? Validate(SkuDto dto, IStringLocalizer stringLocalizer)
        {
            var lError = new List<string>();

            lError.AddIfNotIsNullOrWhiteSpace(ValidateName(dto.Name, stringLocalizer));
            lError.AddIfNotIsNullOrWhiteSpace(ValidateIsActive(dto.IsActive, stringLocalizer));

            if (lError.Count > 0)
                return lError;

            return null;
        }

        public static string? ValidateName(string? value, IStringLocalizer stringLocalizer)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Format(stringLocalizer[ValidationMessages.Required], SkuConsts.NameDisplay);

            if (value!.Length > SkuConsts.MaxNameLength)
                return string.Format(stringLocalizer[ValidationMessages.MaxLength], SkuConsts.NameDisplay, SkuConsts.MaxNameLength);

            return null;
        }

        public static string? ValidateIsActive(bool? value, IStringLocalizer stringLocalizer)
        {
            if (value == null)
                return string.Format(stringLocalizer[ValidationMessages.Required], SkuConsts.IsActiveDisplay);

            return null;
        }

        public static string? ValidateSkuScopeList(List<SkuScopeDto>? value, IStringLocalizer stringLocalizer)
        {
            if (value == null)
                return null;

            var lCheck = new List<SkuScopeDto>();
            foreach (var iScope in value)
            {
                if(lCheck.Any(x => 
                    x.ApplicationName == iScope.ApplicationName
                    && x.HttpMethod == iScope.HttpMethod
                    && x.Url == iScope.Url))
                    return string.Format(stringLocalizer[ValidationMessages.DuplicateValues], SkuConsts.SkuScopeListDisplay);

                if (iScope.HttpMethod != null
                    && value.Any(x =>
                        x.ApplicationName == iScope.ApplicationName
                        && x.HttpMethod == null
                        && x.Url == iScope.Url))
                    return "There cannot be an api scope without an http method and another with an http method for the same url.";

                if (string.IsNullOrWhiteSpace(iScope.Url)
                    && value.Any(x =>
                        x.ApplicationName == iScope.ApplicationName
                        && !string.IsNullOrWhiteSpace(x.Url)
                        && x.IsBillable == iScope.IsBillable))
                    return "There cannot be an application scope and an api scope of that application with the same value for the field Billable.";

                lCheck.Add(iScope);
            }

            return null;
        }

        public static string? ValidateSkuPriceRangeList(List<SkuPriceRangeDto>? value, IStringLocalizer stringLocalizer)
        {
            if (value == null)
                return null;

            var checkNullUpToRequestCount = false;
            var lCheck = new List<SkuPriceRangeDto>();
            foreach (var iPriceRange in value)
            {
                if (lCheck.Any(x => x.UpToRequestCount == iPriceRange.UpToRequestCount))
                    return string.Format(stringLocalizer[ValidationMessages.DuplicateValues], SkuConsts.SkuPriceRangeListDisplay);

                checkNullUpToRequestCount = checkNullUpToRequestCount || iPriceRange.UpToRequestCount == null;

                lCheck.Add(iPriceRange);
            }

            if(!checkNullUpToRequestCount)
                return "There must be a price range without request count.";

            return null;
        }

        #region ResultRequestDto

        public static List<string>? Validate(SkuResultRequestDto resultRequestDto, IStringLocalizer stringLocalizer)
        {
            var lError = new List<string>();

            lError.AddIfNotIsNullOrWhiteSpace(ValidateNameContains(resultRequestDto.NameContains, stringLocalizer));

            if (lError.Count > 0)
                return lError;

            return null;
        }

        public static string? ValidateNameContains(string? value, IStringLocalizer stringLocalizer)
        {
            if (value == null)
                return null;

            if (value.Length < SkuConsts.MinNameLength || value.Length > SkuConsts.MaxNameLength)
                return string.Format(stringLocalizer[ValidationMessages.MinMaxLength], SkuConsts.NameDisplay, SkuConsts.MinNameLength, SkuConsts.MaxNameLength);

            return null;
        }

        #endregion
    }
}
