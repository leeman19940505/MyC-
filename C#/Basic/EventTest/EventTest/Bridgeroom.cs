using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTest
{
    //事件式特殊的多路广播委托
    //自定义事件类，并使其带有事件数据
    public class CustomEventArgs : EventArgs
    {
        public string Message;
        public CustomEventArgs(string msg)
        {
            Message = msg;
        }
    }

    //主角A类 充当事件发布者
    class Bridgeroom
    {
        //自定义委托
        public delegate void MarrayHandler(string msg);

        //使用自定义委托类型定义事件，事件名为MarryEvent
        public event MarrayHandler MarryEvent;

        //使用.NET类库中预定义的委托类型EventHandler
        public event EventHandler BirthdayEvent;

        //发出事件
        public void OnMarriageComing(string msg)
        {
            if(MarryEvent != null)
            {
                //触发事件
                MarryEvent(msg);
            }
        }

        //预定义委托类型 public delegate void EventHandler(Object sender, EventArgs e);
        //该委托返回类型为void 因此实例化委托类型的方法也需要满足这点
        //第一个参数sender负责保存对触发事件对象的引用 
        //第二个参数e负责保存事件数据 EventArgs不保存任何数据 如果要在定义的事件中包含事件数据 则需要通过拓展EventArgs类来使事件参数e带有事件数据
        public void OnBirthdayComing(string msg)
        {
            if(BirthdayEvent != null)
            {
                Console.WriteLine(msg);
                //触发事件
                BirthdayEvent(this, new EventArgs());
            }
        }

        //自定义委托类型
        public delegate void CustomHandler(object sender, CustomEventArgs e);
        //自定义事件
        public event CustomHandler CustomEvent;

        public void OnCustomEventSending(string msg)
        {
            //判断是否绑定了事件处理方法
            if(CustomEvent != null)
            {
                CustomEvent(this, new CustomEventArgs(msg));
            }
        }

        static void Main(string[] args)
        {
            //初始化主角A对象
            Bridgeroom bridgeroom = new Bridgeroom();

            //实例化朋友对象
            Friend friend1 = new Friend("Friend1");
            Friend friend2 = new Friend("Friend2");
            Friend friend3 = new Friend("Friend3");

            //使用 += 来订阅事件
            //bridgeroom.MarryEvent += new MarrayHandler(friend1.SendMessage);
            //bridgeroom.MarryEvent += new MarrayHandler(friend2.SendMessage);
            //bridgeroom.BirthdayEvent += new EventHandler(friend1.SendMessage);
            //bridgeroom.BirthdayEvent += new EventHandler(friend2.SendMessage);
            bridgeroom.CustomEvent += new CustomHandler(friend1.SendMessage);
            bridgeroom.CustomEvent += new CustomHandler(friend2.SendMessage);

            //发出通知 此时只有订阅了事件的对象才能收到通知
            //bridgeroom.OnMarriageComing("from bridgeroom");
            //bridgeroom.OnBirthdayComing("frrom bridgeroom birthday");
            bridgeroom.OnCustomEventSending("from bridgeroom custom");
            Console.WriteLine("-----------------------------");

            //使用-=取消事件订阅
            //bridgeroom.MarryEvent -= new MarrayHandler(friend2.SendMessage);
            //bridgeroom.MarryEvent += new MarrayHandler(friend3.SendMessage);
            //bridgeroom.BirthdayEvent -= new EventHandler(friend2.SendMessage);
            //bridgeroom.BirthdayEvent += new EventHandler(friend3.SendMessage);
            bridgeroom.CustomEvent -= new CustomHandler(friend2.SendMessage);
            bridgeroom.CustomEvent += new CustomHandler(friend3.SendMessage);

            //bridgeroom.OnMarriageComing("still from bridgeroom");
            //bridgeroom.OnBirthdayComing("frrom bridgeroom birthday");
            bridgeroom.OnCustomEventSending("from bridgeroom custom");
            Console.Read();
        }
    }

    public class Friend
    {
        //字段
        public string Name;

        //构造函数
        public Friend(string name)
        {
            Name = name;
        }

        //事件处理函数 该函数需要符合MarrayHandler委托的定义
        //public void SendMessage(string message)
        //{
        //    //输出通知信息
        //    Console.WriteLine(message);

        //    //对事件做出处理
        //    Console.WriteLine(this.Name + "接收到信息");
        //}

        //函数要符合委托的定义
        //public void SendMessage(object s, EventArgs e)
        //{
        //    //对事件做出处理
        //    Console.WriteLine(this.Name + "接收到信息");
        //}

        public void SendMessage(object s, CustomEventArgs e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(this.Name + "Custom");
        }
    }
}
