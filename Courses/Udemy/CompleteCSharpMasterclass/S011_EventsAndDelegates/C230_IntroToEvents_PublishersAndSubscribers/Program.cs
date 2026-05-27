using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C230_IntroToEvents_PublishersAndSubscribers
{
    /* === NOTES ==================================================================================
     * === Introduction to Events, Publishers, and Subscribers ===
     * - Events
     *   - Events encapsulate (not extend) the delegate class.
     *   - Consider them to be a controlled method of accessing the delegate. They provide a way
     *     for a class to notify other classes or objects when something of interest occurs.
     *   - Events are sent by objects called publishers, and the objects that receive the
     *     event are called subscribers.
     *   - Example: public event MyDelegate MyEvent;
     *   
     */

    // 1. EventArgs Class:
    //   - Implementing an EventArgs class is best practice when defining events, as it allows you
    //     to pass any relevant information from the publisher to the subscriber when an event is
    //     raised.
    //   - This is superior to using a delegate that takes parameters directly, because it allows
    //     for better extensibility and maintainability. If you need to add more information to the
    //     event in the future.
    public class MyEventArgs : EventArgs
    {
        // Properties to hold any relevant information for the event.
        // In this example, we have a single property, Message, which is a string that contains
        //   the message being published.
        public string Message { get; set; }
        public MyEventArgs(string message)
        {
            Message = message;
        }
    }

    // 2. Delegate Declaration:
    public delegate void MyDelegate(MyEventArgs eventArgs);

    // 3. Publisher Class:
    //   - The publisher class functionally owns the event.
    //     - It is responsible for declaring and raising the event.
    //   - No other class can raise the event, but any class can subscribe to it.
    public class Publisher
    {
        // Declare an event of type MyDelegate.
        public event MyDelegate MyEvent;
        // Method to raise the event.
        public void Publish(string message)
        {
            // Check if there are any subscribers before raising the event.
            if (MyEvent != null)
            {
                // Create an instance of MyEventArgs with the message and raise the event.
                MyEventArgs args = new MyEventArgs(message);
                MyEvent(args);
            }
        }
    }

    // 4. Subscriber Class:
    public class Subscriber
    {
        // Method to handle the event. This method must match the signature of the delegate.
        public void OnMyEvent(MyEventArgs eventArgs)
        {
            Console.WriteLine("Subscriber received message: " + eventArgs.Message);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
