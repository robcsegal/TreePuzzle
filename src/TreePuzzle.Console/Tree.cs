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
        List<TreeNode> treeFields = new List<TreeNode>();
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

            var treeField = new TreeNode(word.ToString().Trim());

            if (parseIndex < inputToParse.Length && inputToParse[parseIndex] == '(')
            {
                parseIndex++;
                treeField.AddChildren(Parse(inputToParse, ref parseIndex));
            }

            treeFields.Add(treeField);

            if (parseIndex < inputToParse.Length && inputToParse[parseIndex] == ',')
            {
                parseIndex++;
            }
        }

        return treeFields;
    }
    
    /// <summary>
    /// Print tree by using basic recursive tree logic
    /// </summary>
    /// <param name="treeFields">Collection of tree fields</param>
    /// <param name="numberOfIndents">Number of indents based on level of recursion</param>
    public static void Print(List<TreeNode> treeFields, int numberOfIndents)
    {
        foreach (var treeField in treeFields)
        {
            System.Console.WriteLine(
                $"{new string(' ', numberOfIndents * Constants.NUM_OF_SPACES_FOR_INDENT)}- {treeField.Value}");
            if (treeField.Children.Any())
            {
                Print(treeField.Children, numberOfIndents + 1);
            }
        }
    }

    /// <summary>
    /// Sort list of tree fields
    /// </summary>
    /// <param name="treeFields">list of tree fields</param>
    /// <returns>sorted list of tree fields</returns>
    public static List<TreeNode> Sort(List<TreeNode> treeFields)
    {
        List<TreeNode> sortedTreeFields = treeFields.OrderBy(f => f.Value).ToList();
        foreach (var treeField in sortedTreeFields)
        {
            _SortChildren(treeField);
        }

        return sortedTreeFields;
    }

    /// <summary>
    /// Sort a tree field's children till end of list
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