using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class LinkedListCollection<T> : ICollection<T>
    {
        public LinkedListCollection()
        {
            Head = null;
            Tail = null;
        }

        public LinkedListCollection(T[] data)
        {
            ArrayNullException(data);
            foreach (var x in data)
            {
                Add(x);
            }
        }

        public LinkedListNode<T> Head { get; set; }

        public LinkedListNode<T> Tail { get; set; }

        public int Count { get; private set;  }

        public bool IsReadOnly { get => MakeReadOnly; }

        public bool MakeReadOnly { get; protected set; }

        public void Add(T item)
        {
            AlreadyInListException(item);
            IsReadonlyException();
            LinkedListNode<T> toAdd = new LinkedListNode<T>(item);
            Add(toAdd);
        }

        public void Add(LinkedListNode<T> node)
        {
            IsReadonlyException();
            NullNodeException(node);
            if (Tail == null)
            {
                Head = node;
            }
            else
            {
                node.Previous = Tail;
                Tail.Next = node;
            }

            Tail = node;
            Head.Previous = Tail;
            Tail.Next = Head;
            Count++;
        }

        public void AddFirst(T item)
        {
            IsReadonlyException();
            AlreadyInListException(item);
            NullItemException(item);
            LinkedListNode<T> toAdd = new LinkedListNode<T>(item);
            AddFirst(toAdd);
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            IsReadonlyException();
            NullNodeException(node);
            if (Head == null)
            {
                Tail = node;
            }
            else
            {
                node.Next = Head;
                Head.Previous = node;
            }

            Head = node;
            Head.Previous = Tail;
            Tail.Next = Head;
            Count++;
        }

        public void AddBefore(LinkedListNode<T> node, T item)
        {
            IsReadonlyException();
            AlreadyInListException(item);
            NullNodeException(node);
            NullItemException(item);
            LinkedListNode<T> toAdd = new LinkedListNode<T>(item);
            if (node == Head)
            {
                AddFirst(node);
                return;
            }

            // linking nodes
            node.Previous.Next = toAdd;
            toAdd.Previous = node.Previous;
            node.Previous = toAdd;
            toAdd.Next = node;
            Count++;
        }

        public void AddAfter(LinkedListNode<T> node, T item)
        {
            IsReadonlyException();
            AlreadyInListException(item);
            NullNodeException(node);
            LinkedListNode<T> toAdd = new LinkedListNode<T>(item);
            if (node == Tail)
            {
                Add(node);
                return;
            }

            // linking nodes
            node.Next.Previous = toAdd;
            toAdd.Next = node.Next;
            node.Next = toAdd;
            toAdd.Previous = node;
            Count++;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public LinkedListNode<T> Find(T item)
        {
            if (Head == null)
            {
                return null;
            }

            LinkedListNode<T> current = Head;
            while (current.Next != Head)
            {
                if (current.Value.Equals(item))
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }

        public LinkedListNode<T> FindLast(T item)
        {
            LinkedListNode<T> current = Tail;
            while (current.Previous != Tail)
            {
                if (current.Value.Equals(item))
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ArrayNullException(array);
            NegativeIndexException(arrayIndex);
            ArgumentException(array, arrayIndex);
            LinkedListNode<T> current = Head;
            int index = 0;
            while (current.Next != Head)
            {
                array[index] = current.Value;
                current = current.Next;
                index++;
            }

            array[index] = Tail.Value;
        }

        public bool Remove(T item)
        {
            IsReadonlyException();
            LinkedListNode<T> current = Head;
            while (current.Next != Head)
            {
                if (current.Value.Equals(item))
                {
                    if (current.Next == Head)
                    {
                        RemoveLast();
                    }
                    else
                    {
                        current.Next.Previous = current.Previous;
                    }

                    if (current.Previous == Tail)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                    }

#pragma warning disable S1854 // Unused assignments should be removed
                    current = null;
#pragma warning restore S1854 // Unused assignments should be removed
                    Count--;
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void RemoveLast()
        {
            IsReadonlyException();
            if (Tail == null)
            {
                Head = null;
                return;
            }

            Tail = Tail.Previous;
            Tail.Next = null;
            Head.Previous = Tail;
            Tail.Next = Head;
            Count--;
        }

        public void RemoveFirst()
        {
            IsReadonlyException();
            if (Head == null)
            {
                Tail = null;
                return;
            }

            Head = Head.Next;
            Head.Previous = null;
            Tail.Next = Head;
            Head.Previous = Tail;
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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