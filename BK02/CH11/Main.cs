using System;

class Program
{
    public static int f(int x, int y, int z = 0)
    {
        return (2 + x) * y + z;
    }

    public static void Main()
    {
        // demonstrate using optional parameters, as named parameters
        Console.WriteLine("f(3, 5) = {0}", f(3, 5));  // prints 25
        Console.WriteLine("f(3, 5, 4) = {0}", f(3, 5, 4));  // prints 29
        Console.WriteLine("f(y:5, z:4, x:3) = {0}", f(y:5, z:4, x:3));  // prints 29
    }
}

