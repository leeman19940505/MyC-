using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DicSample1();
            DicSample2();
            DicSample3();

            Console.ReadKey();
        }

        public static void DicSample1()
        {
            Dictionary<String, String> pList = new Dictionary<string, string>();
            try
            {
                if(pList.ContainsKey("Item1") == false)
                {
                    pList.Add("Item1", "ZheJiang");
                }
                if(pList.ContainsKey("Item2") == false)
                {
                    pList.Add("Item2", "ShangeHai");
                }
                else
                {
                    pList["Item2"] = "ShangHai";
                }
                if(pList.ContainsKey("Item3") == false)
                {
                    pList.Add("Item3", "BeiJiang");
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }

            //判断是否存在相应的key并显示
            if(pList.ContainsKey("Item1"))
            {
                Console.WriteLine("Output: " + pList["Item1"]);
            }

            //遍历Key
            foreach(var key in pList.Keys)
            {
                Console.WriteLine("Output Key: {0}", key);
            }

            //遍历Value
            foreach(String value in pList.Values)
            {
                Console.WriteLine("Output Value: {0}", value);
            }

            //遍历Key和Value
            foreach(var dic in pList)
            {
                Console.WriteLine("Output Key : {0}, Value : {1}", dic.Key, dic.Value);
            }
        }

        /// <summary>
        /// Dictionary的Value为一个数组
        /// </summary>
        public static void DicSample2()
        {
            Dictionary<String, String[]> dic = new Dictionary<String, String[]>();
            String[] ZheJiang = { "Huzhou", "HangZhou", "TaiZhou" };
            String[] ShangHai = { "Budong", "Buxi" };
            dic.Add("ZJ", ZheJiang);
            dic.Add("SH", ShangHai);
            Console.WriteLine("Output :" + dic["ZJ"][0]);
        }

        /// <summary>
        /// Dictionary的Value为一个类
        /// </summary>
        public static void DicSample3()
        {
            Dictionary<String, Student> stuList = new Dictionary<string, Student>();
            Student stu = null;
            for(int i = 0; i < 3; i++)
            {
                stu = new Student();
                stu.Name = i.ToString();
                stu.Name = "StuName" + i.ToString();
                stuList.Add(i.ToString(), stu);
            }

            foreach(var student in stuList)
            {
                Console.WriteLine("Output : Key {0}, Num : {1}, Name {2}", student.Key, student.Value.Num, student.Value.Name);
            }
        }

    }
}
