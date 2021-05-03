using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PublishSubscribePatternSample.Events
{
    public class CollectionEvent: EventArgs
    {
        public List<string> Collection { get; set; }

        public CollectionEvent(List<string> collection)
        {
            Collection = collection;
        }
    }
}
