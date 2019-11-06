using RemoteControlCommandTest.Entity;
using RemoteControlCommandTest.Interface;

namespace RemoteControlCommandTest.Implements
{
    class DoorOpenCommand : Command
    {
        Door door;

        public DoorOpenCommand(Door door)
        {
            this.door = door;
        }

        public void execute()
        {
            door.OpenDoor();
        }
    }
}
