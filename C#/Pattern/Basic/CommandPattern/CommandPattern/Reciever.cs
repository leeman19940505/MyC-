using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    /// <summary>
    /// 接收者
    /// </summary>
    class Reciever
    {
        public void Operation(Action aAction, Message aMessage)
        {
            switch(aAction)
            {
                case Action.Delete:
                    Delete(aAction, aMessage);
                    break;
                case Action.Insert:
                    Insert(aAction, aMessage);
                    break;
                default:
                    break;
            }
        }

        private void Insert(Action aAction, Message aMessage)
        {
            Console.WriteLine("delete: " + aAction.ToString() + ", " + aMessage.Id + ", " + aMessage.Name);
        }

        private void Delete(Action aAction, Message aMessage)
        {
            Console.WriteLine("add: " + aAction.ToString() + ", " + aMessage.Id + ", " + aMessage.Name);
        }
    }
}
