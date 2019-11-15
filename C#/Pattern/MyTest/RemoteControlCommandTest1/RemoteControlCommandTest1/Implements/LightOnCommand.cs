using RemoteControlCommandTest1.Entity;
using RemoteControlCommandTest1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlCommandTest1.Implements
{
    class LightOnCommand : Command
    {
        Light light;

        public LightOnCommand(Light light)
        {
            this.light = light;
        }

        public void execute()
        {
            light.On();
        }

        public void undo()
        {
            light.Off();
        }
    }
}
