using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTest
{
    class BubbleSortTest
    {
        CArray nums = null;

        public BubbleSortTest()
        {
            Console.WriteLine("--------------BubbleSort-------------");
            nums = CArray.InitArray();
            Console.Write("before: ");
            nums.DisplayElements();
            BubbleSort();
            Console.WriteLine("-------------------------------------");
        }

        /// <summary>
        /// 较小的值浮动到左侧 较大的值浮动到右侧 
        /// 多次遍历数组 比较相邻的值 如果左侧的数值大于右侧数值就进行交换
        /// </summary>
        public void BubbleSort()
        {
            int temp;
            for(int outer = nums.Upper; outer >= 1; outer--)
            {
                for(int inner = 0; inner <= outer - 1; inner++)
                {
                    if((int)nums.Arr[inner] > nums.Arr[inner + 1])
                    {
                        temp = nums.Arr[inner];
                        nums.Arr[inner] = nums.Arr[inner + 1];
                        nums.Arr[inner + 1] = temp;
                    }
                }
                nums.DisplayElements();
            }
        }

    }
}
