using Xunit;

namespace Range
{
    public class ValueTests
    {
        [Fact]
        public void ValidatesSingleValuedArray()
        {
            var array = new Value();
            Assert.True(array.Match("[\"Alin\"]").Success());
            Assert.Equal("", array.Match("[\"Alin\"]").RemainingText());
        }

        [Fact]
        public void ValidatesMultipleValuedArray()
        {
            var array = new Value();
            Assert.True(array.Match("[\"Alin\", \"Andrei\", \"George\"]").Success());
            Assert.Equal("", array.Match("[\"Alin\"]").RemainingText());
        }

        [Fact]
        public void ValidatesKeyValueTypedObject()
        {
            var obj = new Value();
            Assert.True(obj.Match("{\"ID\": \"SGML\"}").Success());
            Assert.Equal("", obj.Match("{\"ID\": \"SGML\"}").RemainingText());
        }

        [Fact]
        public void ValidatesKeyValueTypedObjectContainingAnArray()
        {
            var obj = new Value();
            Assert.True(obj.Match("{\"para\": \"A meta-markup language, used to create markup languages such as DocBook.\",\"GlossSeeAlso\": [\"GML\", \"XML\"]}").Success());
            Assert.Equal("", obj.Match("{\"para\": \"A meta-markup language, used to create markup languages such as DocBook.\",\"GlossSeeAlso\": [\"GML\", \"XML\"]}").RemainingText());
        }

        [Fact]
        public void ValidatesCompleteJsonFormat()
        {
            var obj = new Value();
            Assert.True(obj.Match("{\"menu\": {\"id\": \"file\",\"value\": \"File\",  \"popup\": " +
                "{\"menuitem\": [{\"value\": \"New\", \"onclick\": \"CreateNewDoc()\"}," +
                "{\"value\": \"Open\", \"onclick\": \"OpenDoc()\"},{\"value\": \"Close\", \"onclick\": \"CloseDoc()\"}]}}}").Success());
            Assert.Equal("", obj.Match("{\"menu\": {\"id\": \"file\",\"value\": \"File\",  \"popup\": " +
                "{\"menuitem\": [{\"value\": \"New\", \"onclick\": \"CreateNewDoc()\"}," +
                "{\"value\": \"Open\", \"onclick\": \"OpenDoc()\"},{\"value\": \"Close\", \"onclick\": \"CloseDoc()\"}]}}}").RemainingText());
        }
    }
}
