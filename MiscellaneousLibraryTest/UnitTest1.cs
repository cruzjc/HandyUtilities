using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityLibraries;

namespace MiscellaneousLibraryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCheckForDuplicates()
        {
            Random random = new Random();
            int randomListSize = random.Next(100);
            int[] testArray = Miscellaneous.RandomIntegerOrder(randomListSize);
            bool result = true;
            

            for(int i = 0; i < randomListSize; i++)
            {
                for(int j = 0; j < randomListSize; j++)
                {
                    if (i == j) continue;

                    if (testArray[i] == testArray[j])
                    {
                        result= false;
                        break;
                    }

                }
            }
            Assert.IsTrue(result);

            foreach (int i in testArray){
                Console.Write(i + ",");
            }
        }
    }
}
