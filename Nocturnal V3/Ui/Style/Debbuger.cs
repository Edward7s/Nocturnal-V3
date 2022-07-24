
using Nocturnal.Ui;
using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using System.Threading;

namespace Nocturnal.Style
{
    internal class Debbuger
    {
        private static string _lastlines = "";
        private string _error { get; set; }

        public static void ExceptionHandler()
        {

            AppDomain.CurrentDomain.FirstChanceException += (sender, eventArgs) =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("//////////////////[Please Report This To Noctunral Server]//////////////////");
                Console.WriteLine("Send The Log.log from Nocturnal folder to a ticket channel");
                Console.WriteLine("[ERROR]: " + eventArgs.Exception.ToString());
                Console.WriteLine("///////////////////////////////////////////////////////////////////////////");
                File.AppendAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Log.log", $"\n//////////////////////////////////////////////////////\n[ERROR]: {eventArgs.Exception.ToString()}\n//////////////////////////////////////////////////////");

            };

         /*   AppDomain.CurrentDomain.UnhandledException += (sender, eventArgs) =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("//////////////////[Please Report This To Noctunral Server]//////////////////");
                Console.WriteLine("Send The Log.log from Nocturnal folder to a ticket channel");
                Console.WriteLine("[ERROR]: " + eventArgs.ExceptionObject.ToString());
                Console.WriteLine("///////////////////////////////////////////////////////////////////////////");
                File.AppendAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Log.log", $"\n//////////////////////////////////////////////////////\n[ERROR]: {eventArgs.ExceptionObject.ToString()}\n//////////////////////////////////////////////////////");

            };


            Application.ThreadException += (sender, eventArgs) =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("//////////////////[Please Report This To Noctunral Server]//////////////////");
                Console.WriteLine("Send The Log.log from Nocturnal folder to a ticket channel");
                Console.WriteLine("[ERROR]: " + eventArgs.Exception.ToString());
                Console.WriteLine("///////////////////////////////////////////////////////////////////////////");
                File.AppendAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Log.log", $"\n//////////////////////////////////////////////////////\n[ERROR]: {eventArgs.Exception.ToString()}\n//////////////////////////////////////////////////////");

            };*/

        }


        public static string Debugermsg(string text)
        {
            try
            {
                if (!Settings.ConfigVars.qmdebug)
                    return null;

                //   while (Qm_basic._debugtext.text == null)
                //    return null;


                if (_lastlines != string.Empty)
                {
                    var today = System.DateTime.Now;
                    var stringtime = today.ToString("HH:mm:ss");
                    Qm_basic._debugtext.text = "";
                    Qm_basic._debugtext.text = $"</color>[<color=#ff1f53>{stringtime}</color>] - {text}\n{_lastlines}";
                    _lastlines = Qm_basic._debugtext.text;
                }
                else
                {
                    var today = System.DateTime.Now;
                    var stringtime = today.ToString("HH:mm:ss");
                    Qm_basic._debugtext.text = $"</color>[<color=#ff1f53>{stringtime}</color>] - {text}\n";
                    _lastlines = Qm_basic._debugtext.text;
                }
                if (_lastlines.Split('\n').Length > 15)
                {
                    string stringi = "";
                    int ab = 0;
                    foreach (var line in _lastlines.Split('\n'))
                    {
                        ab += 1;
                        if (ab < 17)
                            stringi += $"{line}\n";

                    }
                    _lastlines = stringi;
                }
                Qm_basic._debugtext.text = _lastlines;
            }
            catch { }
            System.GC.Collect();
           

            return _lastlines;
        }
    }
}
