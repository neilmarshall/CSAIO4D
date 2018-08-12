using System;

// Basic mathematical functions
public class MathFunctions
{
    // Factorial -- Return the factorial of the given number
    public static int Factorial(int n)
    {
        // don't allow negative numbers
        if (n < 0)
        {
            // report negative argument
            string s = String.Format("Illegal negative argument to Factorial {0}", n);
            throw new ArgumentException(s);
        }
        else
        {
            return n > 1 ? n * Factorial(n - 1) : 1;
        }
    }
}


public class Program
{
    public static void Main()
    {
        try
        {
            // call Factorial in a loop
            for (int i = 6; i > -6; i--)
            {
                int factorial = MathFunctions.Factorial(i);
                Console.WriteLine("i = {0}, factorial = {1}", i, factorial);
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("Fatal error...");
            Console.WriteLine(e.ToString());
        }
    }
}

