using Events;
using System;

namespace Subscribers.Handlers
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