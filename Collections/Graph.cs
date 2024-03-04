using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_Foguete.Collections;

public class Graph<T> : Node<T>
{
    public Graph(T value, List<Node<T>> neighbors = null!) : base(value, neighbors) {  }
}
