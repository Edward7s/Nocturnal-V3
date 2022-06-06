using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nocturnal.Settings
{
    internal class LoadConfig
    {
        /*  [DllImport("User32.dll", EntryPoint = "MessageBox",
             CharSet = CharSet.Auto)]
          internal static extern int MsgBox(
             IntPtr hWnd, string lpText, string lpCaption, uint uType);*/
       
        internal static void load()
        {
            var configtimer = System.Diagnostics.Stopwatch.StartNew();

            NocturnalC.Log("Checking Config", "Config Setup");

            if (File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Config.json") == string.Empty)
              ConfigVars.saveconfig(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Config.json");

            var mainl = Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Config.json"));
            foreach (var bbc in mainl.GetType().GetProperties())
            {
                try
                {

                    var bcc = bbc.GetValue(mainl);
                    bcc.ToString();
                   // NocturnalC.Log($"{bbc.Name}:{bcc}", "Config Setup", ConsoleColor.Yellow);
                }
                catch
                {
                 //   NocturnalC.Log(bbc.Name + " FAILED", "Config Setup", ConsoleColor.DarkRed);
                    var getfields = typeof(ConfigVars).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                    foreach (var a in getfields)
                    {
                        try
                        {
                            if (bbc.Name == a.Name)
                            {
                                bbc.SetValue(mainl, a.GetValue(getfields));

                            }
                        }
                        catch { NocturnalC.Log($"BIG FAIL {bbc.Name}", "Config Setup", ConsoleColor.Red); }
                    }

                }

            }

            

            ConfigVars.applyconfig($"{Directory.GetCurrentDirectory()}\\Nocturnal V3\\Config\\Config.json",mainl);
            var deserializedtexxt = JsonConvert.DeserializeObject<Settings.jsonmanager.discordrpc>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc"));
            ConfigVars.discordrichpresence = deserializedtexxt.ison;



            NocturnalC.Log($"Config Applied in {configtimer.Elapsed.ToString("hh\\:mm\\:ss\\.ff")} ", "Config Setup", ConsoleColor.Green);


    

            configtimer.Stop();
        }
    }
}
