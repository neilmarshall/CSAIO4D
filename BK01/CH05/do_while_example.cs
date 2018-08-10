using System;

class Program {

    static void Main() {

        // print values of integers from 1 onwards, whilst less than 10 but
        // skipping multiples of 3, using nothing but break and continue statements
        int i = 1;
        do {
            if (i % 3 == 0) continue;
            Console.WriteLine(i);
        } while (i++ < 10);
    }
}

