using System;
using System.Threading;
using System.Diagnostics;

//passing functions as a parameter for methods
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/using-delegates

namespace UtilityLibraries
{
    public class Miscellaneous {

        /// <summary>
        /// random order generator function
        /// 
        /// generates a list from 0 to 'n'
        /// iterates through the list starting
        /// at zero, and swaps with a random index
        /// 
        /// </summary>
        /// <param name="listSize">
        /// the length of a list size 'n'
        /// </param>
        /// <returns>
        /// an int array containing numbers from
        /// 0 (inclusive) up to 'n' (exclusive)
        /// not in order
        /// </returns>
        public static int[] RandomIntegerOrder(int listSize) {
            int[] result = new int[listSize];

            //O(n)
            for (int i = 0; i < listSize; i++) {
                result[i] = i;
            }


            //O(n)
            int randomIndex;
            int temp;
            Random random = new Random();
            for (int i = 0; i < listSize; i++) {
                randomIndex = random.Next(listSize);
                temp = result[i];
                result[i] = result[randomIndex];
                result[randomIndex] = temp;
            }
            return result;
        }


        /// <summary>
        /// a method used to help prevent infinite loops
        /// 
        /// start a given function in a separate thread,
        /// while the main thread uses a stopwatch to 
        /// call a timeout if needed
        /// </summary>
        /// <param name="function">
        /// a method (no parameters) which has a loop structure
        /// </param>
        /// <param name="timeOut">
        /// the allowed time for the given function to live
        /// </param>
        public static void LoopSafeGuard(Action function, float timeOut) {
            Console.WriteLine("LoopSafeGuard Start");
            Stopwatch stopwatch = new Stopwatch();

            ThreadStart childThreadReference = new ThreadStart(function);
            Thread loopingThread = new Thread(childThreadReference);
            stopwatch.Start();
            loopingThread.Start();
            while (stopwatch.Elapsed.TotalSeconds < timeOut) {
                //Console.WriteLine("Time remaining:" + (timeOut - stopwatch.Elapsed.TotalSeconds));
                if (stopwatch.Elapsed.Seconds >= timeOut) {
                    loopingThread.Abort();
                }

            }
            stopwatch.Stop();
            Console.WriteLine("LoopSafeGuard End");
        }        


    }

    //takes in a array of a type
    //takes in a function 'f(x,y)'
    //takes each pair of permutations from 
    //array and calls f(x,y) with the pair
    //of values as parameters
    //returns a 2d array of given type filled
    //with output of function
    public class Miscellaneous<T> {
        public static T[,] FunctionPairPermutation(T[] array,Func<T,T,T> function) {
            T[,] result = new T[array.Length,array.Length];
            for (int i = 0; i < array.Length; i++) {
                for(int j=0; j< array.Length; j++) {
                    //if (i == j) continue;

                    result[i,j]=function(array[i],array[j]);
                }

            }
            return result;
        }
    }

}
