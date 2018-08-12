using System;

class Program
{
    public static void Main(string[] args)
    {
        int N;
        if (args.Length == 0 || !Int32.TryParse(args[0], out N))
        {
            Console.Error.WriteLine("Invalid arguments supplied");
            Environment.Exit(1);
        }
        else
            {
            Tuple<int, bool>[] indicators = new Tuple<int, bool>[N];
    
            for (int i = 0; i < N; i++)
            {
                bool flag = is_prime(i);
                indicators[i] = new Tuple<int, bool>(i, flag);
            }
    
            foreach (Tuple<int, bool> indicator in indicators)
            {
                Console.WriteLine("{0} is{1}prime",
                    indicator.Item1, indicator.Item2 ? " " : " not ");
            }
        }
    }

    public static bool is_prime(int n)
    {
        if (n <= 2) return n == 2 ? true : false;

        for (int p = 2; p <= n / 2; p++)
        {
            if (n % p == 0)
            {
                return false;
            }
        }

        return true;
    }
}
