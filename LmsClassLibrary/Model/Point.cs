namespace LmsClassLibrary.Model;

public class Point
{
    public Point(int x)
    {
        X = x;
    }

    public Point()
    {
    }

    public Point(int x, int y, string name)
    {
        X = x;
        Y = y;
        Name = name;
    }

    public int X { get; set; }
    public int Y { get; set; }
    public string Name { get; set; } = "Default name";

    public static Point operator +(Point p1, Point p2)
    {
        return new Point {X = p1.X + p2.X, Y = p1.Y + p2.Y};
    }
}