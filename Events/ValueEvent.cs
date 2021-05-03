using System;
using System.Collections.Generic;
using System.Text;

namespace PublishSubscribePatternSample.Events
{
    public class ValueEvent : EventArgs
    {
        public int Value { get; set; }

        public ValueEvent(int value)
        {
            Value = value;
        }
    }
}
