using NUnit.Framework;
using System.Linq;
using x.Graph.Scenarios.Readers;

namespace x.Graph.Scenarios.Tests.Readers
{
    public class YamlScenarioReaderFixture
    {
        [TestFixture]
        public class ReadString
        {
            [TestCase(1)]
            public void Returns_Scenario(int scenarioId)
            {
                //Arrange
                var reader = new YamlScenarioReader();
                var scenarioData = x.Graph.Scenarios.Files.DataProvider.GetScenario(scenarioId);
                
                //Act    
                var scenario = reader.ReadString(scenarioData);

                //Assert
                Assert.NotNull(scenario);
                Assert.AreEqual(scenario.NodeCount, scenario.NodeRepresentations.Count);
                Assert.AreEqual(scenario.EdgeCount, scenario.EdgeRepresentations.Count);
            }
        }
    }
}
