using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[100];
            StreamReader numFile = File.OpenText(@"../../numbers.txt");
            for(int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Convert.ToInt32(numFile.ReadLine());
            }

            int searchNumer;
            Console.Write("Enter a number to search for: ");
            searchNumer = Convert.ToInt32(Console.ReadLine(), 10);
            int foundAt;
            foundAt = SeqSearch(numbers, searchNumer);

            if(foundAt >= 0)
            {
                Console.WriteLine(searchNumer + " is in the array at position " + foundAt);
            }
            else
            {
                Console.WriteLine(searchNumer + " is not in the array");
            }

            Console.ReadKey();
        }

        private static int SeqSearch(int[] arr, int sValue)
        {
            for(int index = 0; index < arr.Length; index++)
            {
                if(arr[index] == sValue)
                {
                    return index;
                }
            }
            return -1;
        }
    }
}
