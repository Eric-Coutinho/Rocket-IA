using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Foguete.Collections;

public class Node<T> : INode<T>
{
    public T Value { get; set; }
    public List<Node<T>> Neighbors { get; set; }
    public int Connections => Neighbors.Count;

    public Node(T value = default(T), List<Node<T>> neighbors = null!)
    {
        Value = value;
        Neighbors = neighbors ?? new List<Node<T>>();

        foreach (var neighbor in Neighbors)
            neighbor.Neighbors.Add(this);
    }

    public Node<T> AddNode(Node<T> node)
    {
        Neighbors.Add(node);
        node.Neighbors.Add(this);

        return this;
    }

    public Node<T> RemoveNode(Node<T> node)
    {
        Neighbors.Remove(node);
        node.Neighbors.Remove(this);

        return this;
    }
}
