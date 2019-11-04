using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    class Message
    {
        private int id;
        private string name;

        public int Id
        {
            get
            { 
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public Message(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
