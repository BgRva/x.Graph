using NUnit.Framework;
using System.Linq;

namespace x.Graph.Scenarios.Tests.Readers
{
    public class YamlEdgeDataReaderFixture
    {
        [TestFixture(typeof(double))]
        public class ReadString<T>
        {
            [Datapoints]
            public DataFileWrapper<double>[] DataFilesOfDouble = new[]
                {
                  new DataFileWrapper<double>(1),
                };

            [Theory]
            public void Returns_Dictionary_Of_Node_Data(DataFileWrapper<T> dataFile)
            {
                //Arrange
                var fileData = x.Graph.Scenarios.Files.DataProvider.GetEdgeData<T>(dataFile.Id);
                var reader = dataFile.GetEdgeReader();

                //Act    
                var data = reader.ReadString(fileData);

                //Assert
                Assert.NotNull(data);

                var maxKey = (data.Keys.Select(k => k)).Max();

                Assert.AreEqual(data.Count, maxKey + 1);
            }
        }
    }
}
