using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Foguete.Collections;

namespace Desafio_Foguete.Search;

public static partial class Search
{
    public static bool DFSearch<T>(TreeNode<T> node, T goal)
    {
        if (EqualityComparer<T>.Default.Equals(node.Value, goal))
            return true;
        
        foreach (var currNode in node.Children)
            if (DFSearch<T>(currNode, goal))
                return true;

        return false;
    }
}
