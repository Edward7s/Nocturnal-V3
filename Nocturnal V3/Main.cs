using UnityEngine;
using MelonLoader;
using System.Collections.Generic;
using System.Collections;
using UnhollowerRuntimeLib;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Linq;
using VRC.SDKBase;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Text;
using Newtonsoft.Json;
using System.Diagnostics;
namespace Nocturnal
{
    public class RunM : MelonMod
    {
        //Only for Debbuging
        public override void OnApplicationStart() => Main2.Start();
        public override void OnLateUpdate() => Main2.Update();
        public override void OnGUI() => Main2.OnGui();

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

        }



        internal static GameObject secondcamera = null;
        internal static bool isthirdpersonback = false;
        internal static bool isthirdp = false;



        public static void Update()
        {
           if (Settings.ConfigVars.discordrichpresence)
            Settings.Download_Files.callback.Invoke(Settings.Download_Files.callback, null);

            //   discord.RunCallbacks();

        
            if (Input.GetKeyDown(KeyCode.K))
            {
             //   var bot = GameObject.Find("/Decor/Vroomba").gameObject;
             //   var hg = VRC.Player.prop_Player_0.gameObject.transform.Find("AnimationController/HeadAndHandIK/RightEffector").GetComponent<VRCHandGrasper>();
          //   hg.field_Internal_VRC_Pickup_0 = bot.GetComponent<VRC_Pickup>();
          //    hg.field_Private_VRC_Pickup_0 = bot.GetComponent<VRC_Pickup>();
           //   hg.Method_Public_VRC_Pickup_0();
         //    hg.Method_Public_VRC_Pickup_1();

            }


            try
            {
                if (VRC.Player.prop_Player_0.transform == null)
                    return;
            }
            catch
            {
                return;
            }



                if (Settings.ConfigVars.bhop && Input.GetKey(KeyCode.Space) || Settings.ConfigVars.bhop && Input.GetKey(KeyCode.JoystickButton1))
                if (VRC.SDKBase.Networking.LocalPlayer.GetVelocity().y == 0) exploits.misc.jump();

            if (Input.GetKey(KeyCode.LeftControl))
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    exploits.Fly.flytoggle = !exploits.Fly.flytoggle;

                    Settings.wrappers.extensions.togglecontroller(!exploits.Fly.flytoggle);

                }

                if (Settings.ConfigVars.Thidperson)
                {
                    if (Input.GetKeyDown(KeyCode.T))
                    {
                        if (secondcamera != null && !isthirdpersonback)
                        {
                            GameObject.DestroyImmediate(secondcamera);
                            secondcamera = null;
                            Settings.wrappers.extensions.camera().gameObject.SetActive(true);
                            isthirdp = false;

                        }
                        else if (!isthirdpersonback)
                        {

                            secondcamera = new GameObject("Camera Holder");
                            secondcamera.AddComponent<Camera>();
                            secondcamera.transform.parent = Settings.wrappers.extensions.camera().transform;
                            secondcamera.transform.localEulerAngles = Vector3.zero;
                            secondcamera.transform.localScale = Vector3.one;
                            secondcamera.transform.localPosition = new Vector3(0, 0, -2);
                            Settings.wrappers.extensions.camera().gameObject.SetActive(false);
                            isthirdpersonback = true;
                            isthirdp = true;
                        }
                        else
                        {
                            secondcamera.transform.localPosition = new Vector3(0, 0, 2);
                            secondcamera.transform.localEulerAngles = new Vector3(0, -180, 0);
                            isthirdpersonback = false;
                        }
                    }

                    if (isthirdp)
                    {
                        if (Input.mouseScrollDelta.y == 1)
                        {
                            secondcamera.transform.localPosition = new Vector3(0, 0, secondcamera.transform.localPosition.z - 0.15f);
                        }


                        if (Input.mouseScrollDelta.y == -1)
                        {
                            secondcamera.transform.localPosition = new Vector3(0, 0, secondcamera.transform.localPosition.z + 0.15f);
                        }
                    }

                }



            }
            try
            {
                if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton1))
                {
                    if (exploits.Sitonparts.issiting)
                    {
                        exploits.Sitonparts.issiting = false;
                        Settings.wrappers.extensions.togglecontroller(true);
                    }
                    if (Settings.ConfigVars.infinitejump)
                        exploits.misc.jump();


                }

                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton1))
                {
                    if (Networking.LocalPlayer.GetJumpImpulse() == 0)
                    Networking.LocalPlayer.SetJumpImpulse(1);
                    if (Settings.ConfigVars.forcejump)
                        exploits.misc.jump();
                }
               

            }
            catch { }
            exploits.pickups.stopobjs();
            exploits.pickups.ownerpickups();
            exploits.orbit.orbituser();
            exploits.Fly.fly();
            exploits.zoom._zoom();
        }
        public static void OnGui()
        {

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



            Ui.Bundles.loadnotifications();
            var images = Resources.FindObjectsOfTypeAll<ImageThreeSlice>().ToArray();
            for (int i = 0; i < images.Length; i++)
                images[i].raycastTarget = false;




            NocturnalC.log("Founded UserInteface");
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
             MelonCoroutines.Start(exploits.playerlist.playerlistm());

        }

        private protected static void injectories()
        {
            ClassInjector.RegisterTypeInIl2Cpp<monobehaviours.pagemanager>();
            ClassInjector.RegisterTypeInIl2Cpp<monobehaviours.outline>();
            ClassInjector.RegisterTypeInIl2Cpp<monobehaviours.platemanager>();
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
