using Microsoft.Extensions.Localization;
using Necnat.Abp.NnLibCommon.Extensions;
using Necnat.Abp.NnLibCommon.Validators;
using System.Collections.Generic;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public static class BillingClientValidator
    {
        public static List<string>? Validate(BillingClientDto dto, IStringLocalizer stringLocalizer)
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
                return string.Format(stringLocalizer[ValidationMessages.Required], BillingClientConsts.NameDisplay);

            if (value!.Length > BillingClientConsts.MaxNameLength)
                return string.Format(stringLocalizer[ValidationMessages.MaxLength], BillingClientConsts.NameDisplay, BillingClientConsts.MaxNameLength);

            return null;
        }

        public static string? ValidateIsActive(bool? value, IStringLocalizer stringLocalizer)
        {
            if (value == null)
                return string.Format(stringLocalizer[ValidationMessages.Required], BillingClientConsts.IsActiveDisplay);

            return null;
        }

        #region ResultRequestDto

        public static List<string>? Validate(BillingClientResultRequestDto resultRequestDto, IStringLocalizer stringLocalizer)
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

            if (value.Length < BillingClientConsts.MinNameLength || value.Length > BillingClientConsts.MaxNameLength)
                return string.Format(stringLocalizer[ValidationMessages.MinMaxLength], BillingClientConsts.NameDisplay, BillingClientConsts.MinNameLength, BillingClientConsts.MaxNameLength);

            return null;
        }

        #endregion
    }
}
