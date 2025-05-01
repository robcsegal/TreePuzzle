using System.Text;

namespace TreePuzzle.Console;

public static class Tree
{
    /// <summary>
    /// Parse input section by section by parenthesis using basic recursive tree logic
    /// </summary>
    /// <param name="inputToParse">input value to parse</param>
    /// <param name="parseIndex">index to continue processing from</param>
    /// <returns></returns>
    public static List<TreeNode> Parse(string inputToParse, ref int parseIndex)
    {
        List<TreeNode> treeNodes = new List<TreeNode>();
        char[] otherChars = [',', '(', ')'];
        StringBuilder word = new StringBuilder();
        while (parseIndex < inputToParse.Length)
        {
            if (inputToParse[parseIndex] == '(' || inputToParse[parseIndex] == ',')
            {
                parseIndex++;
                continue;
            }
            
            if (inputToParse[parseIndex] == ')')
            {
                parseIndex++;
                break;
            }
            
            word.Clear();
            
            while (!otherChars.Contains(inputToParse[parseIndex]))
            {
                word.Append(inputToParse[parseIndex++]);
            }

            var treeNode = new TreeNode(word.ToString().Trim());

            if (parseIndex < inputToParse.Length && inputToParse[parseIndex] == '(')
            {
                parseIndex++;
                treeNode.AddChildren(Parse(inputToParse, ref parseIndex));
            }

            treeNodes.Add(treeNode);

            if (parseIndex < inputToParse.Length && inputToParse[parseIndex] == ',')
            {
                parseIndex++;
            }
        }

        return treeNodes;
    }
    
    /// <summary>
    /// Print tree by using basic recursive tree logic
    /// </summary>
    /// <param name="treeNodes">Collection of tree nodes</param>
    /// <param name="numberOfIndents">Number of indents based on level of recursion</param>
    public static void Print(List<TreeNode> treeNodes, int numberOfIndents)
    {
        foreach (var treeNode in treeNodes)
        {
            System.Console.WriteLine(
                $"{new string(' ', numberOfIndents * Constants.NUM_OF_SPACES_FOR_INDENT)}- {treeNode.Value}");
            if (treeNode.Children.Any())
            {
                Print(treeNode.Children, numberOfIndents + 1);
            }
        }
    }

    /// <summary>
    /// Sort list of tree nodes
    /// </summary>
    /// <param name="treeNodes">list of tree nodes</param>
    /// <returns>sorted list of tree nodes</returns>
    public static List<TreeNode> Sort(List<TreeNode> treeNodes)
    {
        List<TreeNode> sortedTreeNodes = treeNodes.OrderBy(f => f.Value).ToList();
        foreach (var treeField in sortedTreeNodes)
        {
            _SortChildren(treeField);
        }

        return sortedTreeNodes;
    }

    /// <summary>
    /// Sort a tree node's children till end of list
    /// </summary>
    /// <param name="treeNode">tree field</param>
    private static void _SortChildren(TreeNode treeNode)
    {
        treeNode.Children = treeNode.Children.OrderBy(f => f.Value).ToList();
        foreach (var child in treeNode.Children)
        {
            _SortChildren(child);
        }
    }
}