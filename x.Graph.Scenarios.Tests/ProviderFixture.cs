using NUnit.Framework;
using x.Graph.Scenarios.Readers;

namespace x.Graph.Scenarios.Tests
{
    public class ProviderFixture
    {
        [TestFixture]
        public class GetScenarioReader
        {
            [Test]
            public void Returns_YamlScenarioReader()
            {
                //Arrange

                //Act    
                var reader = Provider.GetScenarioReader();

                //Assert
                Assert.NotNull(reader);
                Assert.IsInstanceOf<YamlScenarioReader>(reader);
            }
        }

        [TestFixture(typeof(double))]
        public class GetNodeDataReader<T>
        {
            [Datapoint]
            public double DataOfDouble = 0.0;

            [Theory]
            public void Returns_YamlNodeDataReader_of_T(T data)
            {
                //Arrange

                //Act    
                var reader = Provider.GetNodeDataReader<T>();

                //Assert
                Assert.NotNull(reader);
                Assert.IsInstanceOf<YamlNodeDataReader<T>>(reader);
            }
        }

        [TestFixture(typeof(double))]
        public class GetEdgeDataReader<T>
        {
            [Datapoint]
            public double DataOfDouble = 0.0;

            [Theory]
            public void Returns_YamlEdgeDataReader_of_T(T data)
            {
                //Arrange

                //Act    
                var reader = Provider.GetEdgeDataReader<T>();

                //Assert
                Assert.NotNull(reader);
                Assert.IsInstanceOf<YamlEdgeDataReader<T>>(reader);
            }
        }
    }
}
