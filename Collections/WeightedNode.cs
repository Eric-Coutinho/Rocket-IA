using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Foguete.Collections;

public class WeightedNode<T> : INode<T>
{
    public T Value { get; set; }
    public List<Edge<T>> Neighbors { get; set; }
    public int Connections => Neighbors.Count;

    public WeightedNode
    (
        T value = default(T),
        List<Edge<T>> neighbors = null!
    )
    {
        Value = value;
        Neighbors = neighbors ?? new List<Edge<T>>();
    }

    public WeightedNode<T> AddNode(Edge<T> edge)
    {
        Neighbors.Add(edge);
        return this;
    }

    public WeightedNode<T> AddNode(WeightedNode<T> node, float weight)
    {
        Neighbors.Add(new Edge<T>(node, weight));
        return this;
    }

    public WeightedNode<T> RemoveNode(WeightedNode<T> node)
    {
        Neighbors.RemoveAll(edge => edge.Node == node); //* Função mudada meu nobre

        return this;
    }
}
