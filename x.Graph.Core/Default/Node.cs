using System;

namespace x.Graph.Core.Default
{
    public class Node<T> : INode<T>
    {
        public System.Collections.Generic.IEnumerable<IEdge<T>> IncomingEdges
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public System.Collections.Generic.IEnumerable<IEdge<T>> OutgoingEdges
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public System.Collections.Generic.IEnumerable<INode<T>> Predecessors
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public System.Collections.Generic.IEnumerable<IEdge<T>> SelfLoops
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public System.Collections.Generic.IEnumerable<INode<T>> Successors
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public T UniqueId
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
