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
    class CeilingFanHightCommand : ICommand
    {
        CeilingFan ceilingFan;
        int preSpeed;

        public CeilingFanHightCommand(CeilingFan cf)
        {
            ceilingFan = cf;
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
