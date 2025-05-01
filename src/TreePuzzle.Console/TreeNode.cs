namespace TreePuzzle.Console;

public class TreeNode
{
    public string Value { get; set; }
    public List<TreeNode> Children { get; set; }

    public TreeNode(
        string value)
    {
        Value = value;
        Children = new List<TreeNode>();
    }

    public void AddChild(TreeNode child)
    {
        Children.Add(child);
    }

    public void AddChildren(List<TreeNode> children)
    {
        Children.AddRange(children);
    }
}