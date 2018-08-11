using System;

class Program {

    // a simple class to continuously provide multiples of a given number
    class MultipleGenerator {

        private int seed;
        private int multiple;

        // class constructor
        public MultipleGenerator (int n) {

            seed = 0;
            multiple = n;

        }

        // function that does all the work
        public System.Collections.IEnumerator GetEnumerator() {
 
            while (true) {
                seed += multiple;
                yield return seed; 
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

        MultipleGenerator mg = new MultipleGenerator(n);
        foreach (int m in mg) {
            Console.WriteLine("Next multiple of {0} is {1}", n, m);
            Console.WriteLine("Hit enter to see the next multiple, or any other key to exit");
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input)) break;
        }

        Console.WriteLine("Program Exited!!!");
    }
}

