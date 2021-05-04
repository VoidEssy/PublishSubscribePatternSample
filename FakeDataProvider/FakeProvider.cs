using System;
using System.Collections.Generic;

namespace FakeDataProvider
{
    public class FakeProvider
    {
        public static List<string> GetInitialListOfStrings()
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

        public static int GetInitialValue()
        {
            return new Random().Next(9000);
        }
    }
}
