using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanSpeedCommandTest
{
    class CeilingFan
    {
        public const int HIGH = 3;
        public const int MEDIUM = 2;
        public const int LOW = 1;
        public const int OFF = 0;
        string location;
        int speed;

        public CeilingFan()
        {
            this.location = location;
        }

        public void High()
        {
            speed = HIGH;
            Console.WriteLine(location + "high mode");
        }
        
        public void Medium()
        {
            speed = MEDIUM;
            Console.WriteLine(location + "medium speed mode");
        }

        public void Low()
        {
            speed = LOW;
            Console.WriteLine(location + "low speed mode");
        }

        public void Off()
        {
            speed = OFF;
            Console.WriteLine(location + "off speed mode");
        }

        public int getSpeed()
        {
            return speed;
        }
    }
}
