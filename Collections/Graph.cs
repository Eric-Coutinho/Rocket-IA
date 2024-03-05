using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Foguete.Collections;

public class Graph<T> : GraphNode<T>
{
    public List<GraphNode<T>> Nodes { get; set; }
    public Graph(T value, List<Node<T>> nodes = null!)
    { 
        Nodes == nodes ?? List<Node<T>>();
    }
}
