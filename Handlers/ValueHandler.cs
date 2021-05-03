using PublishSubscribePatternSample.Events;
using System;

namespace PublishSubscribePatternSample.Handlers
{
    public class ValueHandler : IHandler
    {
        public bool CanHandle(EventArgs e)
        {
            return e is ValueEvent;
        }

        public void Handle(EventArgs e)
        {
            var eventContent = e as ValueEvent;
            Console.WriteLine("Supplied Value is: " + eventContent.Value);
        }
    }
}