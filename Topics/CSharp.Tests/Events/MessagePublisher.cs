using System;
using System.Collections.Generic;
using System.Text;

namespace DevLab.CSharp.Events
{
    /// <summary>
    /// Publishes messages by raising an event that subscribers can handle.
    /// </summary>
    public class MessagePublisher
    {
        /// <summary>
        /// Occurs when a message is published.
        /// </summary>
        /// <remarks>
        /// MessagePublished is the event.
        /// EventHandler&lt;MessageEventArgs&gt; is its delegate type, which defines
        /// the required handler signature: void (object? sender, MessageEventArgs e).
        /// A method subscribed to the event, such as MessageSubscriber.HandleMessage,
        /// is an event handler.
        ///
        /// Subscribers use += to attach handlers and -= to remove them.
        /// Code outside this class cannot directly invoke the event.
        /// </remarks>
        public event EventHandler<MessageEventArgs>? MessagePublished;

        /// <summary>
        /// Constructs the event arguments and requests that the message event be raised.
        /// </summary>
        /// <param name="message">The message to provide to subscribers.</param>
        public void Publish(string message)
        {
            MessageEventArgs e = new MessageEventArgs(message);
            OnMessagePublished(e);
        }

        /// <summary>
        /// Raises the MessagePublished event using the supplied event arguments.
        /// </summary>
        /// <param name="e">The message data to provide to subscribed handlers.</param>
        /// <remarks>
        /// This protected virtual method provides an extension point for derived
        /// classes to customize event raising. An override can perform additional
        /// work before or after calling base.OnMessagePublished(e).
        ///
        /// Calling the base implementation invokes the subscribed handlers.
        /// An override that omits that call suppresses this implementation's
        /// notification of subscribers.
        ///
        /// Publish constructs the arguments separately. Making this method
        /// protected and virtual does not enforce how arguments are constructed.
        /// </remarks>
        protected virtual void OnMessagePublished(MessageEventArgs e)
        {
            // Invoke the subscribed handlers only when the delegate is non-null.
            MessagePublished?.Invoke(this, e);
        }
    }
}