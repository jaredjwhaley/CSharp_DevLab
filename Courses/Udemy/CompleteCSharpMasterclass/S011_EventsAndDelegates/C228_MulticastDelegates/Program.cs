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

        // To invoke safely, we can check if the delegate is not null before invoking it:
        //   - This is important because if the delegate has no methods in its invocation list, it
        //     will be null and invoking it will throw a NullReferenceException.
        public static void SafeInvoke(MyDelegate del, string message)
        {
            if (del != null)
            {
                del(message);
            }
        }
        // Alternatively, we can use the null-conditional operator (?.) to invoke the delegate safely:
        //  - This is a more concise way to check for null before invoking the delegate.
        //  - Example: del?.Invoke(message);

        // To check if a specific method is in the invocation list of a multicast delegate, we can use the GetInvocationList() method:
        /// <summary>
        /// Determines whether a method with the specified name appears in the invocation list of the provided multicast
        /// delegate.
        /// </summary>
        /// <param name="del">The multicast delegate whose invocation list is searched; may be null.</param>
        /// <param name="methodName">The name of the method to locate in the delegate's invocation list.</param>
        /// <returns>True if a method with the specified name is found in the delegate's invocation list; otherwise, false.</returns>
        public static bool IsMethodInDelegate(MyDelegate del, string methodName)
        {
            if (del != null)
            {
                foreach (var d in del.GetInvocationList())
                {
                    if (d.Method.Name == methodName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
