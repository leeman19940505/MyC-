using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeYou
{
    //枚举类型 
    //值类型 用于声明一组命名了的常数 默认枚举中每个元素都是int类型
    public enum Gender : byte
    {
        // 女
        Female,
        //男
        Male
    }

    //Complex结构体属于一个自定义结构体 结构体不可对声明字段进行初始化 类可以
    public struct Complex
    {
        //复数的实数部分
        public int real;

        //复数的虚数部分
        public int imaginary;

        public Complex(int real, int imaginary)
        {
            //初始化复数的实数和虚数
            this.real = real;
            this.imaginary = imaginary;
        }

        //+运算符重载方法
        public static Complex operator +(Complex complex1, Complex complex2)
        {
            //值类型都有默认无参构造函数
            Complex result = new Complex();

            result.real = complex1.real + complex2.real;
            result.imaginary = complex1.imaginary + complex2.imaginary;

            return result;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //常量
            const string TEST = "test";

            //定义输出文本变量
            string welcomeText = "welcome";
            //输出文本到控制台
            Console.WriteLine(welcomeText);

            //结构体
            Complex number1 = new Complex(1, 2);
            Complex number2 = new Complex(3, 4);

            //用+运算符对两个复数进行相加 如果复数类型中没有对+运算符进行重载 则不能使用+运算符来对复数类型进行相加操作
            Complex sum = number1 + number2;

            Console.WriteLine("first: {0}, {1}", number1.real, number1.imaginary);
            Console.WriteLine("second: {0}, {1}", number2.real, number2.imaginary);
            Console.WriteLine("first and second: {0}, {1}", sum.real, sum.imaginary);
            //Console.Read();

            Statements statements = new Statements();
            statements.statementsIF();
            statements.statementSWITCH();
            statements.statementWHILE();
            statements.statementDOWHILE();
            statements.statementFOR();
            statements.statementFOREACH();

            Person person = new Person();
            person.Print("printString");
            person.Print(1);
            person.Print("printSting", 1);

            //索引器
            person[0] = 1;
            person[1] = 2;
            person[3] = 3;

            Console.WriteLine(person[0]);
            Console.WriteLine(person[1]);
            Console.WriteLine(person[2]);

            //OOP
            Horse horse = new Horse();
            horse.Print();

            Sheep sheep = new Sheep();
            sheep.Voice();
            horse.Voice();

            horse.Eat();
            ((Animal)horse).Eat();

            //调用接口中的方法
            PersonImp p1 = new PersonImp();
            p1.Age = 18;

            PersonImp p2 = new PersonImp();
            p2.Age = 19;

            if (p1.CompareTo(p2) > 0)
            {
                Console.WriteLine("p1比p2大");
            }
            else if (p1.CompareTo(p2) < 0)
            {
                Console.WriteLine("p1比p2小");
            }
            else
            {
                Console.WriteLine("p1和p2一样大");
            }

            //隐式接口调用/显式接口调用
            Speaker speaker = new Speaker();

            //调用中国人打招呼方法
            IChineseGreeting iChineseG = (IChineseGreeting)speaker;
            iChineseG.SayHello();

            //调用美国人打招呼方法
            IAmericanGreeting iAmericanG = (IAmericanGreeting)speaker;
            iAmericanG.SayHello();

            //让控制台程序可见知道用户按下任意字符位置
            Console.ReadKey();
        }
    }
}
