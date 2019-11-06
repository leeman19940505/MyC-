using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputStateCommandTest
{
    /// <summary>
    /// 撤销 还原操作
    /// </summary>
    interface ICommand
    {
        /// <summary>
        /// 
        /// </summary>
        void Excute();

        /// <summary>
        /// 
        /// </summary>
        void UnExcute();
    }
}
