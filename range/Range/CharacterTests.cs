using Xunit;

namespace Range
{
    public class CharacterTests
    {
        [Fact]
        public void ValidatesStartingCharacter()
        {
            Assert.True(new Character('4').Match("4kdjsd"));
        }

        [Fact]
        public void InvalidatesStartingCharacter()
        {
            Assert.False(new Character('4').Match("5kdjsd"));
        }
    }
}
