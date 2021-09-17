using Sqlzor.DbSchema.Models;

namespace Sqlzor.DbSchema
{
    public interface ISchemaTreeBuilder
    {
        Node BuildTree(SchemaModel schema);
    }
}
