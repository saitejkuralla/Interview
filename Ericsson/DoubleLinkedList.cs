using System;

public class DLLImplementation
{
    public static void Main()
    {
        DoubleLinkedList oDoubleLinkedList = new DoubleLinkedList();
        oDoubleLinkedList.Insert(10);
        oDoubleLinkedList.Insert(20);
        oDoubleLinkedList.Insert(30);

    }
}

public class DoubleLinkedList
{
    public Node Head;
    public Node Tail;
    public void Insert(int Value)
    {
        if (Head == null)
        {
            Head = new Node(Value);
        }
        else
        {
            Node newNode = new Node(Value);
            Head.next = newNode;
            newNode.previous = Head;            
        }
    }
}


public class Node
{
    public int Value;
    public Node next;
    public Node previous;

    public Node(int _value)
    {
        Value = _value;
    }

}