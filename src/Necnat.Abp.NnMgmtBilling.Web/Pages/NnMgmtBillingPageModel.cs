using Necnat.Abp.NnMgmtBilling.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Necnat.Abp.NnMgmtBilling.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class NnMgmtBillingPageModel : AbpPageModel
{
    protected NnMgmtBillingPageModel()
    {
        LocalizationResourceType = typeof(NnMgmtBillingResource);
        ObjectMapperContext = typeof(NnMgmtBillingWebModule);
    }
}
