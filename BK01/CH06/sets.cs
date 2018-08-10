using System;
using System.Collections.Generic;

class Program {

    static void Main() {

        // create a set using initialiser list
        HashSet<string> s1 = new HashSet<string> {"orange", "blue", "green", "red"};

        // create a set from an existing array
        string[] c2 = {"blue", "yellow", "red", "yellow", "red"};
        HashSet<string> s2 = new HashSet<string>(c2);

        // create a set using the set.Add method
        HashSet<string> s3 = new HashSet<string>();
        s3.Add("green");
        s3.Add("green");
        s3.Add("red");

        Console.WriteLine("Contents of s1: " + String.Join(", ", s1));
        Console.WriteLine("Contents of s2: " + String.Join(", ", s2));
        Console.WriteLine("Contents of s3: " + String.Join(", ", s3));

        // define a new set to hold the union of all colours
        HashSet<string> colour_union = new HashSet<string>(s1);
        colour_union.UnionWith(s2);
        colour_union.UnionWith(s3);
        Console.WriteLine("Union of s1, s2 and s3: " + String.Join(", ", colour_union));

        // define a new set to hold the intersection of all colours
        HashSet<string> colour_intersection = new HashSet<string>(s1);
        colour_intersection.IntersectWith(s2);
        colour_intersection.IntersectWith(s3);
        Console.WriteLine("Intersection of s1, s2 and s3: " + String.Join(", ", colour_intersection));
    }
}

