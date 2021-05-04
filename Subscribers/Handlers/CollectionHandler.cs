using Events;
using System;

namespace Subscribers.Handlers
{
    public class CollectionHandler : IHandler
    {
        public bool CanHandle(EventArgs e)
        {
            return e is CollectionEvent;
        }

        public void Handle(EventArgs e)
        {
            var eventContent = e as CollectionEvent;
            foreach (var str in eventContent.Collection)
            {
                Console.WriteLine(str);
            }
        }
    }
}