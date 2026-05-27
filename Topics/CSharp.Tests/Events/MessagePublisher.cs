using System;
using System.Collections.Generic;
using System.Text;

namespace DevLab.CSharp.Events
{
    // Publisher classes are responsible for defining and raising events.
    // They contain the event declaration and the logic to raise the event when appropriate.
    public class MessagePublisher
    {
        // Publisher classes always contain an event that subscribers can subscribe to.
        // That event (or events) is what is know as an "event handler," and it is
        // typically of type EventHandler<TEventArgs>, where TEventArgs is a class that
        // contains any relevant data for the event.
        // In this case, we have a MessagePublished event that uses the MessageEventArgs class,
        // which expects to be asigned a method that takes an object sender and a MessageEventArgs
        // parameter.
        public event EventHandler<MessageEventArgs>? MessagePublished;

        // Publisher classes also contain methods that raise the event when appropriate.
        // These "Raise" or "Publish" methods normally call a protected virtual method
        // (like OnMessagePublished) that actually raises the event.
        // These public methods are functionally responsible for constructing the
        // event arguments and calling the protected method to raise the event.
        public void Publish(string message)
        {
            MessageEventArgs e = new MessageEventArgs(message);
            OnMessagePublished(e);
        }

        // The OnMessagePublished method is responsible for actually raising the
        // MessagePublished event.
        // This method is protected and virtual specifically so that the functionality
        // of constructing the event arguments cannot change, but the logic for raising
        // the event can be overridden by derived classes if necessary.
        protected virtual void OnMessagePublished(MessageEventArgs e)
        {
            MessagePublished?.Invoke(this, e);
        }
    }
}
