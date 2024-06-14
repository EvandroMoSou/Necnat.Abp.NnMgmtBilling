namespace Necnat.Abp.NnMgmtBilling;

public static class NnMgmtBillingDbProperties
{
    public static string DbTablePrefix { get; set; } = "NnMgmtBilling";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "NnMgmtBilling";
}
