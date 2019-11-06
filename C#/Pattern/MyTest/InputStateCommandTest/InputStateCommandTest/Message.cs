using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputStateCommandTest
{
    class Message
    {
        private TextBox input;
        private string inputValue;

        public TextBox Input
        {
            get
            {
                return input;
            }
            set
            {
                input = value;
            }
        }

        public string InputValue
        {
            get
            {
                return inputValue;
            }
            set
            {
                inputValue = value;
            }
        }

    }
}
