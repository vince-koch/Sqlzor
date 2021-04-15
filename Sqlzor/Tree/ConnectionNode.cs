using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sqlzor.Tree
{
    public class ConnectionNode : TreeNode
    {
        public DatabaseNode[] Databases => Children.OfType<DatabaseNode>().ToArray();
    }
}
