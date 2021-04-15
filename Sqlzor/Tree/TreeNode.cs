using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sqlzor.Tree
{
    public class TreeNode
    {
        private TreeNode _parent;

        public TreeNode Parent 
        {
            get
            {
                return _parent;
            }

            set
            {
                _parent?.Children?.Remove(this);
                _parent = value;
                _parent?.Children?.Add(this);
            }
        }

        public List<TreeNode> Children { get; } = new List<TreeNode>();
    }
}
