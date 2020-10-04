using System.Collections.Generic;
using Xunit;

namespace DataStructures
{
    public class DictionaryCollectionTests
    {
        [Fact]
        public void AddTest()
        {
            var pair = new KeyValuePair<int, int>(4, 2);
            var dict = new DictionaryCollection<int, int>(4);
            dict.Add(pair);
            Assert.Single(dict);
        }

        [Fact]
        public void SetIndexerTest()
        {
            var dictionary = new DictionaryCollection<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");
            dictionary[1] = "f";
            Assert.Equal("f", dictionary[1]);
        }

        [Fact]
        public void GetIndexerTest()
        {
            var dictionary = new DictionaryCollection<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");
            Assert.Equal("a", dictionary[1]);
        }

        [Fact]
        public void CointainsTest()
        {
            var dictionary = new DictionaryCollection<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");
            KeyValuePair<int, string> toFind = new KeyValuePair<int, string>(2, "b");
            Assert.Contains(toFind, dictionary);
        }

        [Fact]
        public void ContainsKeyTest()
        {
            var dictionary = new DictionaryCollection<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");
            Assert.True(dictionary.ContainsKey(7));
        }

        [Fact]
        public void GetKeysTest()
        {
            var dict = new DictionaryCollection<string, int>(5);
            dict.Add(new KeyValuePair<string, int>("Cat", 1));
            dict.Add(new KeyValuePair<string, int>("Dog", 2));
            dict.Add(new KeyValuePair<string, int>("Rabbit", 4));
            ICollection<string> keysList = dict.Keys;
            Assert.Equal(3, keysList.Count);
        }

        [Fact]
        public void GetValuesTest()
        {
            var dict = new DictionaryCollection<string, int>(5);
            dict.Add(new KeyValuePair<string, int>("Cat", 1));
            dict.Add(new KeyValuePair<string, int>("Dog", 2));
            dict.Add(new KeyValuePair<string, int>("Rabbit", 4));
            ICollection<int> valueList = dict.Values;
            Assert.Equal(3, valueList.Count);
        }

        [Fact]
        public void RemoveTest()
        {
            var dictionary = new DictionaryCollection<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");
            dictionary.Remove(2);
            Assert.False(dictionary.ContainsKey(2));
        }

        [Fact]
        public void RemovePairTest()
        {
            var dictionary = new DictionaryCollection<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");
            KeyValuePair<int, string> pair = new KeyValuePair<int, string>(2, "b");
            dictionary.Remove(pair);
            Assert.False(dictionary.ContainsKey(2));
        }

        [Fact]
        public void RemoveFirstPairTest()
        {
            var dictionary = new DictionaryCollection<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");
            KeyValuePair<int, string> pair = new KeyValuePair<int, string>(1, "a");
            dictionary.Remove(pair);
            Assert.False(dictionary.ContainsKey(1));
        }

        [Fact]
        public void RemoveLastPairTest()
        {
            var dictionary = new DictionaryCollection<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");
            KeyValuePair<int, string> pair = new KeyValuePair<int, string>(12, "e");
            dictionary.Remove(pair);
            Assert.False(dictionary.ContainsKey(12));
        }

        [Fact]
        public void RemoveThenAddOnEmptySpaceTest()
        {
            var dictionary = new DictionaryCollection<int, string>(5);
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");
            KeyValuePair<int, string> pair = new KeyValuePair<int, string>(2, "b");
            dictionary.Remove(pair);
            dictionary.Add(5, "b");
            Assert.Contains(5, dictionary);
        }
    }
}
