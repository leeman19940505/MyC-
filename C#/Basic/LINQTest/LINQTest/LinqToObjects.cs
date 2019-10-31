using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTest
{
    class LinqToObjects
    {
        public static void OldQueryTest()
        {
            List<int> inputArray = new List<int>();
            for(int i = 1; i < 10; i++)
            {
                inputArray.Add(i);
            }

            Console.WriteLine("old: ");
            OldQuery(inputArray);
            Console.Read();
        }

        //use foreach
        public static void OldQuery(List<int> collection)
        {
            List<int> queryResults = new List<int>();
            foreach(int item in collection)
            {
                if(item % 2 == 0)
                {
                    queryResults.Add(item);
                }
            }

            foreach(int item in queryResults)
            {
                Console.Write(item + "  ");
            }
        }

        public static void LinqQueryTest()
        {
            List<int> inputArray = new List<int>();
            for(int i = 1; i < 10; i++)
            {
                inputArray.Add(i);
            }

            Console.WriteLine("linq: ");
            LinqQuery(inputArray);
        }

        public static void LinqQuery(List<int> collection)
        {
            //创建查询表达式来获得集合中为偶数的元素
            //var类型预先不用知道变量的类型；根据你给变量赋值来判定变量属于什么类型
            //var必须是局部变量
            var queryResult = from item in collection
                              where item % 2 == 0
                              select item;

            foreach(var item in queryResult)
            {
                Console.Write(item + " ");
            }
        }
    }
}
