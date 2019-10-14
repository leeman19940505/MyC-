using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeYou
{
    class Statements
    {
        //if
        public void statementsIF()
        {
            bool condition = true;
            int x = 13;
            
            if(condition)
            {
                Console.WriteLine("变量设置为真");
            }
            else
            {
                Console.WriteLine("变量设置为假");
            }

            if(x < 5)
            {
                Console.WriteLine("x的值小于5!");
            }
            else if(x < 10)
            {
                Console.WriteLine("x的值大于5小于10!");
            }
            else if(x < 20)
            {
                Console.WriteLine("x的值大于10小于20!");
            }
        }

        //switch
        public void statementSWITCH()
        {
            //声明开关变量
            int switchVar = 2;
            switch (switchVar)
            {
                case 0:
                case 1:
                    Console.WriteLine("变量的值为0或1");
                    break;
                case 2:
                    Console.WriteLine("变量的值为2");
                    break;
                default:
                    Console.Write("默认情况");
                    break;
            }
        }

        //while
        public void statementWHILE()
        {
            int i = 0;
            while (i < 5)
            {
                Console.WriteLine("当前i的值为： {0}", i);
                i++;
            }
        }

        //doWhile
        public void statementDOWHILE()
        {
            int i = 5;
            Console.WriteLine("while语句的执行结果为：");
            while(i < 5)
            {
                Console.WriteLine("当前i的值为： {0}", i);
                i++;
            }

            Console.WriteLine();
            Console.WriteLine("do-while语句的执行结果为： ");
            do
            {
                Console.WriteLine("当前i的值为： {0}", i);
                i++;
            } while (i < 5);
        }

        //for
        public void statementFOR()
        {
            //声明并初始化一个含有5个元素的int数组
            int[] array = new int[5];
            //
            for (int index = 0; index <= array.Length - 1; index++)
            {
                array[index] = index;
                Console.WriteLine("array{0}: {1}", index, array[index]);
            }
        }

        //foreach
        public void statementFOREACH()
        {
            int[] array = new int[] { 0, 1, 1, 2, 3, 4 };
            Console.WriteLine("数组中的每个元素：");
            foreach(int element in array)
            {
                System.Console.WriteLine(element);
            }
        }

        //continue
        public void statementCONTINUE()
        {
            Console.WriteLine("使用Continue");
            for(int i = 0; i < 5; i++)
            {
                if(i == 2)
                {
                    continue;
                }

                Console.WriteLine("当前i的值为： {0}", i);
            }
        }

        //break;
        public void statementBREAK()
        {
            Console.WriteLine("使用break");
            for(int i = 0; i < 5; i++)
            {
               if(i == 2)
                {
                    break;
                }

                Console.WriteLine("当前i的值为： {0}", i);
            }
        }

        //return
        public void statementRETURN()
        {
            Console.WriteLine("使用return");
            for(int i = 0; i < 5; i++)
            {
                if(i == 2)
                {
                    return;
                }
                Console.WriteLine("当前i的值为：{0}", i);
            }

            Console.WriteLine("循环已推出");
        }

    }
}
