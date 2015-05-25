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

        private List<IEdge<T>> _IncomingEdges = null;
        private List<IEdge<T>> _OutgoingEdges = null;
        private IEdge<T> _SelfLoops = null;

        /// <summary>
        /// Add incoming edge to list of incoming edges for Node object.
        /// </summary>
        /// <param name="incomingEdge">An edge where current node is target of edge.</param>
        public void AddIncomingEdge(IEdge<T> incomingEdge)
        {
            if (_IncomingEdges == null)
                _IncomingEdges = new List<IEdge<T>>();

            _IncomingEdges.Add(incomingEdge);
        }

        /// <summary>
        /// Add outgoing edge to list of outgoing edges for Node object.
        /// </summary>
        /// <param name="outgoingEdge">An edge where current node is source of edge.</param>
        public void AddOutgoingEdge(IEdge<T> outgoingEdge)
        {
            if (_OutgoingEdges == null)
                _OutgoingEdges = new List<IEdge<T>>();

            _OutgoingEdges.Add(outgoingEdge);
        }

        /// <summary>
        /// Add self-loop for Node object.
        /// </summary>
        /// <param name="outgoingEdge">An edge where current node is source and sink of edge.</param>
        public void AddSelfLoop(IEdge<T> edge)
        {
            _SelfLoops = edge;
        }

        public IEnumerable<IEdge<T>> IncomingEdges
        {
            get
            {
                return _IncomingEdges;
            }
        }

        public IEnumerable<IEdge<T>> OutgoingEdges
        {
            get
            {
                return _OutgoingEdges;
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
