var rectangle = new Rectangle(420, 69);

var newOne = rectangle with { Width = 420 };

public struct Rectangle
{
    public Rectangle()
    {
        Height = 0;
        Width = 0;
    }

    public Rectangle(int height, int width)
    {
        Height = height;
        Width = width;
    }

    public int Height { get; init; }

    public int Width { get; init; }
}