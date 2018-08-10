using System;

class Program {

    static void Main() {

        Console.Write("Please enter an integer between 1 and 3: ");

        int n;
        if (!Int32.TryParse(Console.ReadLine(), out n)) {
            Console.Error.WriteLine("Not valid input!");
            Environment.Exit(1);
        }

        switch (n) {
            case 1:
                Console.WriteLine("You entered 1!");
                break;
            case 2:
                Console.WriteLine("You entered 2!");
                break;
            case 3:
                Console.WriteLine("You entered 3!");
                break;
            default:
                Console.WriteLine("You did not follow the rules!");
                break;
        }
    }
}

