using System;

class Program {

    // This program takes input from the command line and if it can be cast
    // to a double, prints it in a nice format
    static void Main() {

        Console.Write("Please input a number: ");
        string input = Console.ReadLine();
        double val;
        if (Double.TryParse(input, out val)) {
            Console.WriteLine("You entered {0:N}", val);
        } else {
            Console.Error.WriteLine("Bad input!");
            Environment.Exit(1);
        }
    }
}
