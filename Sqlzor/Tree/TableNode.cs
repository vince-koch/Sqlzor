using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Sqlzor.Drivers.Models;

namespace Sqlzor.Tree
{
    public class TableNode : TreeNode
    {
        private readonly TableModel _table;

        public ColumnNode[] Columns => Children.OfType<ColumnNode>().ToArray();

        public ForeignKeyNode[] ForeignKeys => Children.OfType<ForeignKeyNode>().ToArray();

        public TableNode(TableModel table)
        {
            _table = table;
        }
    }
}
