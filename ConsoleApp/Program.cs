using System.Diagnostics;
using System.Drawing;
using System.Timers;
using Timer = System.Threading.Timer;

namespace ConsoleApp;

public class Program
{
    // Define a delegate
    public delegate void MyDelegate(string msg);

    public static void Main()
    {
        var dateUser = new DateUser(1994, 2, 1);
        var dateTime = new DateTime(1994, 2, 1);
        var dateOnly = new DateOnly(1994, 2, 1);
        var watch = new Stopwatch();
        watch.Start();
        // Create an instance of the delegate class.
        Console.WriteLine("Enter your name: ");
        watch.Stop();
        Console.WriteLine("Elapsed time: {0}", watch.Elapsed);
        // Call the delegate.
        var list = new List<int> {1, 2, 3, 4, 5};
        list.Clear();
        list.Add(6);
        list.AddRange(new[] {1, 2, 3, 4, 5});
        var contains = list.Contains(1);
        var find = list.Find(x => x == 2);
        var findAll = list.FindAll(x => x > 2 && x < 4);
        var findIndex = list.FindIndex(x => x == 4);
        var findLast = list.FindLast(x => x == 4);
        var findLastIndex = list.FindLastIndex(x => x == 4);
        var indexOf = list.IndexOf(4);
        list.Insert(6, list.Count);
        list.InsertRange(4, new[] {1, 2, 3, 4, 5});
        list.Remove(4);
        list.RemoveAll(x => x == 4);
        list.RemoveAt(4);
        list.RemoveRange(4, 2);
        list.Sort();
        var array = list.ToArray();
        list.TrimExcess();
    }

    // public static void Main()
    // {
    //     // Create an array of Point structures.
    //     Point[] points =
    //     {
    //         new Point(100, 200),
    //         new Point(150, 250), new Point(250, 375),
    //         new Point(275, 395), new Point(295, 450)
    //     };
    //
    //     // Define the Predicate<T> delegate.
    //     Predicate<Point> predicate = FindPoints;
    //
    //     // Find the first Point structure for which X times Y
    //     // is greater than 100000.
    //     Point first = Array.Find(points, predicate);
    //     var firstPoint = Array.Find(points, point => point.X * point.Y > 100000);
    //     var firstPoint2 = points.First(point => point.X * point.Y > 100000);
    //
    //     // Display the first structure found.
    //     Console.WriteLine("Found: X = {0}, Y = {1}", first.X, first.Y);
    // }

    private static bool FindPoints(Point obj) => obj.X * obj.Y > 100000;
}