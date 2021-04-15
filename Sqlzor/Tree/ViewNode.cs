using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Sqlzor.Drivers.Models;

namespace Sqlzor.Tree
{
    public class ViewNode : TreeNode
    {
        private readonly ViewModel _view;

        public ViewColumnNode[] ViewColumnNodes => Children.OfType<ViewColumnNode>().ToArray();

        public ViewNode(ViewModel view)
        {
            _view = view;
        }
    }
}
