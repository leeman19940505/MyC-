using RemoteControlCommandTest1.Implements;
using RemoteControlCommandTest1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlCommandTest1.Control
{
    class RemoteControl
    {
        //此时遥控器要处理7个开关控制
        Command[] onCommands = new Command[7];
        Command[] offCommands = new Command[7];

        //撤销要先知道之前的命令 撤销变量 用来追踪最后被调用的命令
        Command undoCommand;

        //初始化遥控器类 一开始都是无操作noCommand是一个无操作对象
        //在测试输出时 没有被明确指明命令的插槽 其命令默认为noCommand对象
        public RemoteControl()
        {
            Command noCommand = new NoCommand();
            for(int i = 0; i < onCommands.Length; i++)
            {
                onCommands[i] = noCommand;
                offCommands[i] = noCommand;
            }
            undoCommand = noCommand;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slot">插槽的位置 类似索引值</param>
        /// <param name="onCommand">开的命令</param>
        /// <param name="offCommand">关的命令 这些命令被记录在开关数组对应的插槽位置上 以便使用</param>
        public void SetCommand(int slot, Command onCommand, Command offCommand)
        {
            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand;
        }

        /// <summary>
        /// 开关按钮是对应插槽位置负责调用对应的方法
        /// 遥控器上面的开关按钮的不同位置可以控制不同类型的灯
        /// undoCommand 当按下遥控器按钮时 我们取得这个命令 并记录在undoCommand里
        /// </summary>
        /// <param name="slot"></param>
        public void OnButtonWasPushed(int slot)
        {
            onCommands[slot].execute();
            undoCommand = onCommands[slot];
        }

        public void OffButtonWasPushed(int slot)
        {
            offCommands[slot].execute();
            undoCommand = offCommands[slot];
        }

        //添加一个撤销按钮
        public void UndoButtonWasPushed()
        {
            undoCommand.undo();
        }

        //打印每个插槽对应的命令
        public override string ToString()
        {
            StringBuilder sbf = new StringBuilder(); ;
            sbf.Append("\n======================遥控器======================\n");
            for(int i = 0; i < onCommands.Length; i++)
            {
                sbf.Append("[插槽" + i + "]" + onCommands[i].GetType().Name 
                    + "\t" + offCommands[i].GetType().Name + "\n");
            }

            return sbf.ToString();
        }
    }
}
