using System;
using System.Reflection;
using System.Runtime;

namespace ConsoleApp16
{
    class Program
    {
        static void Main(string[] args)
        {
            var config1 = AppContext.GetData("abc");
            var config2 = AppContext.GetData("foo");

            // prints 123
            Console.WriteLine(config1);

            //prints bar
            Console.WriteLine(config2); 

            AppDomain.CurrentDomain.SetData("secret", "hooray");
            var secret = AppContext.GetData("secret");
            var secret2 = AppDomain.CurrentDomain.GetData("secret");

            //prints hooray
            Console.WriteLine(secret);

            // also prints hooray
            Console.WriteLine(secret2);

            typeof(AppContext).GetMethod("SetData", BindingFlags.Public | BindingFlags.Static).Invoke(null, new object[] { "hello", "world" });
            var hello = AppContext.GetData("hello");

            //prints bar
            Console.WriteLine(hello);
        }
    }
}
