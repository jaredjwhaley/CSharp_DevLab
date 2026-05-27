using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C228_MulticastDelegates
{
    /* === NOTES ==================================================================================
     * === Multicast Delegates ===
     * - Multicast Delegates
     *   - A multicast delegate is a delegate that can have more than one method in its invocation list.
     *   - When a multicast delegate is invoked, it calls all the methods in its invocation list in order.
     *   - Example: del += AnotherMethod; // Adds AnotherMethod to the invocation list of del
     */
    internal class Program
    {
        // 1. Declaration:
        public delegate void MyDelegate(string message);
        public static void Main(string[] args)
        {
            // 2. Instantiation:
            //   - Old Format: MyDelegate del = new MyDelegate(MyMethod);
            //   - New Format: MyDelegate del = MyMethod;
            MyDelegate del = MyMethod;

            // Adding another method to the invocation list
            del += AnotherMethod;

            // 3. Invocation:
            del("Hello, World!");

            // 4. Removing a method from the invocation list
            del -= MyMethod;

            // 5. Invocation after removing MyMethod
            del("Hello again, World!");
        }

        // Method that matches the delegate signature
        public static void MyMethod(string message)
        {
            Console.WriteLine("MyMethod: " + message);
        }
        public static void AnotherMethod(string message)
        {
            Console.WriteLine("AnotherMethod: " + message);
        }
    }
}
