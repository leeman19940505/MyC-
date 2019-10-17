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

        /// <summary>
        /// 插入排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
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

        /// <summary>
        /// 希尔排序 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        public void ShellSort<T>(T[] a) where T : IComparable
        {
            
        }

        /// <summary>
        /// 待测试
        /// </summary>
        /// <param name="a"></param>
        public void ShellSort(int[] a)
        {
            int len = a.Length;
            int j; //当前下标
            int temp; //当前值
            int increment = (len / 2); //增量

            while (increment > 0) //每次分组间隔减半
            {
                for (int i = increment; i < len; i++)
                {
                    j = increment;
                    temp = a[j];
                    //执行插入排序
                    while(j >= increment && a[j - increment] > temp)
                    {
                        //前面的数较大时 当前位置等于前面的数（较大的数）
                        a[j] = a[j - increment];
                        //当前位置移动到前面的数（较大的数的位置）
                        j -= increment; 
                    }
                    a[j] = temp; //给当前位置赋值 
                }

                increment /= 2;
            }
        }
    }
}
