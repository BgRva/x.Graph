using System;
using System.Collections.Generic;

namespace x.Graph.Core.Default
{
    public class Node<T> : INode<T>
    {
        /// <summary>
        /// Node must be given a unique id in order to be constructed.  The
        /// unique id is immutable for a given node
        /// </summary>
        /// <param name="uniqueId">Unique id for new node.</param>
        public Node(T uniqueId)
        {
            _UniqueId = uniqueId;
        }

        private T _UniqueId;

        public T UniqueId
        {
            get
            {
                return _UniqueId;
            }
        }

        public IEnumerable<IEdge<T>> IncomingEdges
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<IEdge<T>> OutgoingEdges
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<INode<T>> Predecessors
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<IEdge<T>> SelfLoops
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<INode<T>> Successors
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
