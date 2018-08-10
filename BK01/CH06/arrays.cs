using System;

class Program {

    static void Main() {

        double[] doubles = {5, 2, 7, 3.5, 6.5, 8, 1, 9, 1, 3};

        double sum = 0;
        foreach (double d in doubles) {
            Console.Write(d + " ");
            sum += d;
        }

        Console.WriteLine("\nAverage = {0:F3}", sum / doubles.Length);
    }
}

