using System;

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