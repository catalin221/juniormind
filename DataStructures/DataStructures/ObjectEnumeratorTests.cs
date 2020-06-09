using Xunit;

namespace DataStructures
{
    public class ObjectEnumeratorTests
    {
        [Fact]
        public void TestEnumerator()
        {
            var test = new ObjArrayCollection { 1, "Eu", 4.5, true, false, 'a' };
            var enumerator = test.GetEnumerator();

            enumerator.MoveNext();
            Assert.Equal(1, enumerator.Current());
            enumerator.MoveNext();
            Assert.Equal("Eu", enumerator.Current());

            enumerator.Reset();
            for (int i = 0; i < test.Count; i++)
            {
                enumerator.MoveNext();
            }

            Assert.Equal('a', enumerator.Current());
        }
    }
}
