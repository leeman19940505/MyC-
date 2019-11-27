using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTest
{
    /// <summary>
    /// 插入排序
    /// </summary>
    class InsertionSortTest
    {
        CArray nums = null;

        public InsertionSortTest()
        {
            Console.WriteLine("--------------BubbleSort-------------");
            nums = CArray.InitArray();
            Console.Write("before: ");
            nums.DisplayElements();
            InsertionSort();
            Console.WriteLine("-------------------------------------");
        }

        private void InsertionSort()
        {
            int inner, temp;
            for(int outer = 1; outer <= nums.Upper; outer++)
            {
                temp = nums.Arr[outer];
                inner = outer;
                while(inner > 0 && nums.Arr[inner - 1] >= temp)
                {
                    nums.Arr[inner] = nums.Arr[inner - 1];
                    inner -= 1;
                }
                nums.Arr[inner] = temp;
                nums.DisplayElements();
            }
        }
    }
}
