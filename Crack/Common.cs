using System;
using System.Text;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace Crack
{
    public class Common
    {
        /// <summary>
        /// 获取json文件内容
        /// </summary>
        /// <returns></returns>
        private static string JsonText()
        {
            Assembly asm = Assembly.Load("Crack");//文件所在的项目 
            Stream sm = asm.GetManifestResourceStream("Crack.Resources.json.txt");//文件的路径,程序集.路径.文件名 
            StreamReader sr = new StreamReader(sm);
            string jsonText = sr.ReadToEnd();
            sr.Close();
            return jsonText;
        }

        //static readonly StreamReader file = File.OpenText(@"C:\Users\Devil\Desktop\jdk\jdkPath.json");
        static readonly JsonTextReader reader = new JsonTextReader(new StringReader(JsonText()));
        static readonly JToken jo = JToken.ReadFrom(reader);
        public static IList<JToken> win = JArray.Parse(jo["Windows"].ToString());
        public static IList<JToken> linux = JArray.Parse(jo["Linux"].ToString());
        public static IList<JToken> mac = JArray.Parse(jo["macOS"].ToString());
        public static IList<JToken> solaris = JArray.Parse(jo["Solaris"].ToString());
        public static IList<string> OSName = new List<string>() {"Windows","Linux","macOS","Solaris" };
        public static IList<IList<JToken>> OStype = new List<IList<JToken>>(){win,linux,mac,solaris};

        /// <summary>
        /// 下载是否停止的状态
        /// </summary>
        public static bool StopDownLoad { get; set; } = true;
        public static int DownloadNum { get; set; } = 0;

        #region  判断是否联网
        [DllImport("winInet.dll")]
        private static extern bool InternetGetConnectedState(
        ref int dwFlag,
        int dwReserved
        );


        /// <summary>
        /// 判断是否联网
        /// </summary>
        /// <returns>true 是联网，false 是断网</returns>
        public static bool Networking()
        {
            try
            {
                Ping ping = new Ping();
                PingOptions poptions = new PingOptions();
                poptions.DontFragment = true;
                string data = string.Empty;
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                System.Int32 dwFlag = new int();
                if (!InternetGetConnectedState(ref dwFlag, 0))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("判断是否联网！" + ex.Message);
            }
        }

        public static void DialogNetworking(string Prompt)
        {
            MessageBox.Show(Prompt, "系统消息");
        }
        #endregion
    }
}
