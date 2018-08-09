using System;

class Program {

    // program takes a year specified by the user and returns whether it is a
    // leap year
    static void Main() {

        Console.Write("Please enter a year: ");

        string input = Console.ReadLine();
        int year;
        if (!Int32.TryParse(input, out year)) {
            Console.Error.WriteLine("Not an integer!");
            Environment.Exit(1);
        }

        if (year % 4 == 0) {  // leap year if year is divisible by 4
            if (year % 100 == 0 && year % 400 != 0) {  // unless year is divisible by 100 but not 400
                Console.WriteLine(false);
            } else {
                Console.WriteLine(true);
            }
        } else {
            Console.WriteLine(false);
        }

    }

}
