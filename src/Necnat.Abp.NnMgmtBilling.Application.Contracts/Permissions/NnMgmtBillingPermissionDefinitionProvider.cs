using Necnat.Abp.NnMgmtBilling.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Necnat.Abp.NnMgmtBilling.Permissions;

public class NnMgmtBillingPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(NnMgmtBillingPermissions.GroupName, L("Permission:NnMgmtBilling"));

        var pgBillingClient = myGroup.AddPermission(NnMgmtBillingPermissions.PrmBillingClient.Default, L("Permission:BillingClient:Default"));
        pgBillingClient.AddChild(NnMgmtBillingPermissions.PrmBillingClient.Create, L("Permission:BillingClient:Create"));
        pgBillingClient.AddChild(NnMgmtBillingPermissions.PrmBillingClient.Update, L("Permission:BillingClient:Update"));
        pgBillingClient.AddChild(NnMgmtBillingPermissions.PrmBillingClient.Delete, L("Permission:BillingClient:Delete"));

        var pgBillingContract = myGroup.AddPermission(NnMgmtBillingPermissions.PrmBillingContract.Default, L("Permission:BillingContract:Default"));
        pgBillingContract.AddChild(NnMgmtBillingPermissions.PrmBillingContract.Create, L("Permission:BillingContract:Create"));
        pgBillingContract.AddChild(NnMgmtBillingPermissions.PrmBillingContract.Update, L("Permission:BillingContract:Update"));
        pgBillingContract.AddChild(NnMgmtBillingPermissions.PrmBillingContract.Delete, L("Permission:BillingContract:Delete"));

        var pgBillingEndpoint = myGroup.AddPermission(NnMgmtBillingPermissions.PrmBillingEndpoint.Default, L("Permission:BillingEndpoint:Default"));
        pgBillingEndpoint.AddChild(NnMgmtBillingPermissions.PrmBillingEndpoint.Create, L("Permission:BillingEndpoint:Create"));
        pgBillingEndpoint.AddChild(NnMgmtBillingPermissions.PrmBillingEndpoint.Update, L("Permission:BillingEndpoint:Update"));
        pgBillingEndpoint.AddChild(NnMgmtBillingPermissions.PrmBillingEndpoint.Delete, L("Permission:BillingEndpoint:Delete"));
        pgBillingEndpoint.AddChild(NnMgmtBillingPermissions.PrmBillingEndpoint.CallEndpoint, L("Permission:BillingEndpoint:CallEndpoint"));

        var pgNnAuditLog = myGroup.AddPermission(NnMgmtBillingPermissions.PrmNnAuditLog.Default, L("Permission:NnAuditLog:Default"));
        pgNnAuditLog.AddChild(NnMgmtBillingPermissions.PrmNnAuditLog.Create, L("Permission:NnAuditLog:Create"));
        pgNnAuditLog.AddChild(NnMgmtBillingPermissions.PrmNnAuditLog.Update, L("Permission:NnAuditLog:Update"));
        pgNnAuditLog.AddChild(NnMgmtBillingPermissions.PrmNnAuditLog.Delete, L("Permission:NnAuditLog:Delete"));

        var pgNnOpenIddictApplication = myGroup.AddPermission(NnMgmtBillingPermissions.PrmNnOpenIddictApplication.Default, L("Permission:NnOpenIddictApplication:Default"));
        pgNnOpenIddictApplication.AddChild(NnMgmtBillingPermissions.PrmNnOpenIddictApplication.Create, L("Permission:NnOpenIddictApplication:Create"));
        pgNnOpenIddictApplication.AddChild(NnMgmtBillingPermissions.PrmNnOpenIddictApplication.Update, L("Permission:NnOpenIddictApplication:Update"));
        pgNnOpenIddictApplication.AddChild(NnMgmtBillingPermissions.PrmNnOpenIddictApplication.Delete, L("Permission:NnOpenIddictApplication:Delete"));

        var pgSku = myGroup.AddPermission(NnMgmtBillingPermissions.PrmSku.Default, L("Permission:Sku:Default"));
        pgSku.AddChild(NnMgmtBillingPermissions.PrmSku.Create, L("Permission:Sku:Create"));
        pgSku.AddChild(NnMgmtBillingPermissions.PrmSku.Update, L("Permission:Sku:Update"));
        pgSku.AddChild(NnMgmtBillingPermissions.PrmSku.Delete, L("Permission:Sku:Delete"));

        var pgSkuPriceRange = myGroup.AddPermission(NnMgmtBillingPermissions.PrmSkuPriceRange.Default, L("Permission:SkuPriceRange:Default"));
        pgSkuPriceRange.AddChild(NnMgmtBillingPermissions.PrmSkuPriceRange.Create, L("Permission:SkuPriceRange:Create"));
        pgSkuPriceRange.AddChild(NnMgmtBillingPermissions.PrmSkuPriceRange.Update, L("Permission:SkuPriceRange:Update"));
        pgSkuPriceRange.AddChild(NnMgmtBillingPermissions.PrmSkuPriceRange.Delete, L("Permission:SkuPriceRange:Delete"));

        var pgSkuScope = myGroup.AddPermission(NnMgmtBillingPermissions.PrmSkuScope.Default, L("Permission:SkuScope:Default"));
        pgSkuScope.AddChild(NnMgmtBillingPermissions.PrmSkuScope.Create, L("Permission:SkuScope:Create"));
        pgSkuScope.AddChild(NnMgmtBillingPermissions.PrmSkuScope.Update, L("Permission:SkuScope:Update"));
        pgSkuScope.AddChild(NnMgmtBillingPermissions.PrmSkuScope.Delete, L("Permission:SkuScope:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<NnMgmtBillingResource>(name);
    }
}
