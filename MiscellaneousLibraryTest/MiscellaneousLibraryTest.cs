using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityLibraries;

namespace MiscellaneousLibraryTest
{
    [TestClass]
    public class MiscellaneousLibraryTest
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

        [TestMethod]
        public void TestCheckForAllValues() {
            Random random = new Random();
            int randomListSize = random.Next(100);
            int[] testArray = Miscellaneous.RandomIntegerOrder(randomListSize);

            for (int i = 0; i < randomListSize; i++) {
                for (int j = 0; j <= randomListSize; j++) {
                    if (testArray[i] == j) {
                        Console.Write(j + ",");
                        break;
                    }

                    if (testArray[i] == randomListSize) {
                        Assert.Fail();
                    }
                }
            }
        }
        
        [TestMethod]
        public void TestLoopSafeGuardPassInfiniteFunctionAsParameter() {
            float timeOut = 2;
            bool result = false;
            try {
                Console.WriteLine("External Function Start");
                Miscellaneous.LoopSafeGuard( 
                    ()=> {
                        while (true) {
                            result = false;
                        }
                    } ,timeOut);
                Console.WriteLine("External Function End");
            } finally {
                //Console.WriteLine("Pass");
                result = true;
                Assert.IsTrue(result);
            }

        }

        [TestMethod]
        public void TestLoopSafeGuardPassNonInfiniteFunctionAsParameter() {
            float timeOut = 2;
            int sleep = 1;
            bool result = false;
            try {
                //Console.WriteLine("External Function Start");
                Miscellaneous.LoopSafeGuard( 
                    () => {
                        Thread.Sleep(sleep);
                        result = true;
                        //Console.WriteLine("Pass");
                    }, timeOut);
                //Console.WriteLine("External Function End");
            } finally {
                Assert.IsTrue(result);
            }

        }

        [TestMethod]
        public void TestFunctionPairPermutation() {
            int[] intArray = {1,2,3,4,5};
            int[,] result=new int[intArray.Length,intArray.Length];
            try {
                result=Miscellaneous<int>.FunctionPairPermutation(
                    intArray,
                    (x, y) => {
                        //Console.WriteLine("{0}+{1}={2}", x, y, (x + y));
                        return (x + y);
                    });

            } finally {
                for(int i = 0; i < result.GetLength(0); i++) {
                    for(int j=0;j < result.GetLength(1); j++) {
                        //Console.WriteLine("result [{0}][{1}]= {2}", i,j,result[i,j]);
                        int expected = intArray[i]+intArray[j];
                        Assert.AreEqual<int>(expected, result[i, j]);
                    }
                }
            }

        }

        [TestMethod]
        public void CompareCsvValuesEquivalentInput() {
            string input1 = "a,b,c,d";
            string input2 = "a,b,c,d";
            bool result = Miscellaneous.CompareCsvValues(input1, input2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CompareCsvValuesNotEquivalentInput() {
            string input1 = "a,b,c,d";
            string input2 = "a,b,c,da";
            bool result = Miscellaneous.CompareCsvValues(input1, input2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CompareCsvValuesExcludeIndexEquivalentInput() {
            string input1 = "a,b,c,d";
            string input2 = "a,b,c,f";
            int excludeIndex = 3;
            bool result = Miscellaneous.CompareCsvValues(input1, input2, excludeIndex);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CompareCsvValuesExcludeMultipleIndicesEquivalentInput() {
            string input1 = "a,b,c,d";
            string input2 = "a,bb,cc,d";
            int[] excludeIndice = { 1, 2 };
            bool result = Miscellaneous.CompareCsvValues(input1, input2, excludeIndice);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CompareCsvValuesExcludeMultipleIndicesNotEquivalentInput() {
            string input1 = "a,b,c,d";
            string input2 = "a,bb,cc,dd";
            int[] excludeIndice = { 1, 2 };
            bool result = Miscellaneous.CompareCsvValues(input1, input2, excludeIndice);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CompareCsvValuesExcludeMultipleIndices2NotEquivalentInput() {
            string input1 = "a,b,c,d";
            string input2 = "a,bb,cc,dd";
            int index1 = 1;
            int index2 = 2;

            bool result = Miscellaneous.CompareCsvValues(input1, input2, index1,index2);
            Assert.IsFalse(result);
        }



    }
}
