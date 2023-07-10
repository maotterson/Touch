using Touch;

try
{
    var filesSet = args.ToHashSet();
    foreach (var file in filesSet)
    {
        try
        {
            if (File.Exists(file))
            {
                throw new FileExistsException();
            }
            using (var createdFile = File.Create(file))
            {
                createdFile.Close();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"CREATED: {createdFile.Name}");
            }
        }
        catch (DirectoryNotFoundException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR: {file} not created. Directory not found.");
        }
        catch(UnauthorizedAccessException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR: {file} not created. Unauthorized access or a folder exists with the same name.");
        }
        catch (FileExistsException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR: {file} not created. A file already exists with the same name.");
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR: {file} not created. An unexpected exception occured.");
        }
    }
}
finally
{
    Console.ResetColor();
}
