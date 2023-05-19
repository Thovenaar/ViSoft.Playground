using ViSoft.Playground.WebAPI.IntegrationTests.TestUtils.Factories;

namespace ViSoft.Playground.WebAPI.IntegrationTests.TestUtils
{
    /// <summary>
    /// This class contains all collections of tests.
    /// Please create a new collection for each new test case that needs their own seed data.
    /// </summary>
    public class SharedTestCollections
    {
        public const string GenericCollection = "GenericCollection";
        public const string UserCollection = "UserCollection";
    }

    [CollectionDefinition(SharedTestCollections.GenericCollection)]
    public class GenericCollection : ICollectionFixture<GenericFactory>
    {
    }

    [CollectionDefinition(SharedTestCollections.UserCollection)]
    public class MonitoringCollection : ICollectionFixture<UserFactory>
    {
    }


}
