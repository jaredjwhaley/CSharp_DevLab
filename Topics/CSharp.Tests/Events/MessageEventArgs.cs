using System;
using System.Collections.Generic;
using System.Text;

namespace DevLab.CSharp.Events
{
    // EventArgs classes are the data containers for events.
    // They are used to pass any relevant information from the publisher to the
    // subscriber when an event is raised.
    public class MessageEventArgs : EventArgs
    {
        // EventArgs classes are used to encapsulate any relevant data for an event.
        // They typically inherit from the EventArgs class, which is a base class
        // provided by .NET for event data.
        //
        // You will normally see multiple properties in an EventArgs class, but for this
        // example we only have one property, Message, which is a string that contains
        // the message being published.
        public string Message { get; }

        public MessageEventArgs(string message)
        {
            Message = message;
        }
    }
}
