using System;

namespace DevLab.CSharp.Events
{
    /// <summary>
    /// Handles published messages and stores the most recently received message.
    /// </summary>
    /// <remarks>
    /// A dedicated subscriber class groups event-handling behavior with related
    /// state. It is not required for subscription: compatible static methods,
    /// instance methods, and lambda expressions can also handle events.
    ///
    /// Creating an instance does not automatically subscribe it to a publisher.
    /// Attach <see cref="HandleMessage"/> to the publisher's event using +=,
    /// and remove it using -= when the subscription is no longer needed.
    /// </remarks>
    public class MessageSubscriber
    {
        /// <summary>
        /// Gets the most recently received message, or null if no message
        /// has been received.
        /// </summary>
        public string? LastMessage { get; private set; }

        /// <summary>
        /// Handles a published message by storing it in <see cref="LastMessage"/>.
        /// </summary>
        /// <param name="sender">
        /// The source of the event. <see cref="MessagePublisher"/> supplies itself
        /// as the sender when raising its event.
        /// </param>
        /// <param name="e">The event data containing the published message.</param>
        /// <remarks>
        /// This handler matches the signature defined by
        /// <see cref="EventHandler{TEventArgs}"/> when its type argument is
        /// <see cref="MessageEventArgs"/>: a void return type, an object sender,
        /// and a MessageEventArgs parameter.
        ///
        /// The method is virtual so derived classes can customize its behavior.
        /// An override can call base.HandleMessage(sender, e) to retain the
        /// behavior that updates LastMessage.
        /// </remarks>
        public virtual void HandleMessage(object? sender, MessageEventArgs e)
        {
            LastMessage = e.Message;
        }
    }
}