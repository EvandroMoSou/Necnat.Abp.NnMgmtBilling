using Volo.Abp.Modularity;

namespace Necnat.Abp.NnMgmtBilling;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class NnMgmtBillingApplicationTestBase<TStartupModule> : NnMgmtBillingTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
