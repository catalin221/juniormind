using Xunit;

namespace DataStructures
{
    public class EnumeratorTests
    {
        [Fact]
        public void IterationTest()
        {
            var testArray = new List<int> { 1, 2, 3, 4 };
            var cloneTestArray = new List<int>();
            foreach (var obj in testArray)
            {
                cloneTestArray.Add(obj);
            }

            Assert.Equal(1, cloneTestArray[0]);
            Assert.Equal(2, cloneTestArray[1]);
            Assert.Equal(3, cloneTestArray[2]);
            Assert.Equal(4, cloneTestArray[3]);
        }
    }
}
