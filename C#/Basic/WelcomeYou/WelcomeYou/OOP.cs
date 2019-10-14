using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeYou
{
    class OOP
    {
    }

    //封装
    public class PersonOOP
    {
        private string _name;
        private int _age;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if(value < 0 || value > 120)
                {
                    throw (new ArgumentOutOfRangeException("AgeIntPropery", value, "年龄必须在0 - 120之间"));
                }
                _age = value;
            }
        }
    }

    //继承
    //abstract 可以通过new操作符创建Animal基类的实例 但是Animal基类的作用是为所有子类提供公共成员 它是一个抽象的概念 使用abstract关键字可以避免创建该类的实例
    public abstract class Animal
    {
        public Animal()
        {
            Console.WriteLine("基类构造函数被调用");
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0 || value > 10)
                {
                    throw (new ArgumentOutOfRangeException("AgeIntPropery", value, "年龄必须在0-10之间"));
                }
                _age = value;
            }
        }

        //只有基类的成员被声明为virtual或abstract时，才能被派生类重写 如果子类想改变虚方法的实现行为 需要使用override关键字
        //virtual关键字 把需要在子类中表现为不同行为的方法定义为虚方法 子类中使用override关键字对基类方法进行重写 每个基类在调用相同的方法时将表现出不同的行为
        public virtual void Voice()
        {
            Console.WriteLine("动物开始发出声音");
        }

        //
        public void Eat()
        {
            Console.WriteLine("动物吃东西");
        }
    }

    //马（子类）
    //子类初始化顺序：初始化类的实例字段； 调用基类的构造函数 如果没有指明基类 则调用System.Object的构造函数；调用子类构造函数
    public class Horse:Animal
    {
        private int FieldA = 3;

        public Horse()
        {
            Console.WriteLine("子类构造函数被调用");
        }

        public void Print()
        {
            Console.WriteLine(FieldA);
        }

        //通过override关键字来重写父类方法
        public sealed override void Voice()
        {
            //调用基类的方法
            base.Voice();
            Console.WriteLine("马-嘶嘶");
        }

        //在派生类中定义与基类成员同名的成员 可以使用new关键字把基类成员隐藏起来
        public new void Eat()
        {
            Console.WriteLine("马吃的方法");
        }

    }

    //羊（子类）
    public class Sheep:Animal
    {
        public override void Voice()
        {
            base.Voice();
            Console.WriteLine("羊-咩咩");
        }
    }

    //密封类 该不可被继承
    public sealed class SealedClass
    {

    }

    //多态 由于可以继承基类的所有成员 子类有了相同的行为， 但是有时子类的行为需要相互区分 子类需要覆写父类中的方法来实现子类特有的行为

    //System.object
    //public class Object
    //{
    //    //方法
    //    //构造函数
    //    public Object();

    //    //虚成员 子类可以重写这些方法
    //    public virtual bool Equals(object obj);
    //    protected virtual void Finalize();
    //    public virtual int getHashCode();
    //    public virtual string ToString();

    //    //实例成员
    //    public Type GetType();
    //    protected object MemberwiseClone();

    //    //静态成员
    //    public static bool Equals(Object objA, object objB);
    //    public static bool ReferenceEquals(object objA, object objB);
    //}

    //OOP例子
    //Dog类
    //public class Dog
    //{
    //    public void EatFood()
    //    {
    //        //eat some food
    //    }

    //    public void Walk()
    //    {
    //        //walk
    //    }
    //}

    //Aninal类封装公用的EatFood和Walk
    //public abstract class AnimalOOP
    //{
    //    public void EatFood()
    //    {
    //        //eat some food
    //    }

    //    public void Walk()
    //    {
    //        //walk
    //    }
    //}

    //public class Dog : AnimalOOP
    //{

    //}

    //不过度使用继承 否则会导致派生类的膨胀
    //使用接口与抽象类 EatFood Walk是所有Dog具有的共性 Show则是某些Dog具有的特性（can-do）
    public abstract class AnimalOOP
    {
        public void EatFood()
        {
            //eat some food
        }

        public void Walk()
        {
            //walk
        }
    }

    public interface IAnimalShow
    {
        void Show();
    }

    public class SpecialDog : AnimalOOP, IAnimalShow
    {
        public void Show()
        {
            //throw new NotImplementedException();
        }
    }
}
