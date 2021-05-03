using System;
using System.Collections.Generic;
using System.Text;

namespace PublishSubscribePatternSample.Events
{
    public class ObjectEvent : EventArgs
    {
        public object Value { get; set; }

        public ObjectEvent(object someObject)
        {
            Value = someObject;
        }
    }
}
