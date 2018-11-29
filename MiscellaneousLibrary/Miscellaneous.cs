using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLibraries
{
    public class Miscellaneous
    {

        public static int[] RandomIntegerOrder(int listSize)
        {
            int[] result =new int[listSize];

            //O(n)
            for(int i = 0; i < listSize; i++)
            {
                result[i] = i;
            }


            //O(n)
            int randomIndex;
            int temp;
            Random random = new Random();
            for(int i = 0; i < listSize; i++)
            {
                randomIndex = random.Next(listSize);
                temp = result[i];
                result[i] = result[randomIndex];
                result[randomIndex] = temp;
            }



            return result;           
        }
        
    }
}
