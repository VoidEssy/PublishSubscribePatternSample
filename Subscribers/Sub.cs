using PublishSubscribePatternSample.Events;
using PublishSubscribePatternSample.Handlers;
using PublishSubscribePatternSample.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublishSubscribePatternSample.Subscribers
{
    public class Sub
    {
        private readonly string ID;
        private readonly string Description;
        private readonly IHandler[] Handlers; //= new IHandler[] { new ValueHandler(), new ObjectHandler(), new CollectionHandler() };
        public Sub(string id, string description, Pub pub, IHandler[] handlers)
        {
            ID = id;
            Handlers = handlers;
            Description = description;

            // Subscribe to the events
            pub.CreateEvent += HandleEvent;
        }

        // Define what actions to take when the event is raised.
        void HandleEvent(object sender, EventArgs e)
        {
            // The If Statement is added as an after thought to keep the console clean.
            if (Handlers.Any(x => x.CanHandle(e)))
            {
                Console.WriteLine($"{ID} received: {e.GetType().Name}");

                foreach (var handler in Handlers)
                {
                    bool canParse = handler.CanHandle(e);
                    if (canParse)
                    {
                        handler.Handle(e);
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine($"{ID} Received a message it doesn't care about");
            }
            Console.WriteLine($"!!!!!!!!{Description}!!!!!!!!");
            Console.WriteLine("-----------------------");
        }
    }
}
