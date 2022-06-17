using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
namespace Nocturnal.Settings
{
    internal class Download_Files
    {
        internal static string shaderlist = null;
        internal static string userwhitelist = null;


        private static string nameplates = "https://nocturnal-client.xyz/Resources/namepalte.png";
        private static string Nameplateicon = "https://nocturnal-client.xyz/Resources/iconbackground.png";
        private static string playerlistmask = "https://nocturnal-client.xyz/Resources/maskplist.png";
        private static string playerlistborder = "https://nocturnal-client.xyz/Resources/playerlistborder.png";
        private static string quickmenumask = "https://nocturnal-client.xyz/Resources/qmmask.png";
        private static string Main = "https://nocturnal-client.xyz/Resources/icons/Base.png";
        private static string Saveconfig = "https://nocturnal-client.xyz/Resources/icons/Save%20Config.png";
        private static string EnterKey = "https://nocturnal-client.xyz/Resources/icons/Key.png";
        private static string ui = "https://nocturnal-client.xyz/Resources/icons/Ui.png";
        private static string Toggles = "https://nocturnal-client.xyz/Resources/icons/Toggle.png";
        private static string Target = "https://nocturnal-client.xyz/Resources/icons/target.png";
        private static string Anitcrash = "https://nocturnal-client.xyz/Resources/icons/anticrash.png";
        private static string Colors = "https://nocturnal-client.xyz/Resources/icons/Colors.png";
        private static string clipboard = "https://nocturnal-client.xyz/Resources/icons/clipboard.png";
        private static string World = "https://nocturnal-client.xyz/Resources/icons/World.png";
        private static string items = "https://nocturnal-client.xyz/Resources/icons/items.png";
        private static string worldhistory = "https://nocturnal-client.xyz/Resources/icons/World%20History.png";
        private static string mute = "https://nocturnal-client.xyz/Resources/icons/Microphone.png";
        private static string defean = "https://nocturnal-client.xyz/Resources/icons/defean.png";
        private static string next = "https://nocturnal-client.xyz/Resources/icons/rightarrow.png";
        private static string prev = "https://nocturnal-client.xyz/Resources/icons/leftarrow.png";
        private static string stopplay = "https://nocturnal-client.xyz/Resources/icons/playpause.png";
        private static string logo = "https://nocturnal-client.xyz/Resources/Nocturnal%20logo.png";
        private static string chatmask = "https://nocturnal-client.xyz/Resources/chatmask.png";
        private static string chat = "https://nocturnal-client.xyz/Resources/Chat.png";
        private static string Mirror = "https://nocturnal-client.xyz/Resources/Mirror.png";
        private static string OptimizedMirror = "https://nocturnal-client.xyz/Resources/optimized%20mirror.png";
        private static string teleport = "https://nocturnal-client.xyz/Resources/Teleport.png";
        private static string tag = "https://nocturnal-client.xyz/Resources/Tagas.png";
        private static string Discord = "https://nocturnal-client.xyz/Resources/Discord.png";
        private static string micmenu = "https://nocturnal-client.xyz/Resources/mic%20icon.png";
        private static string PremiumIcon = "https://nocturnal-client.xyz/Resources/Gold%20Tags.png";


