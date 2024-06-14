using Necnat.Abp.NnMgmtBilling.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Necnat.Abp.NnMgmtBilling.Permissions;

public class NnMgmtBillingPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(NnMgmtBillingPermissions.GroupName, L("Permission:NnMgmtBilling"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<NnMgmtBillingResource>(name);
    }
}
