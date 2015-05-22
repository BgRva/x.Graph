using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace x.Graph.Core
{
    public interface IEdge<T>
    {
        INode<T> Source { get; }
        INode<T> Sink { get; }
    }
}
