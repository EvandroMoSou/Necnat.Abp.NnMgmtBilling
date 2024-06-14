using Necnat.Abp.NnMgmtBilling.Samples;
using Xunit;

namespace Necnat.Abp.NnMgmtBilling.MongoDB.Domains;

[Collection(MongoTestCollection.Name)]
public class MongoDBSampleDomain_Tests : SampleManager_Tests<NnMgmtBillingMongoDbTestModule>
{

}
