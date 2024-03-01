namespace Desafio_Foguete.Collections;

public class Tree<T>
{
    public TreeNode<T> Root { get; set; }
    public List<TreeNode<T>> Children => Root.Children;
    public Tree(TreeNode<T> root) => Root = root;
    public Tree(T value) => Root = new TreeNode<T>(value);

    public void AddBranch(Tree<T> branch)
        => Root.AddChild(branch.Root);

    public void RemoveBranch(Tree<T> branch)
        => Root.RemoveChild(branch.Root);

    
}