using System;

// SimpleDelegateExample -- Demonstrate a simple delegate callback
namespace SimpleDelegateExample
{
    class Program
    {
        //Incide class or inside namespace
        delegate int MyDelType(string name);

        public static void Main(string[] args)
        {
            // Create a delegate instance pointing to the CallBackMethod below;
            // note that the callback method is static, so you can prefix the
            // name with the class name, Program
            MyDelType del = new MyDelType(Program.CallBackMethod);

            // Call a method that will invoke the delegate
            UseTheDel(del, "hello");
        }

        // UseTheDel -- A workhorse method that takes a MyDelType delegate
        // argument and invokes the delegate; arg is a string to pass to the
        // delegate invocation
        private static void UseTheDel(MyDelType del, string arg)
        {
            if (del == null) return;  // Don't invoke a null delegate

            // Here's where the delegate is invoked
            Console.WriteLine("UseTheDel writes {0}", del(arg));
        }

        // CallBackMethod -- A method that conforms to the MyDelType delegate
        // signature (takes a string, returns an int); the delegate will call this
        // method
        public static int CallBackMethod(string stringPassed)
        {
            Console.WriteLine("CallBackMethod writes: {0}", stringPassed);

            return stringPassed.Length;  // Delegate requires an int return
        }
    }
}

