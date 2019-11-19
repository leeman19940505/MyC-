using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml;

namespace PPTApiInvocationTest
{
    class Program 
    {
        static string data;
        static JObject json;
        static void Main(string[] args)
        {
            LoadData();
            if (LoadJson()) //已经获取到数据
            {
                InvocatePPTApi();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void LoadData() 
        {
            //文件路径
            string filePath = @"C:\Users\69439\Desktop\PPTAPIInvocationData.txt";

            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
                    {
                        data = sr.ReadToEnd();
                        byte[] mybyte = Encoding.UTF8.GetBytes(data);
                        data = Encoding.UTF8.GetString(mybyte);
                    }
                }
                else
                {
                    Console.WriteLine("no existed");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static bool LoadJson()
        {
            if(data != null && data.Length > 0)
            {
                json = (JObject)JsonConvert.DeserializeObject(data);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        private static void InvocatePPTApi()
        {
            WebReference.PPTService webservice = new WebReference.PPTService();
            string data = JsonConvert.SerializeObject(json["transferInfo"]);
            string result = webservice.CreatePPT(data);
        }
    }
}
