using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListTest
{
    class Program
    {
        static void Main(string[] args)
        {
            basicTest();
        }

        private static void basicTest()
        {
            ArrayList names = new ArrayList();
            names.Add("Mike");
            names.Add("Beata");
            names.Add("Raymond");
            names.Add("Bernica");
            names.Add("jenneifer");
            Console.WriteLine("The original list of names: ");
            foreach (Object name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
            string[] newNames = new string[] { "David", "Michael" };
            ArrayList moreName = new ArrayList();
            moreName.Add("Terrill");
            moreName.Add("Donnie");
            moreName.Add("Mayo");
            moreName.Add("Clayton");
            moreName.Add("Akisa");
            names.InsertRange(0, newNames); //插入到指定索引处
            names.AddRange(moreName); //添加到末尾
            Console.WriteLine("The new lsit of names: ");
            foreach(object name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
