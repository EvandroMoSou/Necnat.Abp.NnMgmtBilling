using Volo.Abp.Modularity;

namespace Necnat.Abp.NnMgmtBilling;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class NnMgmtBillingDomainTestBase<TStartupModule> : NnMgmtBillingTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
