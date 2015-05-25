using System.Collections.Generic;

namespace x.Graph.Core
{
    public interface INode<T>
    {
        T UniqueId { get; }

        void AddIncomingEdge(IEdge<T> incomingEdge);
        void AddOutgoingEdge(IEdge<T> outgoingEdge);
        void AddSelfLoop(IEdge<T> edge);

        IEnumerable<IEdge<T>> IncomingEdges { get; }
        IEnumerable<IEdge<T>> OutgoingEdges { get; }
        IEnumerable<IEdge<T>> SelfLoops { get; }

        IEnumerable<INode<T>> Successors { get; }
        IEnumerable<INode<T>> Predecessors { get; }
    }
}
