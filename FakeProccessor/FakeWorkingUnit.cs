using System;
using System.Collections.Generic;

namespace FakeProccessor
{
    public class FakeWorkingUnit
    {
        /// <summary>
        /// Lets expand our list a bit via mutation.
        /// </summary>
        /// <param name="dataToMutate"></param>
        public static void MyFakeDataMutation(List<string> dataToMutate)
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
        public static int MyFakeDataMutation(int dataToMutate)
        {
            return dataToMutate + 1337;
        }

        /// <summary>
        /// Well since in this example we are using string in order to avoid constructing an object.
        /// Lets do just that, by for example generating a GUID and stuffing it in there
        /// </summary>
        /// <param name="dataToMutate"></param>
        public static object MyFakeDataMutation(object dataToMutate)
        {
            dataToMutate = Guid.NewGuid().ToString(); // can instantly return but this is here to illustrate some kind of operation on the data.
            return dataToMutate;
        }

    }
}
