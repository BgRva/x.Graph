using System;

namespace x.Graph.Scenarios
{
    public class Provider
    {
        public static IScenarioReader GetScenarioReader()
        {
            return new x.Graph.Scenarios.Readers.YamlScenarioReader();
        }

        public static INodeDataReader<T> GetNodeDataReader<T>()
        {
            return new x.Graph.Scenarios.Readers.YamlNodeDataReader<T>();
        }

        public static IEdgeDataReader<T> GetEdgeDataReader<T>()
        {
            return new x.Graph.Scenarios.Readers.YamlEdgeDataReader<T>();
        }
    }
}
