using YamlDotNet.Serialization;

namespace x.Graph.Scenarios
{
    public class EdgeRepresentation
    {
        public EdgeRepresentation()
        {
            Id = -1;
            SourceId = -1;
            TargetId = -1;
        }

        public int Id
        {
            get;
            set;
        }

        [YamlMember( Alias="source-id")]
        public int SourceId
        {
            get;
            set;
        }

        [YamlMember( Alias="target-id")]
        public int TargetId
        {
            get;
            set;
        }
    }

}
