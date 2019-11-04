using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTest 
{
    class Program  
    {
        static void Main(string[] args)
        {
            BubbleSortTest bubble = new BubbleSortTest(); //冒泡排序
            SelectionSortTest selection = new SelectionSortTest(); //选择排序

            Console.ReadKey();
        }
    }
}
