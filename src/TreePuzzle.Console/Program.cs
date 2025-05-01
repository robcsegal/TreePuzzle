using TreePuzzle.Console;

public class CLI
{
    public static void Main()
    {
        string original = "(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)";
        string valueToParse = original;
        
        Console.WriteLine($"Original is {original}. Do you wish to parse this (y/n)?");
        bool use_original = Convert.ToString(Console.ReadLine()) == "y" ? true : false;
        
        if (!use_original)
        {
            Console.WriteLine("What would you like to parse?");
            valueToParse = Convert.ToString(Console.ReadLine());
        }
        
        Console.WriteLine($"Parsing {valueToParse}");

        int startIndex = 0;
        
        var tree = Tree.Parse(valueToParse, ref startIndex);

        Console.WriteLine("\nUnsorted translation is: ");
        
        Tree.Print(tree, 0);
        
        Console.WriteLine("\nSorted translation is: ");

        var sortedTree = Tree.Sort(tree);
        
        Tree.Print(sortedTree, 0);
    }
}
