using Necnat.Abp.NnMgmtBilling.Localization;
using Volo.Abp.Application.Services;

namespace Necnat.Abp.NnMgmtBilling;

public abstract class NnMgmtBillingAppService : ApplicationService
{
    protected NnMgmtBillingAppService()
    {
        LocalizationResource = typeof(NnMgmtBillingResource);
        ObjectMapperContext = typeof(NnMgmtBillingApplicationModule);
    }
}
