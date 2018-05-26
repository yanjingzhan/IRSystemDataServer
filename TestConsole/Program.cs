using IRSystemDataServer.Model.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string content = File.ReadAllText(@"D:\work\昱佳科技研发\3DProject\IRCameraLibs\Test\bin\x86\Debug\h4");


            ushort[] fuckImage = Newtonsoft.Json.JsonConvert.DeserializeObject<ushort[]>(content);

            byte[] imageBuf = new byte[221184];

            IntPtr ip = Marshal.UnsafeAddrOfPinnedArrayElement(fuckImage, 0);
            Marshal.Copy(ip, imageBuf, 0, 221184);
                        
            InfraredData infraredData = new InfraredData
            {
                Id = 100,
                UserId = 100,
                AdminUserId = 100,
                ApointmentId = 30,
                CreateTime = DateTime.Now,
                GestureId = 1,
                Height = 384,
                Width = 288,
                WindowStart = 0,
                WindowWidth = 0,
                ModifiedTime = DateTime.Now,
                Data = imageBuf

            };

            string s = Newtonsoft.Json.JsonConvert.SerializeObject(infraredData);
        }
    }
}
