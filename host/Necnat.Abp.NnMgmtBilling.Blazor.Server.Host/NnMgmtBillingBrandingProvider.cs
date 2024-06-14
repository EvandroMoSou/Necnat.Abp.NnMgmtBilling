using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Necnat.Abp.NnMgmtBilling.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class NnMgmtBillingBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "NnMgmtBilling";
}
