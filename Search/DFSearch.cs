using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Foguete.Collections;

namespace Desafio_Foguete.Search;

public static partial class Search
{
    public static bool DFSearch<T, TNode>(SearchNode<T, TNode> node, T goal) where TNode : INode<T>
    {
        if (node.Visited)
            return false;

        node.Visited = true;

        if (EqualityComparer<T>.Default.Equals(node.Node.Value, goal))
        {
            node.IsSolution = true;
            return true;
        }

        return node.Neighbors().Any(neighbor => !neighbor.Visited && DFSearch<T, TNode>(neighbor, goal));
    }
}
