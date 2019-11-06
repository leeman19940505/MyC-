using RemoteControlCommandTest.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlCommandTest
{
    /// <summary>
    /// 调用者
    /// </summary>
    class SimpleRemoteControl
    {
        Command slot;

        public SimpleRemoteControl()
        {

        }

        /// <summary>
        /// 设置控制命令 客户端需要改变调用者行为 可以多次调用此方法
        /// </summary>
        /// <param name="command"></param>
        public void SetCommand(Command command)
        {
            slot = command;
        }

        public void ButtonWasPressed()
        {
            slot.execute();
        }
    }
}
