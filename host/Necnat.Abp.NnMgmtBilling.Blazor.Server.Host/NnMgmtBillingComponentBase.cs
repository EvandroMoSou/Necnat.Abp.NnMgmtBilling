using Necnat.Abp.NnMgmtBilling.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Necnat.Abp.NnMgmtBilling.Blazor.Server.Host;

public abstract class NnMgmtBillingComponentBase : AbpComponentBase
{
    protected NnMgmtBillingComponentBase()
    {
        LocalizationResource = typeof(NnMgmtBillingResource);
    }
}
