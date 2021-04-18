using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Sqlzor.Drivers.Models;

namespace Sqlzor.Tree
{
    public class SchemaTreeBuilder
    {
        public Node BuildTree(SchemaModel schema)
        {
            var allModels = new List<object>();
            allModels.AddRange(schema.Columns);
            allModels.AddRange(schema.Databases);
            allModels.AddRange(schema.DataSourceInformation);
            allModels.AddRange(schema.ForeignKeys);
            allModels.AddRange(schema.IndexColumns);
            allModels.AddRange(schema.Indexes);
            allModels.AddRange(schema.ProcedureParameters);
            allModels.AddRange(schema.Procedures);
            allModels.AddRange(schema.Tables);
            allModels.AddRange(schema.Users);
            allModels.AddRange(schema.ViewColumns);
            allModels.AddRange(schema.Views);

            var allNodes = allModels.Select(item => CreateNode(item)).ToList();
            var childNodes = allNodes.SelectMany(item => item.Children).ToArray();
            allNodes.AddRange(childNodes);
            allNodes = allNodes.OrderBy(item => item.Path).ToList();

            foreach (var node in allNodes.Where(item => item.Parent == null))
            {
                var segments = node.Path.Split('/');
                var parentPath = string.Join("/", segments.Take(segments.Length - 1));
                var parentNode = allNodes.Where(item => item.Path == parentPath).SingleOrDefault();
                if (parentNode != null && parentNode != node)
                {
                    node.Parent = parentNode;
                }
            }

            var rootNode = allNodes.Where(item => item.Path == string.Empty).Single();
            var unparentedNodes = allNodes
                .Where(item => item.Parent == null)
                .Where(item => item.Path != string.Empty)
                .ToArray();

            if (unparentedNodes.Length > 0)
            {
                var unparented = AddFolderNode(rootNode, "Unparented");
                unparentedNodes.ForEach(item => item.Parent = unparented);
                DebugNode(rootNode, 0);
            }

            return rootNode;
        }

        private Node CreateNode(object model)
        {
            var node = new Node();
            node.Model = model;

            switch (model.GetType().Name)
            {
                case nameof(ColumnModel):
                    var column = model as ColumnModel;
                    node.Path = $"/Databases/{column.TableCatalog}/Tables/{column.TableSchema}.{column.TableName}/Columns/{column.ColumnName}";
                    break;

                case nameof(DatabaseModel):
                    var database = model as DatabaseModel;
                    node.Path = $"/Databases/{database.DatabaseName}";
                    AddFolderNode(node, "Tables");
                    AddFolderNode(node, "Views");
                    AddFolderNode(node, "Procedures");
                    AddFolderNode(node, "Users");
                    break;

                case nameof(DataSourceInformationModel):
                    node.Path = string.Empty;
                    AddFolderNode(node, "Databases");
                    break;

                case nameof(ForeignKeyModel):
                    var foreignKey = model as ForeignKeyModel;
                    node.Path = $"/Databases/{foreignKey.TableCatalog}/Tables/{foreignKey.TableSchema}.{foreignKey.TableName}/Keys/{foreignKey.ConstraintName}";
                    break;

                case nameof(IndexColumnModel):
                    var indexColumn = model as IndexColumnModel;
                    node.Path = $"/Databases/{indexColumn.TableCatalog}/Tables/{indexColumn.TableSchema}.{indexColumn.TableName}/Indexes/{indexColumn.IndexName}/Columns/{indexColumn.ColumnName}";
                    break;

                case nameof(IndexModel):
                    var index = model as IndexModel;
                    node.Path = $"/Databases/{index.TableCatalog}/Tables/{index.TableSchema}.{index.TableName}/Indexes/{index.IndexName}";
                    AddFolderNode(node, "Columns");
                    break;

                case nameof(ProcedureModel):
                    var procedure = model as ProcedureModel;
                    node.Path = $"/Databases/{procedure.RoutineCatalog}/Procedures/{procedure.RoutineSchema}.{procedure.RoutineName}";
                    break;

                case nameof(TableModel):
                    var table = model as TableModel;
                    node.Path = $"/Databases/{table.TableCatalog}/Tables/{table.TableSchema}.{table.TableName}";
                    AddFolderNode(node, "Columns");
                    AddFolderNode(node, "Indexes");
                    AddFolderNode(node, "Keys");
                    break;

                case nameof(UserModel):
                    var user = model as UserModel;
                    node.Path = $"/Users/{user.UserName}";
                    break;

                case nameof(ViewColumnModel):
                    var viewColumn = model as ViewColumnModel;
                    node.Path = $"/Databases/{viewColumn.TableCatalog}/Tables/{viewColumn.TableSchema}.{viewColumn.TableName}/Columns/{viewColumn.ColumnName}";
                    break;

                case nameof(ViewModel):
                    var view = model as ViewModel;
                    node.Path = $"/Databases/{view.TableCatalog}/Tables/{view.TableSchema}.{view.TableName}";
                    AddFolderNode(node, "Columns");
                    break;

                case nameof(DataTypeModel):
                case nameof(SchemaModel):
                default:
                    break;
            }

            return node;
        }

        private Node AddFolderNode(Node parent, string name)
        {
            var child = new Node();
            child.Parent = parent;
            child.Path = parent.Path + "/" + name;
            return child;
        }

        private void DebugNode(Node node, int depth)
        {
            var indent = new string(' ', depth * 4);
            System.Diagnostics.Debug.WriteLine($"{indent}{node.Name}    [{DebugType(node)}: {node.Path}]");
            foreach (var child in node.Children)
            {
                DebugNode(child, depth + 1);
            }
        }

        private string DebugType(Node node)
        {
            var type = node.Model != null
                ? node.Model.GetType().Name
                : "Folder";

            return type;
        }
    }
}
