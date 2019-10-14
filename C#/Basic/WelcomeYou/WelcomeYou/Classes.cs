using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeYou
{
    //类修饰符
    //internal或无： 只能在同意程序集中访问类
    //private： 
    //protected：
    //public： 同一程序集或引用该程序集的其他程序集都可以访问类 
    //abstract 或interal abstract： 只能在同一程序集中访问类， 该类不能被实例化 只能被继承
    //sealed 或 internal sealed：只能在同一程序集中访问类，该类不能被继承，只能被实例化
    //public sealed: 同一程序集或引用该程序集的其他程序集都可以访问类，不能被继承， 只能被实例化
    //public abstract 同一程序集或引用该程序集的其他程序集都可以访问类， 不能被实例化，只能被继承

    //类成员修饰符：
    //public 同一程序集或引用该程序集的其他程序集都可以访问
    //private 只有用一个类中可以访问
    //protected 只有同一个类或派生类中可以访问
    //internal 只有同一个程序集可以访问
    //protected internal 在同一个程序集，该类和派生类中可以访问
    class Classes
    {
        //字段： 访问修饰符 字段类型 字段名称
        //private string name;
        public int age;
        protected bool sex;

        //属性
        //私有字段定义
        private string name;
        //公有属性定义
        public string Name
        {
            //get访问器
            get
            {
                return name;
            }
            //set访问器
            set
            {
                //value是隐式参数
                name = value;
            }
        }

        //私有字段定义
        private string hobby;
        
        //返回字段
        public string gethobby()
        {
            return hobby;
        }

        //为字段赋值
        public void sethobby(string value)
        {
            name = value;
        }
    }

    public class Person
    {
        //构造函数 可以方法重载 可以使用修饰符 必须与类同名 不允许有返回类型
        public Person()
        {
            name = "leeman";
        }

        //静态构造函数 用于初始化类中的静态成员 不使用任何访问修饰符 不带任何参数 值执行一次 不能直接调用静态构造函数
        //private static string name;
        //static Person()
        //{
        //    name = "leeman"
        //}

        //私有变量
        private string name;
        private int age;
        private bool sex;
        //静态属性
        private static string hobby; 

        //只读属性定义
        public string Name //属性类型必须与访问的字段类型一致
        {
            get
            {
                return name;
            }
            //私有set访问器
            private set
            {
                name = value;
            }
        }

        //只写属性
        public bool Sex
        {
            //私有get访问器
            private get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }

        //添加逻辑
        public int Age
        {
            //get访问器
            get
            {
                return age;
            }
            set
            {
                //在set访问器中添加逻辑
                if(value < 0 || value > 120)
                {
                    throw (new ArgumentOutOfRangeException("AgeIntPropery", value, "age must between 0-120"));
                }
                age = value;
            }
        }

        //静态变量
        public static string Hobby
        {
            //get
            get
            {
                return hobby;
            }
            set
            {
                hobby = value;
            }
        }

        //方法
        public void Print(string name)
        {
            Console.WriteLine("输入的值为： " + name);
        }

        //方法重载
        public void Print(int age)
        {
            Console.WriteLine("输入的值为：" + age);
        }

        //方法重载
        public void Print(string name, int age)
        {
            Console.WriteLine("输入的值为： {0}, {1}", name, age);
        }

        //析构函数
        ~Person()
        {
            Console.WriteLine("析构函数被调用");
        }

        //该析构函数隐式的调用了基类Object的Finalize方法
        //protected override void Finalize()
        //{
        //    try
        //    {
        //        Console.WriteLine("析构函数被调用");
        //    }
        //    finally
        //    {
        //        //调用Object的Finalize方法
        //        base.Finalize();
        //    }
        //}

        //索引器 简化数组操作
        private int[] intarry = new int[10];

        public int this[int index]
        {
            get
            {
                return intarry[index];
            }
            set
            {
                intarry[index] = value;
            }
        }
    }

}
