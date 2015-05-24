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
            _Edges = new Dictionary<Tuple<T, T>, List<IEdge<T>>>();
        }
        #endregion

        #region Nodes
        private IDictionary<T, INode<T>> _Nodes;

        /// <summary>
        /// Treat Graph object indexing as a retrieval for nodes. If Graph object does not
        /// contain node with the given unique id, null is returned.
        /// </summary>
        /// <param name="uniqueId">Unique ID of node to be retrieved.</param>
        /// <returns>INode Object</returns>
        public INode<T> this[T uniqueId]
        {
            get
            {
                if (!_Nodes.ContainsKey(uniqueId))
                    return null;

                return _Nodes[uniqueId];
            }
        }

        /// <summary>
        /// Returns a Node object for the given unique id. If Graph object does not
        /// contain node with the given unique id, null is returned.
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

        //TODO:  Not sure yet how to implement this. Might only be viable for
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
            if (_Nodes.ContainsKey(uniqueId))
                throw new ArgumentException("Graph already contains node with unique ID " + uniqueId.ToString() + ".");

            INode<T> newNode = new Node<T>(uniqueId);
            _Nodes.Add(uniqueId, newNode);
            return newNode;
        }

        /// <summary>
        /// Removes a node from the Graph object with the given unique id. If graph does not
        /// contain the node with the given unique idm then ignore.
        /// </summary>
        /// <param name="uniqueId">Unique ID of node to be added.</param>
        public void RemoveNode(T uniqueId)
        {
            if (!_Nodes.ContainsKey(uniqueId))
                return;

            _Nodes.Remove(uniqueId);
        }
        #endregion

        #region Edges
        // Is this the best way for holding edges? 
        // Are tuples costly; better way to make unique key for pair of nodes?
        private IDictionary<Tuple<T,T>, List<IEdge<T>>> _Edges;

        /// <summary>
        /// Treat Graph object square indexing as a retrieval for edges. If graph does
        /// not contain either nodes or an edge between the given nodes, return null.
        /// </summary>
        /// <param name="srcId">The unique ID of the source node.</param>
        /// <param name="targId">The unique ID of the sink node.</param>
        /// <returns>IEdge Object</returns>
        public List<IEdge<T>> this[T srcId, T targId]
        {
            get
            {
                if (!_Nodes.ContainsKey(srcId) || !_Nodes.ContainsKey(targId))
                    return null;

                Tuple<T, T> pair = new Tuple<T, T>(srcId, targId);

                if (!_Edges.ContainsKey(pair))
                    return null;

                return _Edges[pair];
            }
        }

        /// <summary>
        /// Returns the edge(s) of the graph with given end nodes.
        /// </summary>
        /// <param name="srcId">The unique ID of the source node.</param>
        /// <param name="targId">The unique ID of the sink node.</param>
        /// <returns>IEdge Object</returns>
        public List<IEdge<T>> GetEdge(T srcId, T targId)
        {
            return this[srcId, targId];
        }

        /// <summary>
        /// Returns collection of Edges for Graph object.
        /// </summary>
        public IEnumerable<List<IEdge<T>>> Edges
        {
            get
            {
                return _Edges.Values;
            }
        }

        /// <summary>
        /// Returns the number of edges contained in Graph object.
        /// This count currently includes all parallel edges as well.
        /// Should we keep a private member that retains a count of edges so we don't have to compute all the time??
        /// </summary>
        public int EdgeCount
        {
            get
            {
                int count = 0;
                foreach (Tuple<T, T> pair in _Edges.Keys)
                    count += _Edges[pair].Count;
                return count;
            }
        }

        /// <summary>
        /// Adds a new edge. If an edge already exists in the Graph object for the given source
        /// and sink node, then add a parallel edge.
        /// </summary>
        /// <param name="fromUniqueId">The unique ID of the source node.</param>
        /// <param name="toUniqueId">The unique ID of the sink node.</param>
        /// <returns>IEdge Object</returns>
        public IEdge<T> AddEdge(T fromUniqueId, T toUniqueId)
        {
            // Do we wish to throw an error for non-existant nodes or create the nodes and edge?
            if (!_Nodes.ContainsKey(fromUniqueId))
                throw new ArgumentException("Graph does not contain a node with unique ID of " + fromUniqueId.ToString() + ".");
            else if  (!_Nodes.ContainsKey(toUniqueId))
                throw new ArgumentException("Graph does not contain a node with unique ID of " + toUniqueId.ToString() + ".");

            Tuple<T, T> pair = new Tuple<T, T>(fromUniqueId, toUniqueId);
            IEdge<T> newEdge = new Edge<T>(_Nodes[fromUniqueId], _Nodes[toUniqueId]);
            if (_Edges.ContainsKey(pair))
                _Edges[pair].Add(newEdge);
            else
                _Edges.Add(pair, new List<IEdge<T>>() { newEdge });
            return newEdge;
        }

        /// <summary>
        /// Adds a new edge. If an edge already exists in the Graph object for the given source
        /// and sink node, then add a parallel edge.
        /// </summary>
        /// <param name="srce">The source INode object.</param>
        /// <param name="target">The sink INode object.</param>
        /// <returns>IEdge Object</returns>
        public IEdge<T> AddEdge(INode<T> srce, INode<T> target)
        {
            // Do we wish to throw an error for non-existant nodes or create the nodes and edge?
            if (!_Nodes.ContainsKey(srce.UniqueId))
                throw new ArgumentException("Graph does not contain a node with unique ID of " + srce.UniqueId.ToString() + ".");
            else if (!_Nodes.ContainsKey(target.UniqueId))
                throw new ArgumentException("Graph does not contain a node with unique ID of " + target.UniqueId.ToString() + ".");

            Tuple<T, T> pair = new Tuple<T, T>(srce.UniqueId, target.UniqueId);
            IEdge<T> newEdge = new Edge<T>(srce, target);
            if (_Edges.ContainsKey(pair))
                _Edges[pair].Add(newEdge);
            else
                _Edges.Add(pair, new List<IEdge<T>>() { newEdge });
            return newEdge;
        }

        /// <summary>
        /// Removes the edge (and any parallel edges) from the Graph object.
        /// </summary>
        /// <param name="fromUniqueId">The unique ID of the source node.</param>
        /// <param name="toUniqueId">The unique ID of the sink node.</param>
        public void RemoveAllEdges(T fromUniqueId, T toUniqueId)
        {
            _Edges.Remove(new Tuple<T, T>(fromUniqueId, toUniqueId));
            // This removes it from the collection but does it free up the memory of the Edge object itself??
        }

        /// <summary>
        /// If the given edge is the only edge in the Graph object with the given
        /// source and sink nodes, remove <key,value> pair from Edges collection.
        /// Otherwise, remove only that particular edge from the list of parallel
        /// edges for the given source and sink nodes.
        /// </summary>
        /// <param name="edge">IEdge Object</param>
        public void RemoveEdge(IEdge<T> edge)
        {
            List<IEdge<T>> edges = this[edge.Source.UniqueId, edge.Sink.UniqueId];
            if (edges.Count == 1 && edges[0].Equals(edge))
                RemoveAllEdges(edge.Source.UniqueId, edge.Sink.UniqueId);
            else if (edges.Count > 1)
            {
                for(int i = 0; i < edges.Count; i++)
                    if (edges[i].Equals(edge))
                    {
                        edges.RemoveAt(i);
                        break;
                    }
            }
        }
        #endregion

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
