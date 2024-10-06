using Sqlzor.DbSchema.Drivers;

namespace Sqlzor.DbSchema.Mongo
{
    public class MongoDatabaseDriver : AbstractDatabaseDriver
    {
        public MongoDatabaseDriver() : base(
            typeof(MongoConnection),
            dbProviderFactory: null,
            new MongoSchemaMapper())
        {
        }
    }
}
