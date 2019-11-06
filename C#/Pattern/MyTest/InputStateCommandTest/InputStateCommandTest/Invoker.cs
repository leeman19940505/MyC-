using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputStateCommandTest
{
    /// <summary>
    /// 请求者
    /// </summary>
    class Invoker
    {
        int current;
        List<ICommand> commandList = new List<ICommand>();

        public void Do(ICommand aCommand)
        {
            aCommand.Excute();
            commandList.Add(aCommand);
            current++;
        }

        public void UnDo(int index)
        {
            for(int i = 0; i < index; i++)
            {
                commandList[--current].UnExcute();
                commandList.RemoveAt(current);
            }
        }
    }
}
