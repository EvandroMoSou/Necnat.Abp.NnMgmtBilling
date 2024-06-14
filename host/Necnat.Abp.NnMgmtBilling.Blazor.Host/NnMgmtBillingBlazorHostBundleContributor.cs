using Volo.Abp.Bundling;

namespace Necnat.Abp.NnMgmtBilling.Blazor.Host;

public class NnMgmtBillingBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
