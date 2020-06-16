using Xunit;

namespace DataStructures
{
    public class EnumeratorTests
    {
        [Fact]
        public void IterationTest()
        {
            var testArray = new ObjArrayCollection { 1, "Andrei", 'a', 3.5 };
            var cloneTestArray = new ObjArrayCollection();
            foreach (var obj in testArray)
            {
                cloneTestArray.Add(obj);
            }

            Assert.Equal(1, cloneTestArray[0]);
            Assert.Equal("Andrei", cloneTestArray[1]);
            Assert.Equal('a', cloneTestArray[2]);
            Assert.Equal(3.5, cloneTestArray[3]);
        }
    }
}
