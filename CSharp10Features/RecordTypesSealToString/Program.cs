// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

internal record Rectangle(int Height, int Width)
{
    public sealed override string ToString()
    {
        return $"Height is: {Height} and width is: {Width}";
    }
}

internal record Square : Rectangle
{
    protected Square(int sideLength) : base(sideLength, sideLength)
    {
    }

    //public override string ToString()
    //{
    //    return $"Side length: {Height}";
    //}
}
