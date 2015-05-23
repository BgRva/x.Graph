using System;

namespace x.Graph.Core.Default
{
    public class Edge<T>: IEdge<T>
    {
        private INode<T> _SrcNode;
        private INode<T> _SnkNode;

        public INode<T> Source
        {
            get
            {
                return _SrcNode;
            }
        }

        public INode<T> Sink
        {
            get
            {
                return _SnkNode;
            }
        }

        public Edge(INode<T> srcNode, INode<T> snkNode)
        {
            _SrcNode = srcNode;
            _SnkNode = snkNode;
        }
    }
}
