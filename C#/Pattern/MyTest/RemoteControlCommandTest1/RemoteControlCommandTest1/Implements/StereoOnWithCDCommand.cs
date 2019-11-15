using RemoteControlCommandTest1.Entity;
using RemoteControlCommandTest1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlCommandTest1.Implements
{
    class StereoOnWithCDCommand : Command
    {
        Stereo stereo;

        public StereoOnWithCDCommand(Stereo stereo)
        {
            this.stereo = stereo;
        }

        public void execute()
        {
            stereo.On();
            stereo.setCD();
            stereo.setVolume(11);
        }

        public void undo()
        {
            stereo.Off();
        }
    }
}
