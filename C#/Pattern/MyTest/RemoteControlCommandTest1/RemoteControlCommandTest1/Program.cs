using RemoteControlCommandTest1.Control;
using RemoteControlCommandTest1.Entity;
using RemoteControlCommandTest1.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlCommandTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandTest();
            Console.WriteLine("---------------------------------------------------");
            UnCommandTest();

            Console.ReadKey();
        }

        public static void CommandTest()
        {
            // 实例化遥控器
            RemoteControl remoteControl = new RemoteControl();
            // 实例化需要控制对象，并传入房子位置
            Stereo stereo = new Stereo("客厅");
            Light light = new Light("客厅");
            TV tv = new TV("卧室");
            // 调用设备开关方法
            StereoOnWithCDCommand stereoOnWichCD = new StereoOnWithCDCommand(stereo);
            StereoOffCommand stereoOffWithCD = new StereoOffCommand(stereo);
            LightOnCommand lightOn = new LightOnCommand(light);
            LightOffCommand lightOff = new LightOffCommand(light);
            TVOnCommand tvOn = new TVOnCommand(tv);
            TVOffCommand tvOff = new TVOffCommand(tv);

            // 设置插槽位置(遥控器的哪个按钮对应哪个设备开关)
            remoteControl.SetCommand(0, lightOn, lightOff);
            remoteControl.SetCommand(3, stereoOnWichCD, stereoOffWithCD);
            remoteControl.SetCommand(5, tvOn, tvOff);
            // 输出插槽位置
            Console.WriteLine(remoteControl);
            // 按下开关
            remoteControl.OnButtonWasPushed(0);
            remoteControl.OffButtonWasPushed(0);
            remoteControl.OnButtonWasPushed(3);
            remoteControl.OffButtonWasPushed(3);
            remoteControl.OnButtonWasPushed(5);
            remoteControl.OffButtonWasPushed(5);
        }

        public static void UnCommandTest()
        {
            // 实例化遥控器
            RemoteControl remoteControl = new RemoteControl();
            // 实例化需要控制对象，并传入房子位置
            Light light = new Light("客厅");

            // 调用设备开关方法
            LightOnCommand lightOn = new LightOnCommand(light);
            LightOffCommand lightOff = new LightOffCommand(light);

            // 设置插槽位置(遥控器的哪个按钮对应哪个设备开关)
            remoteControl.SetCommand(0, lightOn, lightOff);

            // 按下开关
            remoteControl.OnButtonWasPushed(0);
            remoteControl.OffButtonWasPushed(0);
            // 输出插槽位置
            Console.WriteLine(remoteControl);
            // 撤销
            Console.WriteLine("按下撤销按钮");
            remoteControl.UndoButtonWasPushed();
            Console.WriteLine("");
            remoteControl.OffButtonWasPushed(0);
            remoteControl.OnButtonWasPushed(0);
            Console.WriteLine(remoteControl);
            Console.WriteLine("按下撤销按钮");
            remoteControl.UndoButtonWasPushed();
        }
    }
}
