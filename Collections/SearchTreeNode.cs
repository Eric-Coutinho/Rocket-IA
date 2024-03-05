using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Foguete.Collections;

public class SearchTreeNode<T> : SearchNode<T, TreeNode<T>>
{
    public SearchTreeNode(TreeNode<T> node) : base(node) { }

    public override List<SearchNode<T, TreeNode<T>>> Neighbors()
    {
        var neighbours = new List<SearchNode<T, TreeNode<T>>>(Node.Children.Count);
        neighbours.AddRange(Node.Children.Select(child => new SearchTreeNode<T>(child)));

        return neighbours;
    }
}
