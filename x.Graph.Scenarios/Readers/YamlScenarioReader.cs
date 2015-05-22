using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace x.Graph.Scenarios.Readers
{
    public class YamlScenarioReader : IScenarioReader
    {
        public void Dispose()
        {
        }

        public Scenario ReadFile(string fileName)
        {
            Scenario scenario = null;

            var deserializer = new Deserializer(namingConvention: new CamelCaseNamingConvention());

            using (var sr = new StreamReader(fileName))
            {
                scenario = deserializer.Deserialize<Scenario>(sr);
            }

            return scenario;
        }

        public Scenario ReadString(string scenarioString)
        {
            Scenario scenario = null;

            var deserializer = new Deserializer(namingConvention: new CamelCaseNamingConvention());

            using (var sr = new StringReader(scenarioString))
            {
                scenario = deserializer.Deserialize<Scenario>(sr);
            }

            return scenario;
        }
    }

}
