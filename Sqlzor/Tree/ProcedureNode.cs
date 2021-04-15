using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Sqlzor.Drivers.Models;

namespace Sqlzor.Tree
{
    public class ProcedureNode : TreeNode
    {
        private readonly ProcedureModel _procedure;

        public ProcedureNode(ProcedureModel procedure)
        {
            _procedure = procedure;
        }
    }
}
