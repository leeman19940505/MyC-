using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlCommandTest.Entity
{
    class Light
    {
        public Light()
        {

        }

        public void On()
        {
            Console.WriteLine("light on");
        }

        public void Off()
        {
            Console.WriteLine("light off");
        }
    }
}
