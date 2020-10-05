using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DataStructures
{
    class DictionaryCollection<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly int[] buckets;

        private readonly Element<TKey, TValue>[] elements;

        private int freeIndex = -1;

        public DictionaryCollection(int dimension)
        {
            buckets = new int[dimension];
            Array.Fill(buckets, -1);
            elements = new Element<TKey, TValue>[dimension];
        }

        public ICollection<TKey> Keys
        {
            get
            {
                List<TKey> keys = new List<TKey>();
                foreach (var element in this)
                {
                    keys.Add(element.Key);
                }

                return keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                List<TValue> values = new List<TValue>();
                foreach (var element in this)
                {
                    values.Add(element.Value);
                }

                return values;
            }
        }

        public bool IsReadOnly { get => MakeReadOnly; }

        public bool MakeReadOnly { get; protected set; }

        public int Count { get; private set; }

        public TValue this[TKey key]
        {
            get
            {
                NullKeyException(key);
                int index = FindKeyPosition(key);
                if (index == -1)
                {
                    KeyNotFoundException(key);
                }

                return this.elements[index].Value;
            }

            set
            {
                IsReadonlyException();
                NullKeyException(key);
                int index = FindKeyPosition(key);
                if (index == -1)
                {
                    Add(key, value);
                }
                else
                {
                    this.elements[index].Value = value;
                }
            }
        }

        public void Add(TKey key, TValue value)
        {
            NullKeyException(key);
            IsReadonlyException();
            KeyAlreadyExistsException(key);
            KeyValuePair<TKey, TValue> pair = new KeyValuePair<TKey, TValue>(key, value);
            Add(pair);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            IsReadonlyException();
            Element<TKey, TValue> toAdd = new Element<TKey, TValue>(item.Key, item.Value);
            int bucketIndex = GetFirstPositionInBucket(item.Key);
            int emptyPosition = FindEmptyPostion();
            elements[emptyPosition] = toAdd;
            if (buckets[bucketIndex] != -1)
            {
                elements[emptyPosition].Next = buckets[bucketIndex];
            }

            buckets[bucketIndex] = emptyPosition;
            Count++;
        }

        public void Clear()
        {
            IsReadonlyException();
            Array.Fill(buckets, -1);
            Count = 0;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return ContainsKey(item.Key) && this[item.Key].Equals(item.Value);
        }

        public bool ContainsKey(TKey key)
        {
            NullKeyException(key);
            return FindKeyPosition(key) != -1;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ArgumentNullException(array);
            ArgumentException(array, arrayIndex);
            ArgumentOutOfRangeException(arrayIndex);
            elements.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int bucket = 0; bucket < buckets.Length; bucket++)
            {
                for (int elementIndex = buckets[bucket]; elementIndex != -1; elementIndex = elements[elementIndex].Next)
                {
                    yield return new KeyValuePair<TKey, TValue>(
                        elements[elementIndex].Key,
                        elements[elementIndex].Value);
                }
            }
        }

        public bool Remove(TKey key)
        {
            NullKeyException(key);
            IsReadonlyException();
            int index = FindKeyPosition(key, out int previous);
            if (index == -1)
            {
                return false;
            }

            if (previous == -1)
            {
                buckets[GetFirstPositionInBucket(key)] = elements[index].Next;
            }
            else
            {
                elements[previous].Next = elements[index].Next;
            }

            elements[index].Next = freeIndex;
            freeIndex = index;
            Count--;
            return true;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return elements[FindKeyPosition(item.Key)].Value.Equals(item.Value) && Remove(item.Key);
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            NullKeyException(key);

            if (FindKeyPosition(key) == -1)
            {
                value = default;
                return false;
            }

            value = this[key];
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public DictionaryCollection<TKey, TValue> ReadOnlyDictionary()
        {
            DictionaryCollection<TKey, TValue> newDictionary = new DictionaryCollection<TKey, TValue>(this.buckets.Length);
            foreach (var element in this)
            {
                newDictionary.Add(element);
            }

            newDictionary.MakeReadOnly = true;
            return newDictionary;
        }

        private int FindKeyPosition(TKey key)
        {
            return FindKeyPosition(key, out int previous);
        }

        private int FindKeyPosition(TKey key, out int previous)
        {
            int firstInBucket = GetFirstPositionInBucket(key);
            int bucketIndex = buckets[firstInBucket];
            previous = -1;
            while (bucketIndex != -1)
            {
                if (elements[bucketIndex].Key.Equals(key))
                {
                    return bucketIndex;
                }

                previous = bucketIndex;
                bucketIndex = elements[bucketIndex].Next;
            }

            return -1;
        }

        private int GetFirstPositionInBucket(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % elements.Length;
        }

        private int FindEmptyPostion()
        {
            if (freeIndex != -1)
            {
                int oldFreeIndex = freeIndex;
                freeIndex = elements[freeIndex].Next;
                return oldFreeIndex;
            }

            return Count;
        }

        private void KeyNotFoundException(TKey key)
        {
            if (FindKeyPosition(key) != -1)
            {
                return;
            }

            throw new KeyNotFoundException("key");
        }

        private void KeyAlreadyExistsException(TKey key)
        {
            if (!ContainsKey(key))
            {
                return;
            }

            throw new ArgumentException("An element with the same key already exists in the dictionary");
        }

        private void NullKeyException(TKey key)
        {
            if (key != null)
            {
                return;
            }

            throw new ArgumentNullException("key");
        }

        private void ArgumentException(KeyValuePair<TKey, TValue>[] array, int index)
        {
            if (array.Length - index >= Count)
            {
                return;
            }

            throw new ArgumentException("Destination array doesn't have enough space for the operation");
        }

        private void ArgumentOutOfRangeException(int index)
        {
            if (index >= 0)
            {
                return;
            }

            throw new ArgumentOutOfRangeException("index");
        }

        private void ArgumentNullException(KeyValuePair<TKey, TValue>[] array)
        {
            if (array != null)
            {
                return;
            }

            throw new ArgumentNullException("array");
        }

        private void IsReadonlyException()
        {
            if (!IsReadOnly)
            {
                return;
            }

            throw new NotSupportedException();
        }
    }
}
