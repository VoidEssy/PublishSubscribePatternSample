using PublishSubscribePatternSample.Events;
using PublishSubscribePatternSample.Handlers;
using PublishSubscribePatternSample.Publisher;
using PublishSubscribePatternSample.Subscribers;
using System;
using System.Collections.Generic;

namespace PublishSubscribePatternSample
{
    class Program
    {
        /// <summary>
        /// Consider this your playground where you can use Method Signatures to configure and manipulate the created
        /// Subscribers and Data
        /// </summary>
        static void Main(string[] args)
        {
            Pub publisher = new Pub();
            var sub1 = new Sub("Sub1", "I Only care about numerical values", publisher, new IHandler[] { new ValueHandler() });
            var sub2 = new Sub("Sub2", "I Only care about Lists", publisher, new IHandler[] { new CollectionHandler() });
            var sub3 = new Sub("Sub3", "I Only care about Objects", publisher, new IHandler[] { new ObjectHandler() });
            var sub4 = new Sub("Sub4", "I care about everything", publisher, new IHandler[] { new ValueHandler(), new ObjectHandler(), new CollectionHandler() });



            publisher.Raise(69);
            publisher.Raise(GetInitialListOfStrings());
            publisher.Raise(1337);


            Console.WriteLine("Hit Enter to kill this");

            Console.ReadLine();
        }

        private static List<string> GetInitialListOfStrings()
        {
            List<string> strings = new List<string>
            {
                "Banana",
                "Peaches",
                "Ananas",
                "Milk",
            };

            return strings;
        }

        private void MyFakeDataMutation(List<string> dataToMutate)
        {
            dataToMutate.Add("Nuke");
            dataToMutate.Add("Furby");
            dataToMutate.Add("Sputnik V");
        }

        private void MyFakeDataMutation(int dataToMutate)
        {
            dataToMutate += 1337;
        }

        private void MyFakeDataMutation(object dataToMutate)
        {
            // Will add later maybe
        }
    }
}
