using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nocturnal
{


    class NocturnalC
    {
     
        private static string _MessageType { get; set; }
        private static System.DateTime _Time { get; set; }

        internal static void Log(object message, string types = "Blank", ConsoleColor color = ConsoleColor.White,bool msg = true)
        {
            _Time = System.DateTime.Now;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($"[{_Time.ToString("HH:mm:ss")}]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($":");
            Console.ForegroundColor = ConsoleColor.Red;
            _MessageType = types == "Blank" ? " => " : $"[{types}] => ";
            Console.Write($"[N:V3]{_MessageType}");
            Console.ForegroundColor = color;
            Console.Write(message.ToString());
            Console.WriteLine();
            try
            {
                File.AppendAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Log.log", $"\n[{_Time.ToString("HH:mm:ss")}][{types}] =>{message.ToString()}");

            }
            catch { }

        }
    }
}
