using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Sqlzor.Drivers.Models;

namespace Sqlzor.Tree
{
    public class ViewColumnNode : TreeNode
    {
        private readonly ViewColumnModel _viewColumn;

        public ViewColumnNode(ViewColumnModel viewColumn)
        {
            _viewColumn = viewColumn;
        }
    }
}
