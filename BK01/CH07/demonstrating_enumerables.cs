using System;

class Program {

    // a simple class to generate the first n Fibonacci numbers
    class FibGen {

        private int n0, n1;

        // class constructor
        public FibGen () {

            n0 = n1 = 1;

        }

        // function that does all the work
        public System.Collections.IEnumerable Generate_N(int limit) {
 
            yield return n0;
            yield return n1;

            for (int i = 2; i < limit; i++) {
                int temp = n1;
                n1 = n0 + n1;
                n0 = temp;
                yield return n1; 
            }
        }
    }

    // creates a generator returning multiples of a user-specified number,
    // until the user quits
    public static void Main(string[] args) {

        int n = 0;
        if (args.Length < 1 || !Int32.TryParse(args[0], out n)) {
            Console.Error.WriteLine("Must specify an integer argument");
            Environment.Exit(1);
        }

        FibGen fg = new FibGen();
        foreach (int f in fg.Generate_N(n)) {
            Console.WriteLine(f);
        }
    }
}

