using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Sqlzor.Drivers.Models;

namespace Sqlzor.Tree
{
    public class ColumnNode : TreeNode
    {
        private readonly ColumnModel _column;

        public ColumnNode(ColumnModel column)
        {
            _column = column;
        }
    }
}
