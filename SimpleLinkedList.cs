using System;
using System.Runtime.CompilerServices;
using System.Xml;

public class SimpleLinkedList<T>
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
}