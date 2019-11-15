using RemoteControlCommandTest1.Entity;
using RemoteControlCommandTest1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlCommandTest1.Implements
{
    class TVOnCommand : Command
    {
        TV tv;

        public TVOnCommand(TV tv)
        {
            this.tv = tv;
        }

        public void execute()
        {
            tv.TVOn();
            tv.setTVChannel(15);
        }

        public void undo()
        {
            tv.TVOff();
        }
    }
}
