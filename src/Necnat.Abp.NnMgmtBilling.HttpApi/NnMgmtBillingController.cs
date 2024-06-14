using Necnat.Abp.NnMgmtBilling.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Necnat.Abp.NnMgmtBilling;

public abstract class NnMgmtBillingController : AbpControllerBase
{
    protected NnMgmtBillingController()
    {
        LocalizationResource = typeof(NnMgmtBillingResource);
    }
}
