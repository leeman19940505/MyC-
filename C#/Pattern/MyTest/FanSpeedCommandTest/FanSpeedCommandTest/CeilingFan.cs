using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanSpeedCommandTest
{
    class CeilingFan
    {
        public const int HIGH = 2;
        public const int LOW = 1;
        public const int OFF = 0;
        int speed;

        public CeilingFan()
        {
            speed = OFF;
        }

        public void High()
        {
            speed = HIGH;
        }
        
        public void Low()
        {
            speed = LOW;
        }

        public void Off()
        {
            speed = OFF;
        }

        public int getSpeed()
        {
            return speed;
        }
    }
}
