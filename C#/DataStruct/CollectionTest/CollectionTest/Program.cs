using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest
{
    class Program
    {
        static void Swap<T>(ref T val1, ref T val2)
        {
            T temp;
            temp = val1;
            val1 = val2;
            val2 = temp;
        }

        static void Main(string[] args)
        {
            //Struct
            //StructsTest();
            //Collection
            //CollectionTest();
            //Generic
            //GenericTest();
            //Time
            TimeTest();
            Console.ReadKey();
        }

        private static void StructsTest()
        {
            StructTest collect = new StructTest();
        }

        private static void CollectionTest()
        {
            Collection names = new Collection();
            names.Add("David");
            names.Add("Bernica");
            names.Add("Raymond");
            names.Add("Clayton");
            foreach (Object name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("Number of names:" + names.Count());
            names.Remove("Raymond");
            Console.WriteLine("Number of names:" + names.Count());
            names.Clear();
            Console.WriteLine("Number of names:" + names.Count());
        }

        private static void GenericTest()
        {
            int num1 = 100;
            int num2 = 200;
            Console.WriteLine("num1:" + num1);
            Console.WriteLine("num2:" + num2);
            Swap<int>(ref num1, ref num2);
            Console.WriteLine("num1:" + num1);
            Console.WriteLine("num2:" + num2);
            string str1 = "Sam";
            string str2 = "Tom";
            Console.WriteLine("String 1:" + str1);
            Console.WriteLine("String 2:" + str2);
            Swap<string>(ref str1, ref str2);
            Console.WriteLine("String 1:" + str1);
            Console.WriteLine("String 2:" + str2);
        }

        private static void TimeTest()
        {
            int[] nums = new int[100000];
            BuildArray(nums);
            Timing tObj = new Timing();
            tObj.startTime();
            DisplayNums(nums);
            tObj.StopTime();
            Console.WriteLine("time {0}: " + tObj.Result().TotalSeconds);
        }

        private static void BuildArray(int[] arr)
        {
            for(int i = 0; i < 100000; i++)
            {
                arr[i] = i;
            }
        }

        private static void DisplayNums(int[] arr)
        {
            for(int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
