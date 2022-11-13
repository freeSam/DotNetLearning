// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

internal struct Rectangle
{
    public int Height { get; init; }

    public int Width { get; init; }
}

internal record struct Person(string FirstName);