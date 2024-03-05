using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Foguete.Collections;
using Microsoft.VisualBasic;

namespace Desafio_Foguete.Search;

public static partial class Search
{
    public static bool Dijkstra<T>(WeightedNode<T> start, WeightedNode<T> end)
    {
        var queue = new PriorityQueue<WeightedNode<T>, float>();
        var dist = new Dictionary<WeightedNode<T>, float>();
        var prev =  new Dictionary<WeightedNode<T>, WeightedNode<T>>();

        queue.Enqueue(start, 0);
        dist[start] = 0.0f;

        while (queue.Count > 0)
        {
            var currNode = queue.Dequeue();

            foreach (var edge in currNode.Neighbors)
            {
                var newWeight = dist[currNode] + edge.Weight;

                if (!dist.ContainsKey(edge.Node))
                {
                    dist[edge.Node] = float.PositiveInfinity;
                    prev[edge.Node] = null!;
                }

                if (newWeight < dist[edge.Node])
                {
                    dist[edge.Node] = newWeight;
                    prev[edge.Node] = currNode;
                    queue.Enqueue(edge.Node, newWeight);
                }
            }
        }

        var attempt = end;
        while (attempt != start)
        {
            if (!prev.ContainsKey(attempt))
                return false;
                
            attempt = prev[attempt];
        }

        return true;
    }
}