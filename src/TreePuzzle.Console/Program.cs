using TreePuzzle.Console;

public class CLI
{
    public static void Main()
    {
        string original = "(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)";
        
        Console.WriteLine($"Parsing {original}");

        int startIndex = 0;
        
        var tree = Tree.Parse(original, ref startIndex);

        Console.WriteLine("\nUnsorted original translation is: ");
        
        Tree.Print(tree, 0);
        
        Console.WriteLine("\nSorted original translation is: ");

        var sortedTree = Tree.Sort(tree);
        
        Tree.Print(sortedTree, 0);
    }
}
