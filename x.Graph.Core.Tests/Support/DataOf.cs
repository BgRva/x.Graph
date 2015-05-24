using System.Collections;

namespace x.Graph.Core.Tests.Support
{
    public class DataOfDouble : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return 0.0;
            yield return 33.003;
        }
    }

    public class DataOfString : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return "";
            yield return "blah";
        }
    }

    public class DataOfItem : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new DummyItem(0, "");
            yield return new DummyItem(3, "BLAH");
        }
    }
}
