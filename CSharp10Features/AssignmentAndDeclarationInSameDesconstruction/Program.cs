var rectangle = new Rectangle(200, 100);

(int h, int w) = rectangle;

int height = 0;
//int width = 0;
(height, int width) = rectangle;

public class Rectangle
{
    public Rectangle(int height, int width)
    {
        Height = height;
        Width = width;
    }


    public int Height { get; init; }

    public int Width { get; init; }

    internal void Deconstruct(out int height, out int width)
    {
        height = Height;
        width = Width;
    }
}