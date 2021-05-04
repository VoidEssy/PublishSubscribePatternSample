using FakeProccessor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GeneralTests
{
    [TestClass]
    public class FakeWorkerTests
    {
        /// <summary>
        /// Check if our FakeWorker increases the value by 1337
        /// </summary>
        [TestMethod]
        public void GetInitalValueTest()
        {
            int value = FakeWorkingUnit.MyFakeDataMutation(0);
            Assert.AreEqual(1337, value);
        }

        /// <summary>
        /// Check if our FakeWorker adds new elements to the list by mutating it.
        /// </summary>
        [TestMethod]
        public void GetInitialListOfStringsTest()
        {
            var listToMutate = new List<string>();
            FakeWorkingUnit.MyFakeDataMutation(listToMutate);
            Assert.IsTrue(listToMutate.Count != 0);
        }
    }
}
