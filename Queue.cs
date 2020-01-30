using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>

public class Queue
{
    private Node Head;
    private Node Tail;
    private int Count = 0;
    public Queue() { }
    public void Enqueue(int OrderID)
    {
        Node newNode = new Node(OrderID);
        if (Head == null)
        {
            Head = newNode;
            Tail = Head;
        }
        else
        {
            Tail.Next = newNode;
            Tail = Tail.Next;
        }
        Count++;
    }
    public int Dequeue()
    {
        if (Head == null)
        {
            throw new Exception("Nothing in queue.");
        }
        int Result = Head.OrderID;
        Head = Head.Next;
        return Result;
    }

    public int getCount()
    {
        return Count;
    }

    public List<Node> GetAllNodes()
    {
        var allNodes = new List<Node>();
        GetAllNodesRecursive(allNodes, Head);
        return allNodes;
    }

    private void GetAllNodesRecursive(List<Node> allNodes, Node node)
    {
        if (node == null)
        {
            return;
        }
        allNodes.Add(node);
        GetAllNodesRecursive(allNodes, node.Next);
    }
}


public class Node
{
    public int OrderID { get; set; }
    public Node Next { get; set; }
    public Node(int ID)
    {
        this.OrderID = ID;
    }
}


