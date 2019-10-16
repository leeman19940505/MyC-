using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureLib.tools
{
    interface IMySort
    {
        //void InsertionSort(int[] a); //插入排序

        void InsertionSort<T>(T[] a) where T : IComparable;
    }
}
