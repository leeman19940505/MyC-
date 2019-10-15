using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTest2
{
    delegate void StringProcessor(string input); //声明委托类型
    class Person
    {
        string name;
        public Person(string name)
        {
            this.name = name;
        }

        public void Say(string message) //声明兼容的实例方法
        {
            Console.WriteLine("{0} says: {1}", name, message);
        }
    }

    class Background
    {
        public static void Note(string note) //声明兼容的静态方法
        {
            Console.WriteLine("{(0)}", note);
        }
    }

    /// <summary>
    /// 声明委托类型 
    /// 必须有一个方法包含了要执行的代码 
    /// 必须创建一个委托实例 
    /// 必须调用(invoke)委托实例
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Person jon = new Person("Jon");
            Person tom = new Person("Tom");
            StringProcessor jonsVoice, tomsVoice, background;
            jonsVoice = new StringProcessor(jon.Say); ///创建三个委托实例
            tomsVoice = new StringProcessor(tom.Say);
            background = new StringProcessor(Background.Note);
            jonsVoice("Hello, son."); //调用委托实例
            tomsVoice.Invoke("Hello, Daddy");
            background("An airplane flies past");
        }
    }
}
