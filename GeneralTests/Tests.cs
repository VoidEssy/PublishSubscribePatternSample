using Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Subscribers.Handlers;

namespace GeneralTests
{
    [TestClass]
    public class Tests
    {
        /// <summary>
        /// We could add 1 for every single handler's every single method.
        /// </summary>
        [TestMethod]
        public void HandlerCanHandleTest()
        {
            var objectHandler = new ObjectHandler();
            var canHandle = objectHandler.CanHandle(new ObjectEvent(string.Empty));
            Assert.IsTrue(canHandle);
        }

        /// <summary>
        /// Since all our HandleMethods are void, we can't check for mutations or response but we could check what will happen if there is a null.
        /// </summary>
        [TestMethod]
        public void HandlerHandleNullTest()
        {
            var objectHandler = new ObjectHandler();
            objectHandler.Handle(new ObjectEvent(null));
        }

        /// <summary>
        /// Check that our CanHandle assesses correctly the type supplied
        /// </summary>
        [TestMethod]
        public void HandlerCantHandle()
        {
            var valueHandler = new ValueHandler();
            var canHandle = valueHandler.CanHandle(new ObjectEvent(string.Empty));
            Assert.IsFalse(canHandle);
        }
    }
}