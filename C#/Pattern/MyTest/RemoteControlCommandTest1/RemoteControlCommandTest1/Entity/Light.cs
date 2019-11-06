using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlCommandTest1.Entity
{
    class Light
    {
        //位置
        string location;

        public Light(String location)
        {
            this.location = location;
        }

        public void On()
        {
            Console.WriteLine(location + "light on");
        }

        public void Off()
        {
            Console.WriteLine(location + "light off");
        }
    }
}
