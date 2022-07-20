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
        public override void OnApplicationStart() => Main2.Start();
    }

 


    public class Main2
    {
        internal static int _pid = 123;
        internal static Thread _mainthread = null;
        internal static IntPtr _hwnd = IntPtr.Zero;
        internal static Process _CurentP { get; set; }
        internal static Dictionary<string,Action> _queueDictionary;

        [Obsolete]
        public static void Start()
        {
      //  Settings.wrappers.extensions.GetAllStrings(typeof(VRCUiPopupManager),typeof(string));
        
            _CurentP = Process.GetCurrentProcess();
            Main2._queueDictionary = new Dictionary<string, Action>(); 
            _pid = System.Diagnostics.Process.GetCurrentProcess().Id;
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
                    NocturnalC.Log("LOADER OUTDATED", "ERROR", ConsoleColor.Red);
                    NocturnalC.Log("Installing the new loader", "Asembly", ConsoleColor.Red);
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
            NocturnalC.Log("Loaded Plugins:", "Assembly's", ConsoleColor.DarkRed);
            Console.WriteLine();
            LogAsembleis(melonpluginslist);
            NocturnalC.Log("Loaded Mods:", "Assembly's", ConsoleColor.DarkRed);
            Console.WriteLine();
            LogAsembleis(melonmodslist);
            _mainthread = Thread.CurrentThread;
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
                            NocturnalC.Log($"Loaded in M:{float.Parse(DateTimeOffset.Now.ToString("mm")) - (float)minute} S:{float.Parse(DateTimeOffset.Now.ToString("ss.fff")) - (float)secondsandm}", "Start Up", ConsoleColor.Green);
                        }
                    }
                }
                catch { }
            }
            NocturnalC.Log("Client Loading", "Start Up");
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            var dateb = new DateTime(2000, 1, 1).AddDays(version.Build).AddSeconds(version.Revision * 2);
            NocturnalC.Log($"Builded on: [{dateb}]", "Assembly", ConsoleColor.Green);
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------");
            NocturnalC.Log("///////////////////////////////\n-Also Check Out NanoSDK (The best VRChat SDK).\n-https://nanosdk.net/discord\n///////////////////////////////////////////////////////////////", "Start Up", ConsoleColor.Green);
            NocturnalC.Log("Join the Discord server if u are not in it\nhttps://discord.nocturnal-client.xyz/", "Start Up", ConsoleColor.Green);
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine();
            Settings.Download_Files.DownloadHanler();
            Settings.Download_Files.runrpc.Invoke(Settings.Download_Files.runrpc, null);
            Settings.LoadConfig.load();
            Injectories();
            MelonCoroutines.Start(waitforuser());
            MelonCoroutines.Start(waitforui());
            Settings.Hooks.StartHooks();
            Settings.XRefedMethods.SetMethods();
            if (!Settings.ConfigVars.discordrichpresence)
                return;
            NocturnalC.Log("Clearing Unity Cache", "Unityengine");
            UnityEngine.Caching.CleanCache();
            VRC.Core.ApiCache.ClearCache();
            VRC.Core.ApiCache.ClearResponseCache();
            try
            {
                string vrcpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") + "\\VRChat\\VRChat";
                System.IO.File.WriteAllText(vrcpath + "\\config.json", "{\"disableRichPresence\":true}");
            }
            catch { }
        }



        private static Thread starsocket = new Thread(server.setup.serversetup);
        private static IEnumerator waitforuser()
        {
            while (VRC.Core.APIUser.CurrentUser == null)
                yield return null;
            NocturnalC.Log("User Logged in");
            Console.Title = $"Nocturnal V3 {{Welcome: [{VRC.Core.APIUser.CurrentUser.displayName}]}}";
            starsocket.Start();
            MelonCoroutines.Start(Settings.wrappers.extensions.clientmessagewaiter($"Hi {VRC.Core.APIUser.CurrentUser.displayName} <3"));
            yield break;
        }
        private static IEnumerator waitforui()
        {
            while (GameObject.Find("/UserInterface") == null)
                yield return null;
            NocturnalC.Log("Founded UserInteface");
            Ui.Bundles.loadnotifications();
            var images = Resources.FindObjectsOfTypeAll<ImageThreeSlice>().ToArray();
            for (int i = 0; i < images.Length; i++)
                images[i].raycastTarget = false;
            Ui.LoadingScreen.runti();
            while (GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)") == null)
                yield return new WaitForEndOfFrame();
            NocturnalC.Log("Founded QuickMenu");
            Ui.Bundles.Loadshader();
            Ui.Bundles.Loadingscreen();
            Ui.Objects.Collectobjs();
            Ui.Qm_basic.Setupstuff();
            Ui.Inject_monos.Inject();
            Ui.buttons_b.Runbuttons();
            while (GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window").gameObject.GetComponent<BoxCollider>() == null)
                yield return new WaitForEndOfFrame();
            GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window").gameObject.GetComponent<BoxCollider>().extents = new Vector3(880, 712, 0.5f);
            while (GameObject.FindObjectOfType<VRC.UI.Elements.MenuStateController>() == null)
                yield return new WaitForEndOfFrame();
            NocturnalC.Log("Initializing Custom Menu");
            Ui.qm.Main.Createmenu();
            Ui.resourceimages.Setupc();

            while (GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content/FavoriteContent/avatars1") == null)
                yield return new WaitForEndOfFrame();

            Ui.Favorites.Run();

            yield break;
           
        }
        private protected static void Injectories()
        {
            ClassInjector.RegisterTypeInIl2Cpp<Monobehaviours.UpdateManager>();
            ClassInjector.RegisterTypeInIl2Cpp<Monobehaviours.Pagemanager>();
            ClassInjector.RegisterTypeInIl2Cpp<Monobehaviours.Outline>();
            ClassInjector.RegisterTypeInIl2Cpp<Monobehaviours.Boomorbit>();
            ClassInjector.RegisterTypeInIl2Cpp<Monobehaviours.Teleportobj>();
            ClassInjector.RegisterTypeInIl2Cpp<Monobehaviours.Fly>();
            ClassInjector.RegisterTypeInIl2Cpp<Monobehaviours.Svastica>();
            ClassInjector.RegisterTypeInIl2Cpp<Monobehaviours.ItemMover>();
            ClassInjector.RegisterTypeInIl2Cpp<Monobehaviours.TagAnimation>();
            ClassInjector.RegisterTypeInIl2Cpp<Monobehaviours.ItemLagger >();
            ClassInjector.RegisterTypeInIl2Cpp<Monobehaviours.PlatesUpdator>();
            ClassInjector.RegisterTypeInIl2Cpp<Monobehaviours.PickupLevitation>();
            ClassInjector.RegisterTypeInIl2Cpp<Monobehaviours.PostProccesingManager>();
            ClassInjector.RegisterTypeInIl2Cpp<Monobehaviours.Trail>();

        }
        private protected static void LogAsembleis(List<MelonBase> melontblList)
        {
            if (melontblList.Count == 0)
            {
                NocturnalC.Log("None Loaded.", "Assembly's", ConsoleColor.DarkRed);
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
