using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace x.Graph.Scenarios
{
    public class Scenario
    {
        public Scenario()
        {
            NodeRepresentations = new List<NodeRepresentation>();
            EdgeRepresentations = new List<EdgeRepresentation>();
        }

        public int Id
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        [YamlMember( Alias="node-count")]
        public int NodeCount
        {
            get;
            set;
        }

        [YamlMember( Alias="edge-count")]
        public int EdgeCount
        {
            get;
            set;
        }

        [YamlMember( Alias="nodes")]
        public List<NodeRepresentation> NodeRepresentations
        {
            get;
            set;
        }

        [YamlMember( Alias="edges")]
        public List<EdgeRepresentation> EdgeRepresentations
        {
            get;
            set;
        }
    }

}
