using Necnat.Abp.NnMgmtBilling.MongoDB;
using Necnat.Abp.NnMgmtBilling.Samples;
using Xunit;

namespace Necnat.Abp.NnMgmtBilling.MongoDb.Applications;

[Collection(MongoTestCollection.Name)]
public class MongoDBSampleAppService_Tests : SampleAppService_Tests<NnMgmtBillingMongoDbTestModule>
{

}
