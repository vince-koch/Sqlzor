using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Sqlzor.Drivers.Models;

namespace Sqlzor.Tree
{
    public class ForeignKeyNode : TreeNode
    {
        private readonly ForeignKeyModel _foreignKey;

        public ForeignKeyNode(ForeignKeyModel foreignKey)
        {
            _foreignKey = foreignKey;
        }
    }
}
