using Volo.Abp.Reflection;

namespace Necnat.Abp.NnMgmtBilling.Permissions;

public class NnMgmtBillingPermissions
{
    public const string GroupName = "NnMgmtBilling";

    public static class PrmBillingClient
    {
        public const string Default = GroupName + ".BillingClient";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class PrmBillingContract
    {
        public const string Default = GroupName + ".BillingContract";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class PrmBillingEndpoint
    {
        public const string Default = GroupName + ".BillingEndpoint";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string CallEndpoint = Default + ".CallEndpoint";
    }

    public static class PrmNnAuditLog
    {
        public const string Default = GroupName + ".NnAuditLog";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class PrmNnOpenIddictApplication
    {
        public const string Default = GroupName + ".NnOpenIddictApplication";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class PrmSku
    {
        public const string Default = GroupName + ".Sku";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class PrmSkuPriceRange
    {
        public const string Default = GroupName + ".SkuPriceRange";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class PrmSkuScope
    {
        public const string Default = GroupName + ".SkuScope";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(NnMgmtBillingPermissions));
    }
}
