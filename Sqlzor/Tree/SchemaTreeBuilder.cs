using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Sqlzor.Drivers.Models;

namespace Sqlzor.Tree
{
    public class SchemaTreeBuilder
    {
        public ConnectionNode BuildTree(SchemaModel schema)
        {
            var connectionNode = new ConnectionNode();
            var databaseNodes = BuildDatabases(schema, connectionNode);
            var tableNodes = BuildTables(schema, databaseNodes);
            var viewNodes = BuildViews(schema, databaseNodes);
            var procedureNodes = BuildProcedures(schema, databaseNodes);

            return connectionNode;
        }

        private DatabaseNode[] BuildDatabases(SchemaModel schema, ConnectionNode connectionNode)
        {
            var databaseNodes = schema.Databases
                .Select(database => new DatabaseNode(database))
                .ToArray();

            databaseNodes.ForEach(node => node.Parent = connectionNode);

            return databaseNodes;
        }

        private TableNode[] BuildTables(SchemaModel schema, DatabaseNode[] databaseNodes)
        {
            var tableNodes = new List<TableNode>();

            foreach (var table in schema.Tables)
            {
                var tableNode = new TableNode(table);

                tableNode.Parent = databaseNodes
                    .Where(item => item.Name == table.TableCatalog)
                    .Single();

                tableNodes.Add(tableNode);
            }

            return tableNodes.ToArray();
        }

        private ViewNode[] BuildViews(SchemaModel schema, DatabaseNode[] databaseNodes)
        {
            var viewNodes = new List<ViewNode>();

            foreach (var view in schema.Views)
            {
                var viewNode = new ViewNode(view);

                viewNode.Parent = databaseNodes
                    .Where(item => item.Name == view.TableCatalog)
                    .Single();

                viewNodes.Add(viewNode);
            }

            return viewNodes.ToArray();
        }

        private ProcedureNode[] BuildProcedures(SchemaModel schema, DatabaseNode[] databaseNodes)
        {
            var procedureNodes = new List<ProcedureNode>();

            foreach (var procedure in schema.Procedures)
            {
                var procedureNode = new ProcedureNode(procedure);

                procedureNode.Parent = databaseNodes
                    .Where(item => item.Name == procedure.RoutineCatalog)
                    .Single();

                procedureNodes.Add(procedureNode);
            }

            return procedureNodes.ToArray();
        }
    }
}
