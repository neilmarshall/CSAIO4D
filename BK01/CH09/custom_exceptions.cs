using System;

public class MyException : Exception
{
    public MyException() : base()
    {
    }

    public MyException(String message) : base(message)
    {
    }

    public MyException(String message, Exception innerException) : base(message, innerException)
    {
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            if (args.Length == 0)
            {
                throw new MyException("No arguments given");
            }
            else if (args.Length == 1)
            {
                throw new MyException(args[0]);
            }
            else
            {
                throw new Exception("Multiple arguments");
            }
        }
        catch (MyException e)
        {
            Console.Error.WriteLine(e.Message);
            Console.Error.WriteLine(e.ToString());
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.Message);
            Console.Error.WriteLine(e.ToString());
        }
    }
}

