using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlCommandTest1.Entity
{
    class TV
    {
        String location;
        int channel; 

        public TV(String location)
        {
            this.location = location;
        }

        public void TVOn()
        {
            Console.WriteLine(location + " TV on");
        }

        public void TVOff()
        {
            Console.WriteLine(location + " TV off");
        }

        public void setTVChannel(int channel)
        {
            this.channel = channel;
            Console.WriteLine(location + " set TV channel to " + channel);
        }
    }
}
