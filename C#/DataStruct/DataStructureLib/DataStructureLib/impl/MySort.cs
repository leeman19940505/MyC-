using DataStructureLib.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureLib.impl
{
    class MySort : IMySort
    {
        //public void InsertionSort(int[] a)
        //{
        //    int len = a.Length;
        //    int j;
        //    int val;
        //    for(int i = 0; i < len; i++)
        //    {
        //        j = i; //标记
        //        val = a[i]; //当前值
        //        while (j > 0 && a[j - 1] > val) //前一个值小于当前值时推出
        //        {
        //            a[j] = a[j - 1]; //前一个只大于当前值 前一个值向后移动
        //            j--; //标记向前移
        //        }
        //        a[j] = val; //当前值排序后的位置
        //    }
        //}

        public void InsertionSort<T>(T[] a) where T : IComparable
        {
            int len = a.Length;
            int j;
            T val;
            for(int i = 0; i < len; i++)
            {
                j = i;
                val = a[i];
                while(j > 0 && a[j - 1].CompareTo(val) > 0)
                {
                    a[j] = a[j - 1];
                    j--;
                }
                a[j] = val;
            }
        }
    }
}
