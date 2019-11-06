using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputStateCommandTest
{
    class ConcreateCommand : ICommand
    {
        Reciever iReciever;
        Message iMessage;
        Action iAction;

        public ConcreateCommand(Action aAction, Message aMessage)
        {
            iReciever = new Reciever();
            iAction = aAction;
            iMessage = aMessage;
        }

        public void Excute()
        {
            iReciever.Operation(iAction, iMessage);
        }

        public void UnExcute()
        {
            iAction = GetUnDo(); //获取相反操作
            iReciever.Operation(iAction, iMessage);
        }

        private Action GetUnDo()
        {
            switch(iAction)
            {
                case Action.Foreward:
                    return Action.Backward;
                case Action.Backward:
                    return Action.Foreward;
                default:
                    return 0;
            }
        }
    }
}
