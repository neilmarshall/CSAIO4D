using System;
using System.Collections.Generic;

class Program {

    static void Main() {

        // demonstrate adding key-value pairs using both initialiser lists and the 'Add' method
        Dictionary<string, string> dict = new Dictionary<string, string> {{"C++", "Intermediate"}, {"C#", "Basic"}};

        // add key-value pairs
        dict.Add("R", "Intermediate");
        dict.Add("Python", "Advanced");

        // demonstrate various methods
        if (dict.ContainsKey("C++")) Console.WriteLine("C++: " + dict["C++"]);
        Console.Write("Keys: ");
        foreach (string k in dict.Keys) Console.Write(k + " ");
        Console.WriteLine();
        Console.Write("Values: ");
        foreach (string v in dict.Values) Console.Write(v + " ");
        Console.WriteLine();
        Console.WriteLine("Key-Value pairs:");
        foreach (KeyValuePair<string, string> pair in dict) {
            Console.WriteLine(pair.Key + ": " + pair.Value);
        }
    }
}

