using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Necnat.Abp.NnMgmtBilling.EntityFrameworkCore;

public class NnMgmtBillingHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<NnMgmtBillingHttpApiHostMigrationsDbContext>
{
    public NnMgmtBillingHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<NnMgmtBillingHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("NnMgmtBilling"));

        return new NnMgmtBillingHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
