using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanSpeedCommandTest
{
    /// <summary>
    /// 高速运行
    /// </summary>
    class CeilingFanHightCommand : Command
    {
        CeilingFan ceilingFan;
        int preSpeed;

        public CeilingFanHightCommand(CeilingFan ceilingFan)
        {
            this.ceilingFan = ceilingFan;
        }

        public void execute()
        {
            preSpeed = ceilingFan.getSpeed();
            ceilingFan.High();
        }

        public void undo()
        {
            switch(preSpeed)
            {
                case CeilingFan.HIGH:
                    ceilingFan.High();
                    break;
                case CeilingFan.MEDIUM:
                    ceilingFan.Medium();
                    break;
                case CeilingFan.LOW:
                    ceilingFan.Low();
                    break;
                default:
                    ceilingFan.Off();
                    break;
            }
        }
    }
}
