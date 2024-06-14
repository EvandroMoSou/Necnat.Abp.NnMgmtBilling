using Necnat.Abp.NnMgmtBilling.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Necnat.Abp.NnMgmtBilling.Pages;

public abstract class NnMgmtBillingPageModel : AbpPageModel
{
    protected NnMgmtBillingPageModel()
    {
        LocalizationResourceType = typeof(NnMgmtBillingResource);
    }
}
