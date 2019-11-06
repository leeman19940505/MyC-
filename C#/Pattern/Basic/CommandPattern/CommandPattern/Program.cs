using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern 
{
    class Program
    {
        static void Main(string[] args)
        {
            Message aMessage = new Message(1, "a");
            Message bMessage = new Message(2, "b");
            Message cMessage = new Message(3, "c");
            Message dMessage = new Message(4, "d");

            ICommand aCommand = new ConcreateCommand(Action.Delete, aMessage);
            ICommand bCommand = new ConcreateCommand(Action.Insert, bMessage);
            ICommand cCommand = new ConcreateCommand(Action.Delete, cMessage);
            ICommand dCommand = new ConcreateCommand(Action.Insert, dMessage);

            Invoker aInvoker = new Invoker();
            aInvoker.Do(aCommand);
            aInvoker.Do(bCommand);
            aInvoker.Do(cCommand);
            aInvoker.Do(dCommand);

            aInvoker.UnDo(1);
            aInvoker.UnDo(1);

            Console.ReadKey();
        }
    }
}
