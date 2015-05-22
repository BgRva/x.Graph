using x.Graph.Scenarios.Readers;

namespace x.Graph.Scenarios.Tests.Readers
{
    public class DataFileWrapper<T>
    {
        public INodeDataReader<T> GetNodeReader()
        {
            return new YamlNodeDataReader<T>();
        }

        public IEdgeDataReader<T> GetEdgeReader()
        {
            return new YamlEdgeDataReader<T>();
        }

        public DataFileWrapper() { }

        public DataFileWrapper(string fileName)
        {
            FileName = fileName;
        }

        public DataFileWrapper(int id)
        {
            Id = id;
        }

        public string FileName { get; set; }
        public int Id { get; set; }
    }
}
