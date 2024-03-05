namespace Desafio_Foguete.Collections;

public class SearchWeightedNode<T> : SearchNode<T, WeightedNode<T>>
{
    public SearchWeightedNode(WeightedNode<T> node) : base(node) { }

    public override List<SearchNode<T, WeightedNode<T>>> Neighbors()
    {
        var neighbors = new List<SearchNode<T, WeightedNode<T>>>(Node.Neighbors.Count);
        neighbors.AddRange(Node.Neighbors.Select(neighbor => new SearchWeightedNode<T>(neighbor.Node)));

        return neighbors;

    }



}