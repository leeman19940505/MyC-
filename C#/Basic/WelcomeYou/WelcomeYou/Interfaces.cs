using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeYou
{
    //接口定义
    interface Interfaces
    {
        //接口中可以定义方法 属性 时间 索引器
        //接口中的所有成员都默认是公开的
        //接口中定义方法不能添加任何访问修饰符 继承该接口的类都要实现该方法
        int CompareTo(object other);
    }

    //接口继承
    interface ICustomCompare
    {
        int CompareTo(object other);
    }

    //继承接口时需要实现接口中的方法
    public class PersonImp : ICustomCompare
    {
        int age;

       public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public int CompareTo(object value)
        {
            //throw new NotImplementedException();
            if(value == null)
            {
                return 1;
            }

            PersonImp otherp = (PersonImp)value;
            if(this.Age < otherp.Age)
            {
                return -1;
            }

            if(this.Age > otherp.Age)
            {
                return 1;
            }

            return 0;
        }
    }

    //显式接口实现方式 两个不同的接口中有同样的方法 一个类实现了两个接口 需要指定具体实现了哪个接口的方法
    //中国人打招呼接口
    interface IChineseGreeting
    {
        //接口方法声明
        void SayHello();
    }

    //美国人打招呼接口
    interface IAmericanGreeting
    {
        //接口方法声明
        void SayHello();
    }

    public class Speaker : IChineseGreeting, IAmericanGreeting
    {
        //隐式接口实现 将调用相同的SayHello方法 不管具体获取了哪个接口
        //public void SayHello()
        //{
        //    //throw new NotImplementedException();
        //    Console.WriteLine("你好");
        //}

        //显式接口实现 若显式实现接口 方法不能使用任何访问修饰符 显式实现的成员默认为私有（不能通过类的对象进行方法 只能通过接口对象进行访问）
        void IChineseGreeting.SayHello()
        {
            Console.WriteLine("你好");
        }

        void IAmericanGreeting.SayHello()
        {
            Console.WriteLine("Hello");
        }
    }

    //接口与抽象类的区别

}
