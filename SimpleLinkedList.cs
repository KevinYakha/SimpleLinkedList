using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Transactions;
using System.Xml;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    public int Count { get; private set; }
    private Node head;

    public SimpleLinkedList() { }
    public SimpleLinkedList(int value) { Push(value); }
    public SimpleLinkedList(int[] values) { foreach(int value in values) Push(value); }

    private interface INode
    {
        public int value { get; }
        public INode next { get; }
    }

    private class Node : INode
    {
        public int value { get; }
        public INode next { get; }

        public Node(int value, INode next)
        {
            this.value = value;
            this.next = next;
        }
    }
    
    public void Push(int value)
    {
        Count++;
        head = new Node(value, head);
    }

    public int Pop()
    {
        Count--;
        int value = head.value;
        head = (Node)head.next;
        return value;
        // no need to delete empty class or implement a destructor because of the garbage collector?
    }

    public void Reverse()
    {
        Node[] nodes = new Node[Count];
        Node current = head;
        for (int i = 0; i < Count; i++)
        {
            nodes[i] = current;
            current = (Node)current.next;
        }

        head = nodes[Count - 1];
        int oldCount = Count;
        Count = 1;
        for (int i = oldCount - 1; i > 0; i--)
        {
            Push(nodes[i].value);
        }
    }

    public IEnumerator<int> GetEnumerator()
    {
        Node current = head;
        for (int i = 0; i < Count; i++)
        {
            int value = current.value;
            current = (Node)current.next;
            yield return value;
        }
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    IEnumerator<T> IEnumerable<T>.GetEnumerator() => (IEnumerator<T>)GetEnumerator();
}