using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace x.Graph.Scenarios.Readers
{
    public class YamlNodeDataReader<T> : INodeDataReader<T>
    {
        public void Dispose()
        {
        }

        public Dictionary<int, T> ReadFile(string fileName)
        {
            var data = new Dictionary<int, T>();

            var deserializer = new Deserializer(namingConvention: new CamelCaseNamingConvention());

            using (var sr = new StreamReader(fileName))
            {
                data = deserializer.Deserialize<Dictionary<int, T>>(sr);
            }

            return data;
        }

        public Dictionary<int, T> ReadString(string fileContents)
        {
            var data = new Dictionary<int, T>();

            var deserializer = new Deserializer(namingConvention: new CamelCaseNamingConvention());

            using (var sr = new StringReader(fileContents))
            {
                data = deserializer.Deserialize<Dictionary<int, T>>(sr);
            }

            return data;
        }
    }
}
