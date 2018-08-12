using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Section 1 -- Input user data
        decimal principal = 0M;
        decimal interest = 0M;
        decimal duration = 0M;
        InputInterestData(ref principal, ref interest, ref duration);

        // Section 2 -- Verify user data
        Console.WriteLine();
        Console.WriteLine("Principal = " + principal);
        Console.WriteLine("Interest = " + interest + "%");
        Console.WriteLine("Duration = " + duration);
        Console.WriteLine();

        // Section 3 -- Output the interest table
        OutputInterestTable(principal, interest, duration);
    }

    public static void InputInterestData(ref decimal principal,
                                         ref decimal interest,
                                         ref decimal duration)
    {
        principal = InputPositiveDecimal("principal");
        interest = InputPositiveDecimal("interest");
        duration = InputPositiveDecimal("duration");
    }

    public static decimal InputPositiveDecimal(string prompt)
    {
        while (true)
        {
            Console.Write("Enter " + prompt + ": ");
            string input = Console.ReadLine();
            decimal value = Convert.ToDecimal(input);

            if (value >= 0)
            {
                return value;
            }

            Console.WriteLine(prompt + " cannot be negative");
            Console.WriteLine("Try again");
            Console.WriteLine();
        }
    }

    public static void OutputInterestTable(decimal principal,
                                    decimal interest,
                                    decimal duration)
    {
        for (int year = 1; year <= duration; year++)
        {
            decimal interestPaid;
            interestPaid = principal * (interest / 100);

            principal = decimal.Round(principal + interestPaid, 2);

            Console.WriteLine(year + " - " + principal);
        }
    }
}

