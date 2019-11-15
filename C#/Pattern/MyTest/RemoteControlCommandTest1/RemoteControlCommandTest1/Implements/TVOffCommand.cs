using RemoteControlCommandTest1.Entity;
using RemoteControlCommandTest1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlCommandTest1.Implements
{
    class TVOffCommand : Command
    {
        TV tv;

        public TVOffCommand(TV tv)
        {
            this.tv = tv;
        }


        public void execute()
        {
            tv.TVOff();
        }

        public void undo()
        {
            tv.TVOn();
        }
    }
}
