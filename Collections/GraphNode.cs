using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Foguete.Collections;

public class GraphNode<T> : INode<T>
{
    public T Value { get; set; }
    public List<GraphNode<T>> Neighbors { get; set; }
    public int Connections => Neighbors.Count;

    public GraphNode
    (
        T value = default(T),
        List<GraphNode<T>> neighbors = null!
    )
    {
        Value = value;
        Neighbors = neighbors ?? new List<GraphNode<T>>();

        foreach (var neighbor in Neighbors)
            if (!neighbor.Neighbors.Contains(this))
                neighbor.Neighbors.Add(this);
    }

    public GraphNode<T> AddNode(GraphNode<T> graphNode)
    {
        if (!Neighbors.Contains(graphNode))
            Neighbors.Add(graphNode);
        if (!graphNode.Neighbors.Contains(this))
            graphNode.Neighbors.Add(this);

        return this;
    }

    public GraphNode<T> RemoveNode(GraphNode<T> graphNode)
    {
        Neighbors.Remove(graphNode);
        graphNode.Neighbors.Remove(this);

        return this;
    }
}
