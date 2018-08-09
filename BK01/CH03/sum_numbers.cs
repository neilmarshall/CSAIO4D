using System;

class Program {

    // this program takes a series of integers from the command line and outputs their sum
    static void Main() {

        Console.Write("Please enter a list of comma-separated numbers: ");
        string input = Console.ReadLine();

        int sum = 0;
        foreach (string s in input.Split(',')) {
            int n;
            if (Int32.TryParse(s.Trim(), out n)) {
                sum += n;
            }
        }

        Console.WriteLine("Sum: {0}", sum);

    }

}

