using System;

using PrimesLib;

class Program
{
    public static void Main(string[] args)
    {
        int n;
        if (args.Length == 0 || !Int32.TryParse(args[0], out n))
        {
            Console.Error.WriteLine("Must have at least one integer argument");
            Environment.Exit(1);
        }
        else
        {
            Console.WriteLine("{0}: {1}prime", n,
                PrimeFunctions.IsPrime(n) ? "" : "not ");
        }
    }
}

