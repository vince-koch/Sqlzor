using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sqlzor.DbSchema;
using Sqlzor.DbSchema.Models;
using Sqlzor.DbSchema.Postgres;

namespace Sqlzor.Generators
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                Generate().GetAwaiter().GetResult();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success");
                return 0;
            }
            catch (Exception thrown)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(thrown);
                return -1;
            }
            finally
            {
                Console.ResetColor();
            }
        }

        private static async Task Generate()
        {
            var manager = new SchemaManager();

            var schema = await manager.GetSchema(
                new NpgsqlDatabaseDriver(),
                "Host=localhost; Port=5433; Database=chinook; Username=postgres; Password=chinook");

            var treeBuilder = new SchemaTreeBuilder();
            var tree = treeBuilder.BuildTree(schema);

            var builder = new StringBuilder();
            var tables = Descendents(tree, node => node.Model is TableModel).ToArray();
            foreach (var table in tables)
            {
                var tableModel = table.Model as TableModel;

                builder.AppendLine($"public class {tableModel.TableSchema}_{tableModel.TableName}")
                    .AppendLine("{");
                    

                var columns = Descendents(table, node => node.Model is ColumnModel).ToArray();
                foreach (var column in columns)
                {
                    var columnModel = column.Model as ColumnModel;

                    builder.AppendLine($"public {columnModel.DataType} {columnModel.ColumnName} {{ get; set; }}");
                }

                builder.AppendLine("}");
            }

            Console.WriteLine(builder.ToString());
            Debug.WriteLine(builder.ToString());
        }

        private static IEnumerable<Node> Descendents(Node node)
        {
            return Descendents(node, node => true);
        }

        private static IEnumerable<Node> Descendents(Node node, Func<Node, bool> predicate)
        {
            if (predicate(node))
            {
                yield return node;
            }

            foreach (var child in node.Children)
            {
                foreach (var descendant in Descendents(child, predicate))
                {
                    yield return descendant;
                }
            }
        }
    }
}
