using PublishSubscribePatternSample.Handlers;
using PublishSubscribePatternSample.Publisher;
using PublishSubscribePatternSample.Subscribers;
using System;
using System.Collections.Generic;

namespace PublishSubscribePatternSample
{
    internal class Program
    {
        /// <summary>
        /// Consider this your playground where you can use Method Signatures to configure and manipulate the created
        /// Subscribers and Data
        /// </summary>
        private static void Main(string[] args)
        {
            Pub publisher = new Pub();
            var sub1 = new Sub("Sub1", "I Only care about numerical values", publisher, new IHandler[] { new ValueHandler() });
            var sub2 = new Sub("Sub2", "I Only care about Lists", publisher, new IHandler[] { new CollectionHandler() });
            var sub3 = new Sub("Sub3", "I Only care about Objects", publisher, new IHandler[] { new ObjectHandler() });
            var sub4 = new Sub("Sub4", "I care about everything", publisher, new IHandler[] { new ValueHandler(), new ObjectHandler(), new CollectionHandler() });

            #region Fake Data Manipulations Before publishing to illustrate mutations
            //Lets assume you got something from layer above and now you need to change it before passing it to the Subscribers
            var fakeCollection = GetInitialListOfStrings();
            MyFakeDataMutation(fakeCollection);
            #endregion

            publisher.Raise(MyFakeDataMutation(69));
            publisher.Raise(fakeCollection);
            publisher.Raise(MyFakeDataMutation(string.Empty)); // This is used to trigger object handler and subscriber since string is an object that shares traits with primitives :)

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

        /// <summary>
        /// Lets expand our list a bit via mutation.
        /// </summary>
        /// <param name="dataToMutate"></param>
        private static void MyFakeDataMutation(List<string> dataToMutate)
        {
            dataToMutate.Add("Nuke");
            dataToMutate.Add("Furby");
            dataToMutate.Add("Sputnik V");
        }

        /// <summary>
        /// Lets increase our value by changing it and returning the new value
        /// This is done because primitives are passed by Value and as such can't be mutatated and it's a bad practice to mutate primitives
        /// </summary>
        /// <param name="dataToMutate"></param>
        private static int MyFakeDataMutation(int dataToMutate)
        {
            return dataToMutate += 1337;
        }

        /// <summary>
        /// Well since in this example we are using string in order to avoid constructing an object.
        /// Lets do just that, by for example generating a GUID and stuffing it in there
        /// </summary>
        /// <param name="dataToMutate"></param>
        private static object MyFakeDataMutation(object dataToMutate)
        {
            dataToMutate = Guid.NewGuid().ToString(); // can instantly return but this is here to illustrate some kind of operation on the data.
            return dataToMutate;
        }
    }
}