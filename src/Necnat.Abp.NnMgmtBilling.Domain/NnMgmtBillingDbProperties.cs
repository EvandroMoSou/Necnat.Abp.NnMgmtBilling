namespace Necnat.Abp.NnMgmtBilling;

public static class NnMgmtBillingDbProperties
{
    public static string DbTablePrefix { get; set; } = "Blln";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "NnMgmtBilling";
}
