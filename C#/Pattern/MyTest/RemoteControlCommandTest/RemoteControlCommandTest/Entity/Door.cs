using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlCommandTest.Entity
{
    class Door
    {
        public Door()
        {

        }

        public void OpenDoor()
        {
            Console.WriteLine("door open");
        }

        public void OffDoor()
        {
            Console.WriteLine("door off");
        }

        public void StopDoor()
        {
            Console.WriteLine("door stop");
        }

        public void DoorLightOn()
        {
            Console.WriteLine("light in the door on");
        }
    }
}
