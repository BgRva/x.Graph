using System;
using System.Collections.Generic;

namespace x.Graph.Scenarios
{
    public interface IEdgeDataReader<T> : IDisposable
    {
        Dictionary<int, T> ReadFile(string fileName);
        Dictionary<int, T> ReadString(string fileContents);
    }
}
