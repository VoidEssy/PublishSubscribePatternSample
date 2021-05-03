using System;
using System.Collections.Generic;
using System.Text;

namespace PublishSubscribePatternSample.Events
{
    public class ObjectEvent : EventArgs
    {
        public object SomeObject { get; set; }

        public ObjectEvent(object someObject)
        {
            SomeObject = someObject;
        }
    }
}
