using System;
using System.Collections.Generic;

namespace Events
{
    public class CollectionEvent : EventArgs
    {
        public List<string> Collection { get; set; }

        public CollectionEvent(List<string> collection)
        {
            Collection = collection;
        }
    }
}