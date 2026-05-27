using System;
using System.Collections.Generic;
using System.Text;

namespace Lectures
{
    public class S11EventsAndDelegates
    {

        // 1. Declaration:
        // NOTE: Delegates should typically be declared outside of classes
        // but, for simplicity, we will declare it here.
        public delegate void Notify(string message);


        public static void Run()
        {
            // Delegates define a method signature,
            // and any method assigned to a delegate must match this signature.



            // 2. Instantiation:
            Notify notifyDelegate = ShowMessage;
            //Notify notifyDelegate = new Notify(notifyDelegate);


            // 3. Invocation:
            notifyDelegate("Hello, Delegates!");

            // 4. Multicast Delegates:
            notifyDelegate += AnotherMessage;

            // 5. Invocation of Multicast Delegates:
            notifyDelegate("This message will be shown by both methods!");

            // 6. Removing a method from a multicast delegate:
            notifyDelegate -= ShowMessage;

            // Wait for user input before closing the console;
            Console.ReadKey();
        }

        static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        static void AnotherMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void InvokeDelegateSafely(Notify notifyDelegate, string message)
        {
            if (notifyDelegate != null) notifyDelegate.Invoke(message);
        }

        public void RemoveMethodFromDelegate(ref Notify notifyDelegate, Notify methodToRemove)
        {
            if (notifyDelegate != null && notifyDelegate.GetInvocationList().Contains((Delegate)methodToRemove))
            {
                notifyDelegate -= methodToRemove;
            }
            else
            {
                Console.WriteLine("Method is not in the invocation list.");
            }
        }
    }
}
