using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Sqlzor.Drivers.Models;

namespace Sqlzor.Tree
{
    public class DatabaseNode : TreeNode
    {
        private readonly DatabaseModel _database;

        public TableNode[] Tables => Children.OfType<TableNode>().ToArray();

        public ViewNode[] Views => Children.OfType<ViewNode>().ToArray();

        public ProcedureNode[] Procedures => Children.OfType<ProcedureNode>().ToArray();

        public string Name { get; }

        public DatabaseNode(DatabaseModel database)
        {
            _database = database;
        }
    }
}
