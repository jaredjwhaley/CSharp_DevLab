using System;

namespace DevLab.CSharp.Events
{
    /// <summary>
    /// Contains the message data passed from a publisher to its event subscribers.
    /// </summary>
    /// <remarks>
    /// Event-data classes conventionally inherit from <see cref="EventArgs"/>.
    /// They expose the information subscribers need when handling an event.
    /// This example contains a single message, but other events may require
    /// several properties.
    /// </remarks>
    public class MessageEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the message associated with the event.
        /// </summary>
        /// <remarks>
        /// The value is assigned during construction and cannot subsequently
        /// be changed through this property.
        /// </remarks>
        public string Message { get; }

        /// <summary>
        /// Initializes the event data with the specified message.
        /// </summary>
        /// <param name="message">The message to provide to subscribers.</param>
        public MessageEventArgs(string message)
        {
            Message = message;
        }
    }
}