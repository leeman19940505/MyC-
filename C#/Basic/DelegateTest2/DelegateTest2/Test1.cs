using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegateTest2
{
    class Test1
    {
        public Test1()
        {
            //指定委托类型和方法
            EventHandler handler; //EventHandler相当于委托 delegate void EventHandler(object sender, System.EventArgs e) 
            handler = new EventHandler(HandleDemoEvent);
            handler(null, EventArgs.Empty);

            //隐式转换委托
            handler = HandleDemoEvent;
            handler(null, EventArgs.Empty);

            //使用匿名方法
            handler = delegate (object sender, EventArgs e)
            {
                Console.WriteLine("Handled by HandleDemoEvent");
            };
            handler(null, EventArgs.Empty);

            //使用匿名方法简写
            handler = delegate
            {
                Console.WriteLine("Handled by HandleDemoEvent");
            };
            handler(null, EventArgs.Empty);

            //使用委托逆变性 //public delegate void MouseEventHandler(object sender, MouseEventArgs e);
            MouseEventHandler mouseHandler = HandleDemoEvent;
            mouseHandler(null, new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0));
        }

        static void HandleDemoEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Handled by HandleDemoEvent");
        }
    }
}
