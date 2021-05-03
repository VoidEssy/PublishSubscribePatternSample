using PublishSubscribePatternSample.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PublishSubscribePatternSample.Publisher
{
    /// <summary>
    /// Publisher is responsible for creating the events based on input provided from the Program.CS
    /// It has right now 3 overloaded, 
    /// Raise an event with collection
    /// Raise an event with int value
    /// Raise an event with an object
    /// </summary>
    public class Pub
    {
        /// <summary>
        /// The event that is created and subscribed to buy Subscribers
        /// </summary>
        public event EventHandler<EventArgs> CreatedEvent;

        /// <summary>
        /// Will raise an event that holds a collection of strings
        /// </summary>
        /// <param name="collection"></param>
        public void Raise(List<string> collection)
        {
            CreatedEvent(this, new CollectionEvent(collection));
        }

        /// <summary>
        /// Will raise an event with a single int value in it.
        /// </summary>
        /// <param name="value"></param>
        public void Raise(int value)
        {
            CreatedEvent(this, new ValueEvent(value));
        }

        /// <summary>
        /// Will raise an event with some object
        /// </summary>
        /// <param name="someObject"></param>
        public void Raise(object someObject)
        {
            CreatedEvent(this, new ObjectEvent(someObject));
        }
    }
}
