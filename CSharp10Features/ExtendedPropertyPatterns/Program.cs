using ExtendedPropertyPatterns;

var rectangleInside = new Rectangle(100, 100);

var rectangle = new Rectangle(200, 300, rectangleInside);

if (rectangle is { rectangle.Height: > 100 })
{
    Console.WriteLine("First", rectangle);
}

if (rectangle is { Height: > 100 })
{
    Console.WriteLine("Second", rectangle);
}