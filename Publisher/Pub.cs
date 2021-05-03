using PublishSubscribePatternSample.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PublishSubscribePatternSample.Publisher
{
    public class Pub
    {
        public event EventHandler<EventArgs> CreateEvent;

        public void Raise(List<string> collection)
        {
            CreateEvent(this, new CollectionEvent(collection));
        }

        public void Raise(int value)
        {
            CreateEvent(this, new ValueEvent(value));
        }

        public void Raise(object someObject)
        {
            CreateEvent(this, new ObjectEvent(someObject));
        }
    }
}
