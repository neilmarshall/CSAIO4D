using System;
using System.Collections.Generic;

class Program {

    static void Main() {

        List<int> lst = new List<int> {2, 4, 5, 3, 1};

        // demonstrate 'Add' method of 'List'
        lst.Add(6);
        lst.Add(4);

        // demonstrate 'AddRange' method of 'List'
        int[] ints = {13, 12, 11};
        lst.AddRange(ints);

        // print all elements to show this all works
        foreach (int n in lst) Console.WriteLine(n);

        // demonstrate 'Contains' and 'IndexOf' methods of 'List'
        if (lst.Contains(5)) {
            Console.WriteLine("Index of 5: " + lst.IndexOf(5));
        }

        // sort the list and remove the first element
        lst.Sort();
        lst.RemoveAt(0);
        foreach (int n in lst) Console.WriteLine(n);
    }
}

