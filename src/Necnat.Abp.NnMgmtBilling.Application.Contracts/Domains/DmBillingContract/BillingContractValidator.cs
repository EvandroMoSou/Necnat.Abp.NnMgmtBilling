using Microsoft.Extensions.Localization;
using Necnat.Abp.NnLibCommon.Extensions;
using Necnat.Abp.NnLibCommon.Validators;
using System;
using System.Collections.Generic;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public static class BillingContractValidator
    {
        public static List<string>? Validate(BillingContractDto dto, IStringLocalizer stringLocalizer)
        {
            var lError = new List<string>();

            lError.AddIfNotIsNullOrWhiteSpace(ValidateBillingClientId(dto.BillingClientId, stringLocalizer));
            lError.AddIfNotIsNullOrWhiteSpace(ValidateCode(dto.Code, stringLocalizer));
            lError.AddIfNotIsNullOrWhiteSpace(ValidateIsActive(dto.IsActive, stringLocalizer));
            lError.AddIfNotIsNullOrWhiteSpace(ValidateEffectiveTime(dto.EffectiveTime, stringLocalizer));

            if (lError.Count > 0)
                return lError;

            return null;
        }

        public static string? ValidateBillingClientId(Guid? value, IStringLocalizer stringLocalizer)
        {
            if (value == null || value == default)
                return string.Format(stringLocalizer[ValidationMessages.Required], BillingContractConsts.BillingClientIdDisplay);

            return null;
        }

        public static string? ValidateCode(string? value, IStringLocalizer stringLocalizer)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Format(stringLocalizer[ValidationMessages.Required], BillingContractConsts.CodeDisplay);

            if (value!.Length > BillingContractConsts.MaxCodeLength)
                return string.Format(stringLocalizer[ValidationMessages.MaxLength], BillingContractConsts.CodeDisplay, BillingContractConsts.MaxCodeLength);

            return null;
        }

        public static string? ValidateEffectiveTime(DateTimeOffset? value, IStringLocalizer stringLocalizer)
        {
            if (value == null)
                return string.Format(stringLocalizer[ValidationMessages.Required], BillingContractConsts.EffectiveTimeDisplay);

            return null;
        }

        public static string? ValidateIsActive(bool? value, IStringLocalizer stringLocalizer)
        {
            if (value == null)
                return string.Format(stringLocalizer[ValidationMessages.Required], BillingContractConsts.IsActiveDisplay);

            return null;
        }

        public static string? ValidateSkuReferenceTime(DateTimeOffset? value, IStringLocalizer stringLocalizer)
        {
            if (value == null)
                return string.Format(stringLocalizer[ValidationMessages.Required], BillingContractConsts.EffectiveTimeDisplay);

            return null;
        }

        #region ResultRequestDto

        public static List<string>? Validate(BillingContractResultRequestDto resultRequestDto, IStringLocalizer stringLocalizer)
        {
            var lError = new List<string>();

            lError.AddIfNotIsNullOrWhiteSpace(ValidateCodeContains(resultRequestDto.CodeContains, stringLocalizer));

            if (lError.Count > 0)
                return lError;

            return null;
        }

        public static string? ValidateCodeContains(string? value, IStringLocalizer stringLocalizer)
        {
            if (value == null)
                return null;

            if (value.Length < BillingContractConsts.MinCodeLength || value.Length > BillingContractConsts.MaxCodeLength)
                return string.Format(stringLocalizer[ValidationMessages.MinMaxLength], BillingContractConsts.CodeDisplay, BillingContractConsts.MinCodeLength, BillingContractConsts.MaxCodeLength);

            return null;
        }

        #endregion
    }
}
