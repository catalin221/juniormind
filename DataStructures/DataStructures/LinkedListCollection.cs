using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class LinkedListCollection<T> : ICollection<T>
    {
        private LinkedListNode<T> sentinel = new LinkedListNode<T>(default);

        public LinkedListCollection()
        {
            sentinel.Next = sentinel;
            sentinel.Previous = sentinel;
        }

        public LinkedListCollection(T[] data)
        {
            sentinel.Next = sentinel;
            sentinel.Previous = sentinel;
            ArrayNullException(data);
            foreach (var x in data)
            {
                Add(x);
            }
        }

        public int Count { get; private set; }

        public bool IsReadOnly { get => MakeReadOnly; }

        public bool MakeReadOnly { get; protected set; }

        public LinkedListNode<T> GetFirst()
        {
            return sentinel.Next;
        }

        public LinkedListNode<T> GetLast()
        {
            return sentinel.Previous;
        }

        public LinkedListNode<T> GetSentinel()
        {
            return sentinel;
        }

        public void Add(T item)
        {
            AddLast(item);
        }

        public void AddLast(T item)
        {
            LinkedListNode<T> toAdd = new LinkedListNode<T>(item);
            AddLast(toAdd);
        }

        public void AddLast(LinkedListNode<T> node)
        {
            IsReadonlyException();
            NullNodeException(node);
            AlreadyInListException(node.Value);
            AddBefore(sentinel, node.Value);
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
            AddAfter(sentinel, node.Value);
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
            AddBefore(node.Next, item);
        }

        public LinkedListCollection<T> ReadOnlyList()
        {
            LinkedListCollection<T> newList = new LinkedListCollection<T>();
            foreach (var element in this)
            {
                newList.Add(element);
            }

            newList.MakeReadOnly = true;
            return newList;
        }

        public void Clear()
        {
            IsReadonlyException();
            sentinel = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public LinkedListNode<T> Find(T item)
        {
           for (LinkedListNode<T> current = sentinel.Next; current != sentinel; current = current.Next)
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
            for (LinkedListNode<T> current = sentinel.Previous; current != sentinel; current = current.Previous)
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
            for (LinkedListNode<T> current = sentinel.Next; current != sentinel; current = current.Next)
            {
                array[index] = current.Value;
                index++;
            }
        }

        public bool Remove(T item)
        {
            IsReadonlyException();
            for (LinkedListNode<T> current = sentinel.Next; current != sentinel; current = current.Next)
            {
                if (current.Value.Equals(item))
                {
                    if (current.Next == sentinel)
                    {
                        RemoveLast();
                    }
                    else
                    {
                        current.Next.Previous = current.Previous;
                    }

                    if (current.Previous == sentinel)
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
            if (sentinel.Previous == sentinel)
            {
                return;
            }

            LinkedListNode<T> last = sentinel.Previous;
            last = last.Previous;
            last.Next = null;
            last.Next = sentinel;
            sentinel.Previous = last;
            Count--;
        }

        public void RemoveFirst()
        {
            IsReadonlyException();
            if (sentinel.Next == sentinel)
            {
                return;
            }

            LinkedListNode<T> first = sentinel.Next;
            first = first.Next;
            first.Previous = null;
            first.Previous = sentinel;
            sentinel.Next = first;
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (LinkedListNode<T> current = sentinel.Next; current != sentinel; current = current.Next)
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