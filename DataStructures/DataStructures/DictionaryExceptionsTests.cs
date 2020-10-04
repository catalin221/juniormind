using System;
using System.Collections.Generic;
using Xunit;

namespace DataStructures
{
    public class DictionaryExceptionsTests
    {
        [Fact]
        public void SetIndexNullKeyException()
        {
            var dictionary = new DictionaryCollection<int?, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");
            Assert.Throws<ArgumentNullException>(() => dictionary[null] = "f");
        }

        [Fact]
        public void GetIndexNullKeyException()
        {
            var dictionary = new DictionaryCollection<int?, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");
            Assert.Throws<ArgumentNullException>(() => dictionary[null] == "f");
        }

        [Fact]
        public void KeyNotFoundGetIndexException()
        {
            var dictionary = new DictionaryCollection<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");
            Assert.Throws<KeyNotFoundException>(() => dictionary[5] == "f");
        }

        [Fact]
        public void IsReadonlySetIndexException()
        {
            var dictionary = new DictionaryCollection<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");
            dictionary = dictionary.ReadOnlyDictionary();
            Assert.Throws<NotSupportedException>(() => dictionary[2] = "f");
        }

        [Fact]
        public void IsReadonlyAddException()
        {
            var dictionary = new DictionaryCollection<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");
            dictionary = dictionary.ReadOnlyDictionary();
            Assert.Throws<NotSupportedException>(() => dictionary.Add(13, "f"));
        }

        [Fact]
        public void NullKeyAddException()
        {
            var dictionary = new DictionaryCollection<int?, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");
            Assert.Throws<ArgumentNullException>(() => dictionary.Add(null, "f"));
        }

        [Fact]
        public void KeyAlreadyInListAddException()
        {
            var dictionary = new DictionaryCollection<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");
            Assert.Throws<ArgumentException>(() => dictionary.Add(1, "f"));
        }

        [Fact]
        public void ReadOnlyAddPairException()
        {
            var dictionary = new DictionaryCollection<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");
            dictionary = dictionary.ReadOnlyDictionary();
            KeyValuePair<int, string> pair = new KeyValuePair<int, string>(13, "f");
            Assert.Throws<NotSupportedException>(() => dictionary.Add(pair));
        }

        [Fact]
        public void ReadOnlyClearException()
        {
            var dictionary = new DictionaryCollection<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");
            dictionary = dictionary.ReadOnlyDictionary();
            Assert.Throws<NotSupportedException>(() => dictionary.Clear());
        }

        [Fact]
        public void NullKeyContainsKeyException()
        {
            var dictionary = new DictionaryCollection<int?, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");
            Assert.Throws<ArgumentNullException>(() => dictionary.ContainsKey(null));
        }

        [Fact]
        public void NullKeyRemoveException()
        {
            var dictionary = new DictionaryCollection<int?, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");
            Assert.Throws<ArgumentNullException>(() => dictionary.Remove(null));
        }

        [Fact]
        public void ReadOnlyRemoveException()
        {
            var dictionary = new DictionaryCollection<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");
            dictionary = dictionary.ReadOnlyDictionary();
            Assert.Throws<NotSupportedException>(() => dictionary.Remove(2));
        }

        [Fact]
        public void NullKeyTryGetValueException()
        {
            var dictionary = new DictionaryCollection<int?, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");
            Assert.Throws<ArgumentNullException>(() => dictionary.TryGetValue(null, out string value));
        }
    }
}
