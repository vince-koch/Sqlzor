using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Sqlzor.Tree
{
    [DebuggerDisplay("Node [{Path}]")]
    public class Node
    {
        private string _name = null;
        private Node _parent = null;

        public string Path { get; set; }

        public string Name
        {
            get => _name ?? Path?.Split('/')?.Last();
            set => _name = value;
        }

        public object Model { get; set; }

        public Node Parent
        {
            get
            {
                return _parent;
            }

            set
            {
                _parent?.Children?.Remove(this);
                _parent = value;
                _parent.Children.Add(this);
            }
        }

        public List<Node> Children { get; } = new List<Node>();
    }
}
