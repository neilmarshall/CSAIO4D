using System;

public class AddOne {

    public int x;

    public static AddOne operator +(AddOne a, AddOne b) {

        AddOne addone = new AddOne();
        addone.x = a.x + b.x + 1;
        return addone;

    }

}

public class Program {

    static void Main() {

        AddOne foo = new AddOne();
        foo.x = 2;

        AddOne bar = new AddOne();
        bar.x = 3;

        // And 2 + 3 now is 6...
        Console.Write("Adding {0} and {1} ... = ", foo.x, bar.x);
        Console.WriteLine((foo + bar).x.ToString());

    }

}

