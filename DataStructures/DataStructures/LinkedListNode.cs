﻿namespace DataStructures
{
    public class LinkedListNode<T>
    {
        public LinkedListNode(T item)
        {
            Value = item;
        }

        public T Value { get; set; }

        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode<T> Previous { get; set; }
    }
}
