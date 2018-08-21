using System;

public class BaseClass
{
    public int _dataMember;

    public void SomeMethod()
    {
        Console.WriteLine("SomeMethod()");
    }
}

public class SubClass : BaseClass
{
    public void SomeOtherMethod()
    {
        Console.WriteLine("SomeOtherMethod()");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // create a BaseClass object
        Console.WriteLine("Exercising a BaseClass object:");
        BaseClass bc = new BaseClass();
        bc._dataMember = 1;
        bc.SomeMethod();

        // now create a SubClass object
        Console.WriteLine("Exercising a SubClass object:");
        SubClass sc = new SubClass();
        sc.SomeMethod();
        sc.SomeOtherMethod();
    }
}

