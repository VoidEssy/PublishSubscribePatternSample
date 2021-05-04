using FakeDataProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GeneralTests
{
    [TestClass]
    public class FakeProviderTests
    {
        /// <summary>
        /// Check if our FakeProvider gives us a pos number
        /// </summary>
        [TestMethod]
        public void GetInitalValueTest()
        {
            int value = FakeProvider.GetInitialValue();
            Assert.IsTrue(value >= 0);
        }

        /// <summary>
        /// Check if we get a list containing 4 strings
        /// </summary>
        [TestMethod]
        public void GetInitialListOfStringsTest()
        {
            List<string> listOfStrings = FakeProvider.GetInitialListOfStrings();
            Assert.AreEqual(listOfStrings.Count, 4);
        }
    }
}