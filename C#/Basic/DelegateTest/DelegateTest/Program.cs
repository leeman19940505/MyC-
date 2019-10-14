using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTest
{
    //委托 类类型 ILDasm

    //函数的一个包装 使得C#中的函数可以作为参数来被传递
    //委托能包装的方法的限制 方法签名必须和委托一样 （方法签名：参数的个数，类型和顺序）
    //方法的返回类型要和委托一样 （方法的返回类型不属于方法签名的一部分）

    //委托 使一个方法可以作为另一个方法的参数进行传递
    //定义委托类型 -> 声明委托变量 -> 实例化委托 -> 作为参数传递给方法 -> 调用委托
    class Program
    {
        //使用delegate关键字来定义一个委托类型
        delegate void MyDelegate(int para1, int para2);
        public delegate void GreetingDelegate(string name);

        //委托链
        public delegate void DelegateTest();

        static void Main(string[] args)
        {
            //声明委托变量
            MyDelegate d;
            //实例化委托类型 传递的方法也可以为静态方法 这里传递的是实例方法
            d = new MyDelegate(new Program().Add);

            //委托类型作为参数传递为另一个方法
            MyMethod(d);

            //GreetingDelegate
            Program p = new Program();
            p.Greeting("李志", p.ChineseGreeting);
            p.Greeting("Tommy Li", p.EnglishGreeting);

            //委托链
            //用静态方法实例化委托
            DelegateTest dtstatic = new DelegateTest(Program.method1);
            DelegateTest dtinstance = new DelegateTest(new Program().method2);
            //定义一个委托对象 一开始初始化为null 不代表任何方法
            DelegateTest delegatechain = null;

            //使用+符号链接委托 链接多个委托后就成为了委托链
            delegatechain += dtstatic; //静态方法
            delegatechain += dtinstance; //实例方法

            //使用-符号将委托从委托链中移除
            delegatechain -= dtstatic;

            //调用委托链
            delegatechain();

            Console.Read();
        }

        //该方法的定义必须与委托定义相同，即返回类型为void,两个int类型的参数
        void Add(int para1, int para2)
        {
            int sum = para1 + para2;
            Console.WriteLine("两个数的和为：" + sum);
        }

        //方法的参数式委托类型
        private static void MyMethod(MyDelegate mydelegate)
        {
            //mydelegate(1, 2);
            //Invoke显式调用委托
            mydelegate.Invoke(1, 2);
            //Console.Read();
        }

        //不使用委托 拓展性差 需要增加case进行拓展
        //public void Greeting(string name, string language)
        //{
        //    switch(language)
        //    {
        //        case "zh-cn":
        //            ChineseGreeting(name);
        //            break;
        //        case "en-us":
        //            EnglishGreeting(name);
        //            break;
        //        default:
        //            EnglishGreeting(name);
        //            break;
        //    }
        //}

        public void EnglishGreeting(string name)
        {
            Console.WriteLine("Hello, " + name);
        }

        public void ChineseGreeting(string name)
        {
            Console.WriteLine("你好，" + name);
        }

        //使用委托
        public void Greeting(string name, GreetingDelegate callback)
        {
            callback(name);
        }

        //委托链
        //静态方法
        private static void method1()
        {
            Console.WriteLine("静态方法");
        }

        //实例方法
        private void method2()
        {
            Console.WriteLine("实例方法");
        }
    }
}
