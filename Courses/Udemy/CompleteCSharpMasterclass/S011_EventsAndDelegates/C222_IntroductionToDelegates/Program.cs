using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C222_IntroductionToDelegates
{
    /* === NOTES ==================================================================================
     * === Introduction to Delegates ===
     * - Delegates
     *   - A delegate is a type that represents references to methods with a particular parameter list and return type.
     *   - Example: public delegate void MyDelegate(string message);
     *   
     */
    internal class Program
    {
        // 1. Declaration:
        public delegate void MyDelegate(string message);

        public static void Main(string[] args)
        {
            // 2. Instantiation:
            MyDelegate del = new MyDelegate(MyMethod);

            // 3. Invocation:
            del("Hello, World!");
        }

        // Method that matches the delegate signature
        public static void MyMethod(string message)
        {
            Console.WriteLine(message);
        }
    }
}
