using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Foguete.Collections;

namespace Desafio_Foguete.Search;
public static partial class Search
{
    public static bool BFSearch<T>(TreeNode<T> node, T goal)
    {
        var queue = new Queue<TreeNode<T>>();
        queue.Enqueue(node);

        while(queue.Count > 0)
        {
            var currNode = queue.Dequeue();
            if (EqualityComparer<T>.Default.Equals(currNode.Value, goal))
            return true;

            foreach (var child in currNode.Children)
                queue.Enqueue(child);
        }

        return false;
    }
}
