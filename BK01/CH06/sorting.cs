using System;

class Program {

    static void Main() {

        // the planets are initially sorted by distance to the sun (closes first)
        string[] planets = {"Mercury", "Venus", "Earth", "Mars", "Jupiter"};

        Console.Write("The five planets closest to the sun are: " + String.Join(", ", planets) + '\n');

        // now sort the planets lexicographically
        Array.Sort(planets);

        Console.Write("The five planets closest to the sun are in lexicographical order are: " +
                      String.Join(", ", planets) + '\n');
    }
}

