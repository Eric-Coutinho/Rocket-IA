using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Foguete.Collections;
public class SearchGraphNode<T> : SearchNode<T, GraphNode<T>>
{
    public SearchGraphNode(GraphNode<T> node) : base(node) { }

    public override List<SearchNode<T, GraphNode<T>>> Neighbors()
    {
        var neighbors = new List<SearchNode<T, GraphNode<T>>>(Node.Neighbors.Count);
        neighbors.AddRange(Node.Neighbors.Select(neighbor => new SearchGraphNode<T>(neighbor)));

        return neighbors;
    }
}