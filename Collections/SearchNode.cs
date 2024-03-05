using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Foguete.Collections;

public abstract class SearchNode<T, TNode> where TNode : INode<T>
{
    public TNode Node { get; set; }
    public abstract List<TNode> Neighbors();
    public bool IsSolution { get; set; } = false;
}
