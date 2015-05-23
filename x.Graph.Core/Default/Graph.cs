using System;
using System.Collections.Generic;

namespace x.Graph.Core.Default
{
    public class Graph<T> : IGraph<T>
    {
        #region Constructors
        public Graph()
        {
            _Nodes = new Dictionary<T, INode<T>>();
        }
        #endregion

        #region Nodes
        private IDictionary<T, INode<T>> _Nodes;

        /// <summary>
        /// Treat Graph object indexing as a retrieval for nodes.
        /// </summary>
        /// <param name="uniqueId">Unique ID of node to be retrieved.</param>
        /// <returns>INode Object</returns>
        public INode<T> this[T uniqueId]
        {
            get
            {
                return _Nodes[uniqueId];
            }
        }

        /// <summary>
        /// Returns a Node object for the given unique id.
        /// </summary>
        /// <param name="uniqueId">Unique ID of node to be retrieved.</param>
        /// <returns>INode Object</returns>
        public INode<T> GetNode(T uniqueId)
        {
            return this[uniqueId];
        }

        /// <summary>
        /// Returns collection of Nodes for Graph object.
        /// </summary>
        public IEnumerable<INode<T>> Nodes
        {
            get
            {
                return _Nodes.Values;
            }
        }

        /// <summary>
        /// Returns the number of nodes contained in Graph object.
        /// </summary>
        public int NodeCount
        {
            get
            {
                return _Nodes.Count;
            }
        }

        // Not sure yet how to implement this. Might only be viable for
        // a particular kind of type such as int where we can increment.
        public INode<T> AddNode()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds a "blank" node to the Graph object identifiable
        /// by the given unique id.
        /// </summary>
        /// <param name="uniqueId">Unique ID of node to be added.</param>
        /// <returns>INode Object</returns>
        public INode<T> AddNode(T uniqueId)
        {
            INode<T> newNode = new Node<T>(uniqueId);
            _Nodes.Add(uniqueId, newNode);
            return newNode;
        }

        /// <summary>
        /// Removes a node from the Graph object with the given unique id.
        /// </summary>
        /// <param name="uniqueId">Unique ID of node to be added.</param>
        public void RemoveNode(T uniqueId)
        {
            _Nodes.Remove(uniqueId);
        }
        #endregion

        public IEdge<T> this[T srcId, T targId]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int EdgeCount
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<IEdge<T>> Edges
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsAcyclic
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsConnected
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEdge<T> AddEdge(INode<T> srce, INode<T> target)
        {
            throw new NotImplementedException();
        }

        public IEdge<T> AddEdge(T fromUniqueId, T toUniqueId)
        {
            throw new NotImplementedException();
        }

        public IEdge<T> GetEdge(T srcId, T targId)
        {
            throw new NotImplementedException();
        }

        public void RemoveAllEdges(T fromUniqueId, T toUniqueId)
        {
            throw new NotImplementedException();
        }

        public void RemoveEdge(IEdge<T> edge)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<INode<T>> TraverseBF(INode<T> root)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<INode<T>> TraverseBF(T uniqueId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<INode<T>> TraverseDF(INode<T> root)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<INode<T>> TraverseDF(T uniqueId)
        {
            throw new NotImplementedException();
        }
    }
}
