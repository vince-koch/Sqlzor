using System.Collections.Generic;
using MongoDB.Bson;

namespace Sqlzor.DbSchema.Mongo;

public class BsonTreeNode
{
    public string Name { get; set; }
    public BsonValue Value { get; set; }
    public List<BsonTreeNode> Children { get; set; } = new List<BsonTreeNode>();

    public BsonTreeNode(BsonValue value, string? name = null)
    {
        Value = value;
        Name = name ?? "ROOT";
        BuildChildren();
    }

    private void BuildChildren()
    {
        if (Value == null || Value.IsBsonNull)
        {
            return;
        }

        switch (Value.BsonType)
        {
            case BsonType.Document:
                var document = Value.AsBsonDocument;
                //foreach (var element in document)
                foreach (var element in document.OrderBy(e => e.Name))
                {
                    var childNode = new BsonTreeNode(element.Value, element.Name);
                    Children.Add(childNode);
                }
                break;

            case BsonType.Array:
                var array = Value.AsBsonArray;
                int index = 0;
                foreach (var item in array)
                {
                    var childNode = new BsonTreeNode(item, $"[{index}]");
                    Children.Add(childNode);
                    index++;
                }
                break;

            // For other types (primitive values), no children are added.
            default:
                // Leaf node; no children to add.
                break;
        }
    }
}
