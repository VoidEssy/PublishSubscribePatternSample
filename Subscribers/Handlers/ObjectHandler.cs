using Events;
using System;

namespace Subscribers.Handlers
{
    public class ObjectHandler : IHandler
    {
        public bool CanHandle(EventArgs e)
        {
            return e is ObjectEvent;
        }

        public void Handle(EventArgs e)
        {
            var eventContent = e as ObjectEvent;
            Console.WriteLine($"Is an actual object: {eventContent.SomeObject is object}");
            Console.WriteLine("Well this is an object, we could get list of properties and bla bla bla using reflection but that's not part of the task");
        }
    }
}