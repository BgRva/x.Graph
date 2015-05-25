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

    public class ArrayOfDoubles : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new double[] { 0.0, 3.03, -3.03, 0.00005, 10000};
        }
    }

    public class ArrayOfStrings : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new string[] { "", "blah", "Blah Blah", "xyz", "XYZ" };
        }
    }

    public class ArrayOfItems : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new DummyItem[] {
                new DummyItem(0, ""),
                new DummyItem(1, "B"),
                new DummyItem(2, "Z"),
                new DummyItem(4, "x"),
                new DummyItem(5, "X")
            };
        }
    }
}
