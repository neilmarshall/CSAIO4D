using System;

class Point
{
    private double x;
    private double y;

    public Point(Tuple<double, double> point)
    {
        this.x = point.Item1;
        this.y = point.Item2;
    }

    public Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public static Point operator +(Point A, Point B)
    {
        return new Point(new Tuple<double, double>(A.x + B.x, A.y + B.y));
    }

    public double distance()
    {
        return Math.Sqrt(this.x * this.x + this.y * this.y);
    }
}

class Program
{
    static void Main()
    {
        Point P1 = new Point(new Tuple<double, double>(3.0, 4.0));
        Point P2 = new Point(5.0, 12.0);

        Console.WriteLine("Distance for P1 = {0}", P1.distance());
        Console.WriteLine("Distance for P2 = {0}", P2.distance());

        Point P3 = P1 + P2;
        Console.WriteLine("Distance for P3 = {0}", P3.distance());
    }
}


