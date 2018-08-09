using System;

class Program {

    static void Main(string[] args) {

        // ensure user has provided exactly 2 strings
        if (args.Length != 2) {
            Console.Error.WriteLine("You need to provide exactly two string arguments");
            Environment.Exit(1);
        }

        string s1 = args[0];
        string s2 = args[1];

        if (String.Compare(s1, s2) == 1) {
            Console.WriteLine("String {0} is greater than string {1}", s1, s2);
        }
        else if (String.Compare(s1, s2) == -1) {
            Console.WriteLine("String {0} is less than string {1}", s1, s2);
        }
        else {
            Console.WriteLine("String {0} and string {1} compare equal", s1, s2);
        }
    }

}

