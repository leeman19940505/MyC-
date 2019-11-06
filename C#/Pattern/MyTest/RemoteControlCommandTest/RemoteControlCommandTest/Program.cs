using RemoteControlCommandTest.Entity;
using RemoteControlCommandTest.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlCommandTest
{
    class Program
    {
        /// <summary>
        /// 将请求封装成对象 以便使用不同的请求，队列或日志
        /// 来参数化其他对象 命令模式也支持可撤销的操作
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //相当于命令的调用者 会传入一个命令对象 可以用来发送请求
            SimpleRemoteControl remote = new SimpleRemoteControl();
            Light light = new Light();
            Door door = new Door();

            //创建打开电灯动作的类 并传入接收者light
            LightOnCommand lightOn = new LightOnCommand(light);
            DoorOpenCommand doorOpen = new DoorOpenCommand(door);

            remote.SetCommand(lightOn);
            remote.ButtonWasPressed();
             
            remote.SetCommand(doorOpen);
            remote.ButtonWasPressed();

            Console.ReadKey();
        }
    }
}
