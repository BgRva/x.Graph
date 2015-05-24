using System.Collections;

namespace x.Graph.Core.Tests.Support
{
    /// <summary>
    /// DummyItem is a class used to test various generic functionality
    /// that require an object rather than a primitive type
    /// </summary>
    public class DummyItem
    {
        public DummyItem() { }

        public DummyItem(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            if (Name == null)
                return string.Format("{0};null", Id);
            return string.Format("{0};{1}", Id, Name);
        }
    }
}
