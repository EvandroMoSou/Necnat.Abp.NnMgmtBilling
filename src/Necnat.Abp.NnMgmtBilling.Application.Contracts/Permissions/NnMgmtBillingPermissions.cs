using Volo.Abp.Reflection;

namespace Necnat.Abp.NnMgmtBilling.Permissions;

public class NnMgmtBillingPermissions
{
    public const string GroupName = "NnMgmtBilling";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(NnMgmtBillingPermissions));
    }
}
