using RemoteControlCommandTest.Entity;
using RemoteControlCommandTest.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlCommandTest.Implements
{
    class LightOnCommand : Command
    {
        Light light;

        /// <summary>
        /// 构造器传入某个电灯类型 以便让这个命令控制
        /// </summary>
        /// <param name="light"></param>
        public LightOnCommand(Light light)
        {
            this.light = light;
        }

        /// <summary>
        /// 执行亮灯方法
        /// </summary>
        public void execute()
        {
            light.On();
        }
    }
}
