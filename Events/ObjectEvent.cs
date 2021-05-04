using System;

namespace Events
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