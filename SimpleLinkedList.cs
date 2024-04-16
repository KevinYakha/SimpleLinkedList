using System;
using System.Runtime.CompilerServices;
using System.Xml;

public class SimpleLinkedList<T>
{
    public int Count { get; private set; }
    private Node head;

    private interface INode
    {
        public T value { get; }
        public INode next { get; }
    }

    private class Node : INode
    {
        public T value { get; }
        public INode next { get; }

        public Node(T value, INode next)
        {
            this.value = value;
            this.next = next;
        }
    }
    
    public void Push(T value)
    {
        Count++;
        head = new Node(value, head);
    }

    public T Pop()
    {
        Count--;
        T value = head.value;
        head = (Node)head.next;
        return value;
        // no need to delete empty class or implement a destructor because of the garbage collector?
    }
}