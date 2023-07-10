foreach(var file in args)
{
    using (var createdFile = File.Create(file))
    {
        createdFile.Close();
        Console.WriteLine($"{createdFile.Name} created.");
    }
}