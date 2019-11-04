using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTest
{
    class SelectionSortTest
    {
        CArray nums = null;
        public SelectionSortTest()
        {
            Console.WriteLine("------------SelectionSort------------");
            nums = CArray.InitArray();
            Console.Write("before: ");
            nums.DisplayElements();
            SelectionSort();
            Console.WriteLine("-------------------------------------");
        }

        /// <summary>
        /// 从起始开始将第一个元素与数组中的其他元素进行比较 将最小的元素放在第0个位置、
        /// 再从第一个位置开始再次进行排序操作
        /// </summary>
        private void SelectionSort()
        {
            int min, temp;
            for(int outer = 0; outer <= nums.Upper; outer++)
            {
                min = outer;
                for(int inner = outer + 1; inner <= nums.Upper; inner++)
                {
                    if(nums.Arr[inner] < nums.Arr[min])
                    {
                        min = inner;
                    }
                }
                temp = nums.Arr[outer];
                nums.Arr[outer] = nums.Arr[min];
                nums.Arr[min] = temp;
                nums.DisplayElements();
            }
        }

    }
}
