using Xunit;

namespace Range
{
    public class CharacterTests
    {
        [Fact]
        public void ValidatesStartingCharacter()
        {
            Assert.True(new Character('4').Match("4kdjsd").Success());
            Assert.Equal("kdjsd", new Character('4').Match("4kdjsd").RemainingText());
        }

        [Fact]
        public void InvalidatesStartingCharacter()
        {
            Assert.False(new Character('4').Match("5kdjsd").Success());
            Assert.Equal("5kdjsd", new Character('4').Match("5kdjsd").RemainingText());
        }
    }
}
