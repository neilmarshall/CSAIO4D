using System;

public class Program
{
    private static dynamic f(dynamic x)
    {
        return (Math.Sqrt(x) + 5.0 * Math.Pow(x, 3.0));
    }

    public static void Main(string[] args)
    {
        dynamic[] array = new Array[11];

        for (int i = 0; i < 11; i++)
        {
            Console.Write("Please enter a number: ");
            array[i] = Console.ReadLine();
        }

        for (int i = 10; i >= 0; i--)
        {
            dynamic y = f(array[i]);
            if (y > 400.0)
            {
                Console.WriteLine(String.Format("{0} TOO LARGE", i));
            }
             else
            {
                Console.WriteLine("{0} : {1}", i, array[i]);
            }
        }
    }
}

