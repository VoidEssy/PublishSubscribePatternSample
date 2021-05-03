using PublishSubscribePatternSample.Handlers;
using PublishSubscribePatternSample.Publisher;
using System;
using System.Linq;

namespace PublishSubscribePatternSample.Subscribers
{
    public class Sub
    {
        private readonly string ID;
        private readonly string Description;
        private readonly IHandler[] Handlers; //= new IHandler[] { new ValueHandler(), new ObjectHandler(), new CollectionHandler() }; // Older version for reference, if you want every Sub to be able to handle every message
        private readonly ConsoleColor Color;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">For ease of identification when reading logs / console</param>
        /// <param name="description"> For quick contextual understanding when top level skimming Program.cs instead of reading the Handlers declared</param>
        /// <param name="pub"> Publisher to subscribe to </param>
        /// <param name="handlers"> Collection of Handlers that fit the said Subscriber </param>
        public Sub(string id, string description, Pub pub, IHandler[] handlers)
        {
            ID = id;
            Handlers = handlers;
            Description = description;

            // Subscribe to the events
            pub.CreatedEvent += HandleEvent;

            Color = GetRandomConsoleColor();
        }

        /// <summary>
        /// Executed whenever an event is picked up by said Subscriber
        /// </summary>
        /// <param name="sender"> Source of event in this case Pub</param>
        /// <param name="e"> Content of event </param>
        private void HandleEvent(object sender, EventArgs e)
        {
            // Added for ease of reading
            SetMyColor();
            // The If Statement is added as an after thought to keep the console clean.
            if (Handlers.Any(x => x.CanHandle(e)))
            {
                Console.WriteLine($"{ID} received: {e.GetType().Name}");

                // Below is execution of strategy pattern where we go through collection of handlers issued to us in order to find if any can handle them.
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
            Console.WriteLine();
        }

        private void SetMyColor()
        {
            Console.ForegroundColor = Color;
        }

        #region IGNORE THIS ADDED FOR PERSONAL COMFORT WHEN LOOKING AT CONSOLE

        private static ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(new Random().Next(consoleColors.Length));
        }

        #endregion IGNORE THIS ADDED FOR PERSONAL COMFORT WHEN LOOKING AT CONSOLE
    }
}