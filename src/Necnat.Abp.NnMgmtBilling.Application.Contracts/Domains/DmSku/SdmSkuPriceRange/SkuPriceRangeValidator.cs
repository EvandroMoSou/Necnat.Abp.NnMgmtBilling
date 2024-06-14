using Microsoft.Extensions.Localization;
using Necnat.Abp.NnLibCommon.Extensions;
using Necnat.Abp.NnLibCommon.Validators;
using System;
using System.Collections.Generic;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public static class SkuPriceRangeValidator
    {
        public static List<string>? Validate(SkuPriceRangeDto dto, IStringLocalizer stringLocalizer)
        {
            var lError = new List<string>();

            lError.AddIfNotIsNullOrWhiteSpace(ValidateSkuId(dto.SkuId, stringLocalizer));
            lError.AddIfNotIsNullOrWhiteSpace(ValidatePrice(dto.Price, stringLocalizer));
            lError.AddIfNotIsNullOrWhiteSpace(ValidateUpToRequestCount(dto.UpToRequestCount, stringLocalizer));

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

        public static string? ValidatePrice(decimal? value, IStringLocalizer stringLocalizer)
        {
            if (value == null)
                return string.Format(stringLocalizer[ValidationMessages.Required], SkuPriceRangeConsts.PriceDisplay);

            if (value < 0)
                return string.Format(stringLocalizer[ValidationMessages.LessThanZero], SkuPriceRangeConsts.PriceDisplay);

            return null;
        }

        public static string? ValidateUpToRequestCount(int? value, IStringLocalizer stringLocalizer)
        {
            if (value == null)
                return null;

            if (value < 0)
                return string.Format(stringLocalizer[ValidationMessages.LessThanZero], SkuPriceRangeConsts.UpToRequestCountDisplay);

            return null;
        }

        #region ResultRequestDto

        public static List<string>? Validate(SkuPriceRangeResultRequestDto resultRequestDto, IStringLocalizer stringLocalizer)
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
