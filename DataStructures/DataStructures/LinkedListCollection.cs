using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class LinkedListCollection<T> : ICollection<T>
    {
        public LinkedListCollection()
        {
            CreateSentinel();
        }

        public LinkedListCollection(T[] data)
        {
            CreateSentinel();
            ArrayNullException(data);
            foreach (var x in data)
            {
                Add(x);
            }
        }

        public LinkedListNode<T> Sentinel { get; set; }

        public int Count { get; private set;  }

        public bool IsReadOnly { get => MakeReadOnly; }

        public bool MakeReadOnly { get; protected set; }

        public void Add(T item)
        {
            LinkedListNode<T> toAdd = new LinkedListNode<T>(item);
            Add(toAdd);
        }

        public void Add(LinkedListNode<T> node)
        {
            IsReadonlyException();
            NullNodeException(node);
            AlreadyInListException(node.Value);
            AddBefore(Sentinel, node.Value);
        }

        public void AddFirst(T item)
        {
            LinkedListNode<T> toAdd = new LinkedListNode<T>(item);
            AddFirst(toAdd);
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            IsReadonlyException();
            NullNodeException(node);
            AlreadyInListException(node.Value);
            AddAfter(Sentinel, node.Value);
        }

        public void AddBefore(LinkedListNode<T> node, T item)
        {
            NullNodeException(node);
            GenericAddExceptions(item);
            LinkedListNode<T> toAdd = new LinkedListNode<T>(item);

            // linking nodes
            node.Previous.Next = toAdd;
            toAdd.Previous = node.Previous;
            node.Previous = toAdd;
            toAdd.Next = node;
            Count++;
        }

        public void AddAfter(LinkedListNode<T> node, T item)
        {
            NullNodeException(node);
            GenericAddExceptions(item);
            LinkedListNode<T> toAdd = new LinkedListNode<T>(item);

            // linking nodes
            node.Next.Previous = toAdd;
            toAdd.Next = node.Next;
            node.Next = toAdd;
            toAdd.Previous = node;
            Count++;
        }

        public void Clear()
        {
            Sentinel = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public LinkedListNode<T> Find(T item)
        {
           for (LinkedListNode<T> current = Sentinel.Next; current != Sentinel; current = current.Next)
            {
                if (current.Value.Equals(item))
                {
                    return current;
                }
            }

           return null;
        }

        public LinkedListNode<T> FindLast(T item)
        {
            for (LinkedListNode<T> current = Sentinel.Previous; current != Sentinel; current = current.Previous)
            {
                if (current.Value.Equals(item))
                {
                    return current;
                }
            }

            return null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ArrayNullException(array);
            NegativeIndexException(arrayIndex);
            ArgumentException(array, arrayIndex);
            int index = 0;
            for (LinkedListNode<T> current = Sentinel.Next; current != Sentinel; current = current.Next)
            {
                array[index] = current.Value;
                index++;
            }
        }

        public bool Remove(T item)
        {
            IsReadonlyException();
            for (LinkedListNode<T> current = Sentinel.Next; current != Sentinel; current = current.Next)
            {
                if (current.Value.Equals(item))
                {
                    if (current.Next == Sentinel)
                    {
                        RemoveLast();
                    }
                    else
                    {
                        current.Next.Previous = current.Previous;
                    }

                    if (current.Previous == Sentinel)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                    }

                    Count--;
                    return true;
                }
            }

            return false;
        }

        public void RemoveLast()
        {
            IsReadonlyException();
            if (Sentinel.Previous == Sentinel)
            {
                return;
            }

            LinkedListNode<T> last = Sentinel.Previous;
            last = last.Previous;
            last.Next = null;
            last.Next = Sentinel;
            Sentinel.Previous = last;
            Count--;
        }

        public void RemoveFirst()
        {
            IsReadonlyException();
            if (Sentinel.Next == Sentinel)
            {
                return;
            }

            LinkedListNode<T> first = Sentinel.Next;
            first = first.Next;
            first.Previous = null;
            first.Previous = Sentinel;
            Sentinel.Next = first;
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (LinkedListNode<T> current = Sentinel.Next; current != Sentinel; current = current.Next)
            {
                yield return current.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void GenericAddExceptions(T item)
        {
            IsReadonlyException();
            AlreadyInListException(item);
            NullItemException(item);
        }

        private void CreateSentinel()
        {
            Sentinel = new LinkedListNode<T>(default);
            Sentinel.Next = Sentinel;
            Sentinel.Previous = Sentinel;
        }

        private void NullItemException(T item)
        {
            if (item != null)
            {
                return;
            }

            throw new ArgumentNullException("item");
        }

        private void NullNodeException(LinkedListNode<T> node)
        {
            if (node != null)
            {
                return;
            }

            throw new ArgumentNullException("node");
        }

        private void ArgumentException(T[] array, int index)
        {
            if (array.Length - index >= Count)
            {
                return;
            }

            throw new ArgumentException("Destination array doesn't have enough space for the operation");
        }

        private void NegativeIndexException(int index)
        {
            if (index >= 0)
            {
                return;
            }

            throw new ArgumentOutOfRangeException("index");
        }

        private void ArrayNullException(T[] array)
        {
            if (array != null)
            {
                return;
            }

            throw new ArgumentNullException("array");
        }

        private void AlreadyInListException(T item)
        {
            if (!Contains(item))
            {
                return;
            }

            throw new InvalidOperationException("item");
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