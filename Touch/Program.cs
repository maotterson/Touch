foreach(var file in args)
{
    try
    {
        using (var createdFile = File.Create(file))
        {
            createdFile.Close();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"CREATED: {createdFile.Name}");
        }
    }
    catch(DirectoryNotFoundException ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"ERROR: {file} not created. Directory not found.");
    }
    catch
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"ERROR: {file} not created. An unexpected exception occured.");
    }
}