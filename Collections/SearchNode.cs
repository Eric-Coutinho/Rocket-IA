using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Foguete.Collections;

public abstract class SearchNode<T, TNode> where TNode : INode<T>
{
    public TNode Node { get; set; }
    public abstract List<SearchNode<T, TNode>> Neighbors();
    public bool Visited { get; set; } = false;
    public bool IsSolution { get; set; } = false;

    public SearchNode(TNode node) => Node = node;

    public void Reset()
    {
        Visited = false;
        IsSolution = false;
    }
}