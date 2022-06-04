using UnityEngine;
using MelonLoader;
using System.Collections.Generic;
using System.Collections;
using UnhollowerRuntimeLib;
using System;
using System.Reflection;
using System.Threading;
using System.Linq;
using VRC.SDKBase;
using System.IO;
using System.Diagnostics;

namespace Nocturnal
{
    public class RunM : MelonMod
    {
        //Only for Debbuging
        public override void OnApplicationStart() => Main2.Start();


    }
   
    public class Main2
    {
      

        internal static int pid = 123;
        internal static Thread mainthread = null;
        internal static IntPtr hwnd = IntPtr.Zero;

        public static void Start()
        {
           

            pid = System.Diagnostics.Process.GetCurrentProcess().Id;

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            string art = @"@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@....@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ (......................, *@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@@@@./.........................       .( @@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@@@@ ,,**/.     *          ........           .@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@@&**                            ......       .  /@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@,                                  /.....      .,..@@@@@@@
@@@@@@@@@@@@@@@@@@@@ ,   .(((((((((((((##                  ......,      ,.@@@@@@
@@@@@@@@@@@@@@@@@@@.   ,(((((/////////////(((#./#..          *...,.     .,/@@@@@
@@@@@@@@@@@@@@@@@@. ./(/(//////////////////////((((#.          (.,..       @@@@@
@@@@@@@@@@@@@@@@@@..///(///////////////////////#(/((((.         (*...       @@@@
@@@@@@@@@@@@@@@@@@@//// ////////***********/(//(//////((...      ....        @@@
@@@@@@@@@@@@@@@@@@...//*///****#*,,,,,,/,*****/*///(/////#..     ,...       (@@@
@@@@@@@@@@@@@@@@@..//////***,,,/,,,,,,,**,,,**(***/(///////,,.   ,...        ,@@
@@@@@@@@@@@@@@@@@,,////***,*              .,,@&&(**////////%(,,  ,...        /@@
@@@@@@@@@@./ ./. /*////// &@&&              .&&&&  #*//////(((#,,,...          @
@@@@@@@@*         ,////*/                    .,,*/%*///////(((((/*...         ,@
@@@@@@@@.          #//(%(...                      /***(/////###((#....        .(
@@@@@@@@@.           *////                          .*////(/####(#....          
@@@@@@@@@@@ .        ///////,      ///****        ,***////(/###(((,            *
@@@@@@@@@@@@@@ ,   .//////////.    /.....,*      (**//////(%##((/#,,            
@@@@@@@@@@@@@@@@@@@  /(*,         / ,.....       **//(((((((##((//#,.          *
@@@@@@@@@@@@@@@@@.,                 //*        ////(((((((%%##((///,,          .
@@@@@@@@@@@@....                     (((.///((/(/((((((((%%(##((////,,        ,@
@@@@@@.,                 ((            (  ((((/(((((((((((,,#(((/////(,,       @
@@@                      ///               (((/,.....,,,      ((//////(#,.    @@
@*            .           (((              .... ........,**. ((((///(/((#/.%@@@@
            ,,.            ((           *        .........****(((//(///(((/*@@@@
            @@(                       *       . .......... ***((/(((///(((//,@@@
          @@* ,(.                   /          .,.........  **##(((/////((///,@@
      , @@@@*  .,*                           .............. .*####((////((,(/,@@
(/.#@@@@@@@@@/  .,**(         /,          .........*.......  *#####////(#((*/(@@
@@@@@@@@@@@@@@.,,,,***/////**           ...................  *#####///(((.@@#.@@
@@@@@@@@@@@@@@@@@.,,*////*,.          .....................  *(((((///((.@@@(@@@
@@@@@@@@@@@@@@@@@@@,*////. ..,      .........,,,*,,........  (((((((,//&@@@ @@@@
@@@@@@@@@@@@@@@@@@@@ ///*      .. .......,,,***,...........  (((( *.(#/&@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@***         .....(******.............   ((.@,#@@@.(@@@@@@@@
@@@@@@@@@@@@@@@@@@@@#           **/////***,...............  ,@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@*            */////(*****.............  ..@@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@              ////(.,,****,..........   . @@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@/*    .,,**///*...,*****,,,......    *,.@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@**     *,,(////....,***..,,,....     /,*@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@***     ,,,,/////....,***.......     .,,.@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@***      *,,*/////.....,,,.....  .   .,**@@@@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@/        /,,/////(.....,,.....      ,**** @@@@@@@@@@@@@@@@
@@@@@@@@@@@@@@@@@@@@@@, *        / ,///............      ,******.@@@@@@@@@@@@@@@
";



            Console.WriteLine(art);         

            
               List<MelonBase> melonmodslist = new List<MelonBase>(MelonLoader.MelonHandler.Mods);
            melonmodslist.Sort((MelonBase left, MelonBase right) => string.Compare(left.Info.Name, right.Info.Name));

           MelonBase mod = melonmodslist.Where(mod => mod.Info.Name == "Nocturnal Loader").FirstOrDefault();
            if (mod != null)
            {
                System.Net.WebClient webclient = new System.Net.WebClient();
                string clientversion = webclient.DownloadString("https://nocturnal-client.xyz/Resources/loaderversion.txt");
                if (mod.Info.Version != clientversion)
                {
                    NocturnalC.log("LOADER OUTDATED", "ERROR", ConsoleColor.Red);
                    NocturnalC.log("Installing the new loader", "Asembly", ConsoleColor.Red);
                    MelonLogger.Error("Installing the new loader");
                    string filepath = mod.Location;
                    File.Delete(filepath);
                    webclient.DownloadFile("https://nocturnal-client.xyz/Resources/Nocturnal%20Loader.dll", filepath);
                    string arguments = "";
                    foreach (string stringi in Environment.GetCommandLineArgs())
                    {
                        arguments += $"{stringi} ";
                    }
                    Process vrc = new Process();
                    vrc.StartInfo.FileName = $"{Directory.GetCurrentDirectory()}\\VRChat.exe";
                    vrc.StartInfo.Arguments = arguments;
                    vrc.Start();
                    Process.GetCurrentProcess().Kill();
                }
            }
   

            List<MelonBase> melonpluginslist = new List<MelonBase>(MelonLoader.MelonHandler.Plugins);
            melonpluginslist.Sort((MelonBase left, MelonBase right) => string.Compare(left.Info.Name, right.Info.Name));

            NocturnalC.log("Loaded Plugins:", "Assembly's", ConsoleColor.DarkRed);
            Console.WriteLine();

            logasembl(melonpluginslist);


            NocturnalC.log("Loaded Mods:", "Assembly's",ConsoleColor.DarkRed);
            Console.WriteLine();
            logasembl(melonmodslist);

            mainthread = System.Threading.Thread.CurrentThread;
            AppDomain currentDomain = AppDomain.CurrentDomain;

            Assembly[] assems = currentDomain.GetAssemblies();

            for (int i = 0; i < assems.Length; i++)
            {
                try
                {
                    if (!assems[i].ToString().Contains("Nocturnal Load")) continue;
                        var types = assems[i].GetTypes();
                        {
                            for (int i2 = 0; i2 < types.Length; i2++)
                            {
                            if (types[i2].Name != "main") continue;
                                    var minute = types[i2].GetField("minute", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
                                    var secondsandm = types[i2].GetField("second", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
                                    NocturnalC.log($"Loaded in M:{float.Parse(DateTimeOffset.Now.ToString("mm")) - (float)minute} S:{float.Parse(DateTimeOffset.Now.ToString("ss.fff")) - (float)secondsandm}", "Start Up", ConsoleColor.Green);
                            }
                        }
                }
                catch { }
            }
            NocturnalC.log("Client Loading","Start Up");
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            var dateb = new DateTime(2000, 1, 1).AddDays(version.Build).AddSeconds(version.Revision * 2);
            NocturnalC.log($"Builded on: [{dateb}]","Assembly",ConsoleColor.Green);
           

            NocturnalC.log("///////////////////////////////\nRember Using stuff in murder can lead to a crashs\nMurder and prison breack got a custom anticheat for it from what it seams like><\n//////////////////////////////////////////////////////////////", "Start Up",ConsoleColor.Red);
            NocturnalC.log("Join the Discord server if u are not in it\nhttps://discord.nocturnal-client.xyz/", "Start Up", ConsoleColor.Green);
            
            Settings.Download_Files.DownloadHanler();
            Settings.LoadConfig.load();
            injectories();
            MelonCoroutines.Start(waitforuser());
            MelonCoroutines.Start(waitforui());
            Settings.Hooks.StartHooks();








            if (!Settings.ConfigVars.discordrichpresence)
                return;


            NocturnalC.log("Starting Discord RPC", "DiscordRPC");
            Settings.Download_Files.runrpc.Invoke(Settings.Download_Files.runrpc, null);


            NocturnalC.log("Clearing Unity Cache", "Unityengine");
            UnityEngine.Caching.CleanCache();
            
            var vrcpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") + "\\VRChat\\VRChat";
            
            var files = Directory.GetFiles(vrcpath + "\\Cache-WindowsPlayer");
          

            System.IO.File.WriteAllText(vrcpath + "\\config.json", "{\"disableRichPresence\":true}");

        }


       
        private static Thread starsocket = new Thread(server.setup.serversetup);
        private static IEnumerator waitforuser()
        {
            while (VRC.Core.APIUser.CurrentUser == null)
                yield return null;

            NocturnalC.log("User Logged in");
            Console.Title = $"Nocturnal V3 {{Welcome: [{VRC.Core.APIUser.CurrentUser.displayName}]}}";

            starsocket.Start();
            MelonCoroutines.Start(Settings.wrappers.extensions.clientmessagewaiter($"Hi {VRC.Core.APIUser.CurrentUser.displayName} <3"));

         
        }


        private static IEnumerator waitforui()
        {
            while (GameObject.Find("/UserInterface") == null)
               yield return null;

            NocturnalC.log("Founded UserInteface");


            Ui.Bundles.loadnotifications();
            var images = Resources.FindObjectsOfTypeAll<ImageThreeSlice>().ToArray();
            for (int i = 0; i < images.Length; i++)
                images[i].raycastTarget = false;


            GameObject NocturnalUpdateManager = new GameObject("NocturnalUpdateManager");
            NocturnalUpdateManager.AddComponent<monobehaviours.UpdateManager>();
            NocturnalUpdateManager.transform.parent = GameObject.Find("/_Application").transform;




           Nocturnal.Ui.LoadingScreen.runti();
            while (GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)") == null)
                yield return null;

            NocturnalC.log("Founded QuickMenu");
            Ui.Bundles.loadshader();
            Ui.Bundles.loadingscreen();
            Nocturnal.Ui.objects.collectobjs();
            Nocturnal.Ui.Qm_basic.setupstuff();
            Nocturnal.Ui.Inject_monos.inject();
             Nocturnal.Ui.buttons_b.runbuttons();
              Nocturnal.Ui.qm.Main.createmenu();
             Ui.resourceimages.setupc();
             MelonCoroutines.Start(exploits.hudinfo.playerlistm());

            while (GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window").gameObject.GetComponent<BoxCollider>() == null)
                yield return null;
            GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window").gameObject.GetComponent<BoxCollider>().extents = new Vector3(880, 712, 0.5f);

        }

        private protected static void injectories()
        {
            ClassInjector.RegisterTypeInIl2Cpp<monobehaviours.UpdateManager>();
            ClassInjector.RegisterTypeInIl2Cpp<monobehaviours.pagemanager>();
            ClassInjector.RegisterTypeInIl2Cpp<monobehaviours.outline>();
            ClassInjector.RegisterTypeInIl2Cpp<monobehaviours.platemanager>();
            ClassInjector.RegisterTypeInIl2Cpp<monobehaviours.boomorbit>();
            ClassInjector.RegisterTypeInIl2Cpp<monobehaviours.Teleportobj>();

        }



        private protected static void logasembl(List<MelonBase> melontblList)
        {
            if (melontblList.Count == 0)
            {
                NocturnalC.log("None Loaded.", "Assembly's", ConsoleColor.DarkRed);
                Console.WriteLine();
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"[------------------------------------<>------------------------------------][0]");

            for (int i2 = 0; i2 < melontblList.Count; i2++)
            {


                string name = "";
                var Color = ConsoleColor.DarkRed;

                if (melontblList[i2].Info.Name.Contains("Nocturnal"))
                    Color = ConsoleColor.Yellow;

                Console.ForegroundColor = Color;
                Console.Write($"[Name] ");
                Console.ForegroundColor = melontblList[i2].ConsoleColor;

                for (int i = 0; i < melontblList[i2].Info.Name.Length; i++)
                {
                    name += melontblList[i2].Info.Name[i] + " ";
                }
                Console.Write(name);
                Console.WriteLine();
                Console.ForegroundColor = Color;
                Console.Write($"[Author] ");
                Console.ForegroundColor = melontblList[i2].ConsoleColor;
                Console.Write(melontblList[i2].Info.Author);
                Console.WriteLine();

                Console.ForegroundColor = Color;
                Console.Write($"[Version] ");
                Console.ForegroundColor = melontblList[i2].ConsoleColor;
                Console.Write(melontblList[i2].Info.Version);
                Console.WriteLine();

                Console.ForegroundColor = Color;
                Console.Write($"[Id] ");
                Console.ForegroundColor = melontblList[i2].ConsoleColor;
                Console.Write(melontblList[i2].Info.TypeId);
                Console.WriteLine();

                Console.ForegroundColor = Color;
                Console.Write($"[Path] ");
                Console.ForegroundColor = melontblList[i2].ConsoleColor;
                Console.Write(melontblList[i2].Location);
                Console.WriteLine();

                if (melontblList[i2].Info.DownloadLink != null)
                {
                    Console.ForegroundColor = Color;
                    Console.Write($"[Dl] ");
                    Console.ForegroundColor = melontblList[i2].ConsoleColor;
                    Console.Write(melontblList[i2].Info.DownloadLink);
                    Console.WriteLine();
                }
                Console.ForegroundColor = Color;
                Console.WriteLine($"[------------------------------------<>------------------------------------][{i2 + 1}]");

            }

            Console.WriteLine();

        }
    }
}
