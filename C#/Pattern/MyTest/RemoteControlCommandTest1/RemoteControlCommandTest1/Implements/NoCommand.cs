using RemoteControlCommandTest1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlCommandTest1.Implements
{
    /// <summary>
    /// 无操作类 插槽内的类没有实例化就走这个对象
    /// </summary>
    class NoCommand : Command
    {
        public void execute()
        {
        }

        public void undo()
        {
        }
    }
}
