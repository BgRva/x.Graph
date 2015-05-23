using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace x.Graph.Core
{
    public interface IGraph<T>
    {
        INode<T> AddNode();
        INode<T> AddNode(T uniqueId);

        IEdge<T> AddEdge(T fromUniqueId, T toUniqueId);
        IEdge<T> AddEdge(INode<T> srce, INode<T> target);

        void RemoveNode(T uniqueId);

        void RemoveEdge(IEdge<T> edge);
        void RemoveAllEdges(T fromUniqueId, T toUniqueId);

        IEnumerable<INode<T>> Nodes { get; }
        IEnumerable<List<IEdge<T>>> Edges { get; }

        IEnumerable<INode<T>> TraverseBF(T uniqueId);
        IEnumerable<INode<T>> TraverseDF(T uniqueId);
        IEnumerable<INode<T>> TraverseBF(INode<T> root);
        IEnumerable<INode<T>> TraverseDF(INode<T> root);

        INode<T> GetNode(T uniqueId);
        INode<T> this[T uniqueId] { get; }


        List<IEdge<T>> GetEdge(T srcId, T targId);
        List<IEdge<T>> this[T srcId, T targId] { get; }

        int NodeCount { get; }
        int EdgeCount { get; }

        bool IsAcyclic { get; }
        bool IsConnected { get; }
    }
}