        internal static string musicpath = null;
        internal static string loadingscreenmusicpath = null;
        internal static string joinsound = null;
        internal static MethodInfo runrpc = null;
        internal static MethodInfo activitymanager = null;
        internal static MethodInfo setworldinfo = null;
        internal static byte[] loadingscreen = null;
        internal static byte[] shaderesp = null;
        internal static byte[] Rain = null;
        internal static byte[] uinotifications = null;
        internal static jsonmanager.downloadhandler imagehandler;
        internal static void DownloadHanler()
        {
            var sttime = Stopwatch.StartNew();
            NocturnalC.Log("Starting DownloadHander");
            var webclient = new System.Net.WebClient();
            Rain = webclient.DownloadData("https://nocturnal-client.xyz/Resources/rain2");
            loadingscreen = webclient.DownloadData("https://nocturnal-client.xyz/Resources/loading");
            shaderesp = webclient.DownloadData("https://nocturnal-client.xyz/Resources/outline");
            uinotifications = webclient.DownloadData("https://nocturnal-client.xyz/Resources/ui");
            shaderlist = webclient.DownloadString("https://nocturnal-client.xyz/cl/anticrashshader.txt");

            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3"))
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Nocturnal V3");

            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config"))
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config");

            
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Config.json"))
                File.Create(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Config.json").Close();

            if (!File.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\ImageManager.json"))
            {
                File.Create(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\ImageManager.json").Close();

                var jslist = new jsonmanager.downloadhandler()
                {
                    micmenu = Convert.ToBase64String(webclient.DownloadData("https://nocturnal-client.xyz/Resources/mic%20icon.png")),         
                };
                File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\ImageManager.json", Newtonsoft.Json.JsonConvert.SerializeObject(jslist));
               
            }
            jsonmanager.downloadhandler imagemanagerdata = Newtonsoft.Json.JsonConvert.DeserializeObject<jsonmanager.downloadhandler>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\ImageManager.json"));
            var downloadprivatefields = typeof(Download_Files);
            var fieldslist = downloadprivatefields.GetFields(BindingFlags.NonPublic | BindingFlags.Static);
            var props = imagemanagerdata.GetType().GetProperties();
            bool needrewrite = false;
            using (var client = new System.Net.WebClient())
            {
                for (int i = 0; i < props.Length; i++)
                {
                    if (props[i].GetValue(imagemanagerdata) != null) continue;
                    props[i].SetValue(imagemanagerdata, Convert.ToBase64String(client.DownloadData(fieldslist.Where(field => field.Name == props[i].Name).FirstOrDefault().GetValue(props).ToString())));
                    needrewrite = true;
                }
            }
              

            if (needrewrite)
                File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\ImageManager.json", Newtonsoft.Json.JsonConvert.SerializeObject(imagemanagerdata));            


            imagehandler = imagemanagerdata;



            if (!File.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AntiCrash.whitelist"))
                File.Create(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AntiCrash.whitelist").Close();

            if (!File.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\WorldHistory.json"))
                webclient.DownloadFile("https://nocturnal-client.xyz/Resources/WorldHistory.json", Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\WorldHistory.json");

            if (!File.Exists(Directory.GetCurrentDirectory() +  "\\UserLibs\\discord_game_sdk.dll"))
                webclient.DownloadFile("https://nocturnal-client.xyz/Resources/discord_game_sdk.dll", Directory.GetCurrentDirectory() + "\\UserLibs\\discord_game_sdk.dll");




            if (!File.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc"))
            {
                var setc = new jsonmanager.discordrpc()
                {
                    Details = "In my zone now.",

                    State = "That's what they told me.",

                    LargeImage = "https://nocturnal-client.xyz/Resources/guysmoke.gif",

                    ison = true,
                };
                File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc", Newtonsoft.Json.JsonConvert.SerializeObject(setc));
            }


            userwhitelist = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AntiCrash.whitelist");


            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\LoadingMusic"))
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\LoadingMusic");

            if (Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\LoadingMusic").Length == 0)
                webclient.DownloadFile("https://nocturnal-client.xyz/Resources/LoadingMusic.mp3", Directory.GetCurrentDirectory() + "\\Nocturnal V3\\LoadingMusic\\LoadingMusic.mp3");

            loadingscreenmusicpath = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\LoadingMusic").FirstOrDefault().ToString();



            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\QmMusic"))
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\QmMusic");

            if (Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\QmMusic").Length == 0)
                webclient.DownloadFile("https://nocturnal-client.xyz/Resources/Qmmusic.mp3", Directory.GetCurrentDirectory() + "\\Nocturnal V3\\QmMusic\\Qmmusic.mp3");

            musicpath = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\QmMusic").FirstOrDefault().ToString();



            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Joinsound"))
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Joinsound");

            if (Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Joinsound").Length == 0)
                webclient.DownloadFile("https://nocturnal-client.xyz/Resources/joinsound.mp3", Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Joinsound\\Joinsound.mp3");

            joinsound = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Joinsound").FirstOrDefault();




          //  if (!File.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Joinsound.mp3"))



        
            var bytes = webclient.DownloadData("https://nocturnal-client.xyz/Resources/discordrpc.dll");
            
            try
            {
                Assembly asembly = Assembly.Load(bytes);
                Type[] types = asembly.GetTypes();
                var callclass = types.Where(clname => clname.Name == "RPCM").FirstOrDefault();
                runrpc = callclass.GetMethod("startrpc", BindingFlags.NonPublic | BindingFlags.Static);
                activitymanager = callclass.GetMethod("updateRPC", BindingFlags.NonPublic | BindingFlags.Static);
                setworldinfo = callclass.GetMethod("setworld", BindingFlags.NonPublic | BindingFlags.Static);
            }
            catch (Exception ex)
            {
                NocturnalC.Log("DISCORD RICH PRESENCE FAILED: " + ex);
            }
            var bytess = webclient.DownloadData("https://nocturnal-client.xyz/cl/Download/Nocturnal%20Circle.ico");
            Stream stream = new MemoryStream(bytess);
            Icon icon = new Icon(stream);

            try
            {
                Main2._hwnd = Settings.imports.FindWindow(null, "VRChat");
                if (Main2._hwnd == IntPtr.Zero || Main2._hwnd == null)
                {
                    Main2._hwnd = Process.GetProcessById(Main2._pid).MainWindowHandle;
                }
            }
            catch {
                NocturnalC.Log("Exception In Finding the VRC Window,Tryng PID","ERROR");
                Main2._hwnd = Process.GetProcessById(Main2._pid).MainWindowHandle;
            }
            Settings.imports.SendMessage(Main2._hwnd, 0x0080, 0, icon.Handle);
            Settings.imports.SendMessage(Main2._hwnd, 0x0080, 1, icon.Handle);
            Settings.imports.SendMessage(imports.GetConsoleWindow(), 0x0080, 0, icon.Handle);
            Settings.imports.SendMessage(imports.GetConsoleWindow(), 0x0080, 1, icon.Handle);
            Settings.imports.SetWindowText(Main2._hwnd, "Nocturnal[VRChat]");
            webclient.Dispose();
            NocturnalC.Log($"Resources Downloaded In {sttime.Elapsed.ToString("hh\\:mm\\:ss\\.ff")} ", "Download Manager", ConsoleColor.Green);
            sttime.Stop();
            



        }
      
    }
}
