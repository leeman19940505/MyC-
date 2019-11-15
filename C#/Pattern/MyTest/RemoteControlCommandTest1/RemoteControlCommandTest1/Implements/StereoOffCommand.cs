using RemoteControlCommandTest1.Entity;
using RemoteControlCommandTest1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlCommandTest1.Implements
{
    class StereoOffCommand : Command
    {
        Stereo stereo;
        
        public StereoOffCommand(Stereo stereo)
        {
            this.stereo = stereo;
        }

        public void execute()
        {
            stereo.Off();
        }

        public void undo()
        {
            stereo.On();
        }
    }
}
