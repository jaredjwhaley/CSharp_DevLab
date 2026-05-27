using System;
using System.Collections.Generic;
using System.Text;

namespace DevLab.CSharp.Events
{
    public class MessageSubscriber
    {
        public string? LastMessage { get; private set; }

        // Subscriber classes contain methods that match the signature of the event handler delegate.
        // The method you will be subscribing with is the element that fulfills the contract of the
        // event handler delegate. In this case, the event handler delegate is EventHandler<MessageEventArgs>,
        // which means that the method must have a void return type and accept two parameters: an
        // object sender and a MessageEventArgs e.
        //
        // NOTE: You do not techincally need a "Subscriber" class to subscribe to an event.
        // You can subscribe with any method that matches the signature of the event handler delegate,
        // including static methods. However, it is common practice to create a subscriber class to encapsulate
        // the logic for handling the event and to maintain state related to the event handling.
        public virtual void HandleMessage(object? sender, MessageEventArgs e)
        {
            LastMessage = e.Message;
        }
    }
}
