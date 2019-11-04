using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTest
{
    class CArray
    {
        private int[] arr;
        private int upper;
        private int numElements;

        public int Upper
        {
            get
            {
                return upper;
            }
            set
            {
                upper = value;
            }
        }

        public int[] Arr
        {
            get
            {
                return arr; 
            }
            set
            {
                arr = value;
            }
        }

        public CArray(int size)
        {
            arr = new int[size];
            upper = size - 1;
            numElements = 0;
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="item"></param>
        public void Insert(int item)
        {
            arr[numElements] = item;
            numElements++;
        }

        /// <summary>
        /// 输出
        /// </summary>
        public void DisplayElements()
        {
            for(int i = 0; i <= upper; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        public void Clear()
        {
            for(int i = 0; i <= upper; i++)
            {
                arr[i] = 0;
            }
            numElements = 0;
        }

        public static CArray InitArray()
        {
            CArray nums = new CArray(10);
            Random rnd = new Random(100);
            for (int i = 0; i < 10; i++)
            {
                nums.Insert(rnd.Next(0, 100));
            }

            return nums;
        }
    }
}
