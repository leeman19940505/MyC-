using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSytemTest
{
    class Program
    {
        static void Main(string[] args)
        {
            FileTest ft = new FileTest(); 
            ft.FileWrite();

            DirectoryTest dt = new DirectoryTest();
            dt.DictionaryWrite();

            StreamTest st = new StreamTest();
            //st.fileStreamWrite();
            st.streamWrite();

            FileAsynTest at = new FileAsynTest();
            at.asynTest();
        }
    }
}
