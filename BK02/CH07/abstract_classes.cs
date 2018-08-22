using System;

/*
    Learning points from this program:

    1. 'abstract' classes and methods - see declaration of 'ABC' class

    2. Dervived classes marked as 'sealed', meaning these can't be extended

    3. Expression-bodied constructors for the subclasses for simplicity

    4. Expression-bodied function in class 'Program' for simplicity
*/

abstract public class ABC
{
    protected string _data;

    public ABC(string s) => _data = s;

    abstract public void Output(string s);
}

public sealed class Subclass1 : ABC
{
    public Subclass1(string s) : base(s) {}

    override public void Output(string s)
    {
        Console.WriteLine("In Subclass1:");
        Console.WriteLine(_data);
        Console.WriteLine(s.ToLower());
    }
}

public sealed class Subclass2 : ABC
{
    public Subclass2(string s) : base(s) {}

    override public void Output(string s)
    {
        Console.WriteLine("In Subclass2:");
        Console.WriteLine(_data + _data);
        Console.WriteLine(s.ToUpper());
    }
}

public class Program
{
    public static void CallOutput(ABC abc, string s) => abc.Output(s);

    public static void Main()
    {
        Subclass1 s1 = new Subclass1("AbCdEf");
        CallOutput(s1, "AbCdEf");

        Subclass2 s2 = new Subclass2("AbCdEf");
        CallOutput(s2, "AbCdEf");
    }
}

