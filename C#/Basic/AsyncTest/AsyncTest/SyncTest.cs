using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncTest
{
    public partial class SyncTest : Form
    {
        public SyncTest()
        {
            InitializeComponent();
            txbUrl.Text = "http://download.microsoft.com/download/7/0/3/703455ee-a747-4cc8-bd3e-98a615c3aedb/dotNetFx35setup.exe";
        }

        public void btnDownLoad_Click(object sender, EventArgs e)
        {
            rtbState.Text = "下载中.....";
            if(txbUrl.Text == String.Empty)
            {
                MessageBox.Show("请先输入下载地址！ ");
                return;
            }

            DownLoadFileSync(txbUrl.Text.ToString());
        }

        //点击下载时 主线程无法监听窗体移动的操作 导致下载过程中出现假死现象
        public void DownLoadFileSync(string url)
        {
            int BufferSize = 2048;
            byte[] BufferRead = new byte[BufferSize];
            string savepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\dotNetFx 35setup.exe";
            FileStream fileStream = null;
            HttpWebResponse myWebResponse = null;
            if(File.Exists(savepath))
            {
                File.Delete(savepath);
            }

            fileStream = new FileStream(savepath, FileMode.OpenOrCreate);
            try
            {
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                if(myHttpWebRequest != null)
                {
                    myWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                    Stream responseSteam = myWebResponse.GetResponseStream();
                    int readSize = responseSteam.Read(BufferRead, 0, BufferSize);
                    while(readSize > 0)
                    {
                        fileStream.Write(BufferRead, 0, readSize);
                        readSize = responseSteam.Read(BufferRead, 0, BufferSize);
                    }
                    rtbState.Text = "文件下载完成, 文件大小为：" + fileStream.Length + "下载路径为：" + savepath;
                }
            }
            catch(Exception e)
            {
                rtbState.Text = "下载过程中发生异常，异常信息为" + e.Message; 
            }
            finally
            {
                if(myWebResponse != null)
                {
                    myWebResponse.Close();
                }

                if(fileStream != null)
                {
                    fileStream.Close();
                }
            }
        }
    }
}
