using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlCommandTest1.Entity
{
    class Stereo
    {
        //
        string location;

        public Stereo(String location)
        {
            this.location = location;
        }

        public void On()
        {
            Console.WriteLine(location + "stereo on");
        }

        public void Off()
        {
            Console.WriteLine(location + "stereo off");
        }

        public void setDVD()
        {
            Console.WriteLine(location + "stereo DVD mode");
        }

        public void setCD()
        {
            Console.WriteLine(location + "stereo CD");
        }

        public void setRadio()
        {
            Console.WriteLine(location + "stereo Radio mode");
        }
    }
}
