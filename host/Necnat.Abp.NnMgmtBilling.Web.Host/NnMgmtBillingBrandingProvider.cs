using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Necnat.Abp.NnMgmtBilling;

[Dependency(ReplaceServices = true)]
public class NnMgmtBillingBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "NnMgmtBilling";
}
