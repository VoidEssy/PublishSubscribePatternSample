using FakeDataProvider;
using FakeProccessor;
using Publisher;
using Subscribers;
using Subscribers.Handlers;
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
            var fakeCollection = FakeProvider.GetInitialListOfStrings();
            FakeWorkingUnit.MyFakeDataMutation(fakeCollection);
            #endregion Fake Data Manipulations Before publishing to illustrate mutations

            publisher.Raise(FakeWorkingUnit.MyFakeDataMutation(FakeProvider.GetInitialValue()));
            publisher.Raise(fakeCollection);
            publisher.Raise(FakeWorkingUnit.MyFakeDataMutation(string.Empty)); // This is used to trigger object handler and subscriber since string is an object that shares traits with primitives :)

            Console.WriteLine("Hit Enter to kill this");

            Console.ReadLine();
        }
    }
}