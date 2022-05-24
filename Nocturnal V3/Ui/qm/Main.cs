using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Nocturnal.Apis.qm;
using VRC;
using System.Diagnostics;
using System.IO;
using VRC.SDKBase;
using VRC.UI;
using UnityEngine;
using VRC.Core;
using Nocturnal.Settings.wrappers;
using Nocturnal.Settings;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace Nocturnal.Ui.qm
{
    internal class Main
    {
        internal static UnityEngine.GameObject mainpage = null;
        internal static TMPro.TextMeshProUGUI jumpimpulse = null;
        internal static bool stopev7 = false;

        [DllImport("user32.dll")] //Set the active window

        public static extern IntPtr SetActiveWindow(IntPtr hWnd);



     
        internal static void createmenu()
        {

            mainpage = submenu.Submenu("Nocturnal", null,true);
            var Main = submenu.Submenu("Main", mainpage);
            Page.page("Nocturnal", mainpage, Settings.Download_Files.imgr);

            Anticrash.runanti();
            Toggles.runantoggles();
            ui.runui();
            Target.targetmenu();
            Pickups.pickups();
            world.World();
            onuser.Onuser();
            worldhistory.createrhistory();
            tags.Tagsmenu();
            chat.Chat();
            Discord.start();
            Buttons.Button(extensions.getmenu(mainpage), "Close", () => Process.GetCurrentProcess().Kill(), true, null,3, 6);
            Buttons.Button(extensions.getmenu(mainpage), "Restart", () => 
            {
                string arguments = "";
                foreach (string stringi in Environment.GetCommandLineArgs())
                {
                    arguments += $"{stringi} ";
                }
                System.Diagnostics.Process vrc = new System.Diagnostics.Process();
                vrc.StartInfo.FileName = $"{Directory.GetCurrentDirectory()}\\VRChat.exe";
                vrc.StartInfo.Arguments = arguments;
                vrc.Start();
                Process.GetCurrentProcess().Kill();

            }, true, null, 3, 7);
            Buttons.Button(extensions.getmenu(mainpage), "Change avi", () => 
            {
                try
                {
                    string aviid = "";
                    Apis.inputpopout.run("Avatar id", value => aviid = value, () => {
                       exploits.misc.changetoavi(aviid);
                    });


                }

                catch
                {
                  NocturnalC.log("Cloud not change into that avatar");
                }


            }, true, null, 2, 6);
            Buttons.Button(extensions.getmenu(mainpage), "Join By Id", () => 
            {
                string roomid = "";
                Apis.inputpopout.run("Room Instance Id", value => roomid = value, () => {
                    if (!Networking.GoToRoom(roomid))
                    {
                        string[] array = roomid.Split(':');
                        new PortalInternal().Method_Private_Void_String_String_PDM_0(array[0], array[1]);
                    }
                });

            }, true, null, 2, 7);
            Buttons.Button(extensions.getmenu(mainpage), "Delete P", () => exploits.misc.deletportals(), true,null, 1, 6);
            jumpimpulse = Buttons.Button(extensions.getmenu(mainpage), "Jump Imp", () => 
            {
                try
                {
                    Apis.inputpopout.run("Jump Impulse", value => Settings.ConfigVars.jumpimpulse = float.Parse(value), () => { });
                    Networking.LocalPlayer.SetJumpImpulse(Settings.ConfigVars.jumpimpulse);
                    jumpimpulse.text = $"[{Networking.LocalPlayer.GetJumpImpulse()}] Jump imp";
                }
                catch { }
              
            }, true, null, 1, 7).gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            Buttons.Button(extensions.getmenu(mainpage), "Save Config", () => { Settings.ConfigVars.saveconfig($"{Directory.GetCurrentDirectory()}\\Nocturnal V3\\Config\\Config.json"); NocturnalC.log("Saved Config", "Settings", ConsoleColor.Green);
            }, false, Settings.Download_Files.Saveconfig, 1, 0);

            Buttons.Button(extensions.getmenu(mainpage), "Enter Key", () => 
            {
                imports.SetForegroundWindow(imports.GetConsoleWindow());

                NocturnalC.log("Enter Your Key", "Verification", ConsoleColor.Green);
                string getkey = Console.ReadLine();
                NocturnalC.log("Enter A Username u want", "Verification", ConsoleColor.Red);
                string getusername = Console.ReadLine();

                var sendinfo = new jsonmanager.custommsg2()
                {
                    code = "3",

                    msg = getkey.Trim(),

                    msg2 = getusername.Trim(),
                };
                server.setup.sendmessage(Newtonsoft.Json.JsonConvert.SerializeObject(sendinfo));

                File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp", Newtonsoft.Json.JsonConvert.SerializeObject(sendinfo));

                var newmsg = new Settings.jsonmanager.custommsg2()
                {
                    code = "4",

                    msg = JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg2>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")).msg,

                    msg2 = JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg2>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")).msg2,

                };

                server.setup.sendmessage(JsonConvert.SerializeObject(newmsg));

            }, false, Settings.Download_Files.EnterKey, 2, 0);

            Toggle.toggle("Fly", extensions.getmenu(mainpage), () => {
                exploits.Fly.flytoggle = true;
                extensions.togglecontroller(!exploits.Fly.flytoggle);

            }, () => {
                exploits.Fly.flytoggle = false;
                extensions.togglecontroller(!exploits.Fly.flytoggle);


            }, exploits.Fly.flytoggle, true, 0, 6);
            Toggle.toggle("Esp", extensions.getmenu(mainpage), () =>
            {
                Settings.ConfigVars.esp = true;
                var player = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0;
                for (int i = 0; i < player.Count; i++)
                {
                    if (player[i].field_Private_APIUser_0.id != VRC.Core.APIUser.CurrentUser.id)
                    player[i].transform.Find("SelectRegion/ESP").gameObject.SetActive(true);
                }

            }, () => 
            {
                Settings.ConfigVars.esp = false;
                var player = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0;
                for (int i = 0; i < player.Count; i++)
                {
                   
                        if (player[i].field_Private_APIUser_0.id != VRC.Core.APIUser.CurrentUser.id)
                            player[i].transform.Find("SelectRegion/ESP").gameObject.SetActive(false);
                  
                   
                }

            }, Settings.ConfigVars.esp, true, 0, 7);
            mainpage.getmenu().submenu("Main", Main, Settings.Download_Files.Main, false, 0, 0);







            Apis.Slider.slider(extensions.getmenu(Main), value => Settings.ConfigVars.Flyspeed = value, Settings.ConfigVars.Flyspeed, () =>
            {
            }, true, "Fly Speed");


            Apis.qm.Toggle.toggle("Mirror", extensions.getmenu(Main), () => exploits.Mirror.togglemirror(true), () => exploits.Mirror.togglemirror(false));

            Apis.qm.Toggle.toggle("Optimized Mirror", extensions.getmenu(Main), () => exploits.Mirror.togglemirror(true,true), () => exploits.Mirror.togglemirror(false));

            Apis.qm.Toggle.toggle("Ghost Mode", extensions.getmenu(Main), () => stopev7 = true, () => stopev7 = false, stopev7);




            objects.qmexpand.transform.parent.gameObject.minib("Copy instance id to clipboard", () =>
              {
                  var worldid = RoomManager.prop_String_0;
                  NocturnalC.log(worldid);
                  System.Windows.Forms.Clipboard.SetText(worldid);
              }, Settings.Download_Files.clipboard);


            objects.qmexpand.transform.parent.gameObject.minib("Previous Track (Spotify)", () =>
            {
                var p = Process.GetProcessesByName("Spotify").FirstOrDefault();

                try
                {
                    Thread.Sleep(100);

                    imports.SetForegroundWindow(p.MainWindowHandle);
                    Thread.Sleep(100);

                    imports.keybd_event(0x11, 0, 0, 0);
                    imports.keybd_event(0x25, 0, 0, 0);
                    imports.keybd_event(0x11, 0, 2, 0);
                    imports.keybd_event(0x25, 0, 2, 0);
                }
                catch { }

                Thread.Sleep(100);




                imports.SetForegroundWindow(Main2.hwnd);
            }, Settings.Download_Files.prev);

            objects.qmexpand.transform.parent.gameObject.minib("Play Pause (Spotify)", () =>
            {
                var p = Process.GetProcessesByName("Spotify").FirstOrDefault();

                try
                {
                    Thread.Sleep(100);

                    imports.SetForegroundWindow(p.MainWindowHandle);
                    Thread.Sleep(100);

                    imports.keybd_event(0x20, 0, 0, 0);
                    imports.keybd_event(0x20, 0, 2, 0);
                }
                catch { }

                Thread.Sleep(100);


                imports.SetForegroundWindow(Main2.hwnd);
            }, Settings.Download_Files.stopplay);


            objects.qmexpand.transform.parent.gameObject.minib("Next Track (Spotify)", () =>
            {
                var p = Process.GetProcessesByName("Spotify").FirstOrDefault();

                try
                {
                    Thread.Sleep(100);

                    imports.SetForegroundWindow(p.MainWindowHandle);
                    Thread.Sleep(100);

                    imports.keybd_event(0x11, 0, 0, 0);
                    imports.keybd_event(0x27, 0, 0, 0);
                    imports.keybd_event(0x11, 0, 2, 0);
                    imports.keybd_event(0x27, 0, 2, 0);
                }
                catch { }
                Thread.Sleep(100);


                imports.SetForegroundWindow(Main2.hwnd);
            }, Settings.Download_Files.next);


            objects.qmexpand.transform.parent.gameObject.minib("Mute (Discord)", () =>
            {
              //  var p = Process.GetProcesses().Where(pname => pname.ProcessName.Contains("Discord")).FirstOrDefault();
                var p = Process.GetProcessesByName("Discord").FirstOrDefault();


                try
                {
                    Thread.Sleep(100);

                    imports.SetForegroundWindow(p.MainWindowHandle);
                    Thread.Sleep(100);

                    imports.keybd_event(0xA2, 0, 0, 0);
                    imports.keybd_event(0xA0, 0, 0, 0);
                    imports.keybd_event(0x4D, 0, 0, 0);

                    imports.keybd_event(0xA2, 0, 0x0002, 0);
                    imports.keybd_event(0xA0, 0, 0x0002, 0);
                    imports.keybd_event(0x4D, 0, 0x0002, 0);


                }
                catch (Exception ex) { NocturnalC.log(ex); }
                Thread.Sleep(100);


                imports.SetForegroundWindow(Main2.hwnd);

            }, Settings.Download_Files.mute);


            objects.qmexpand.transform.parent.gameObject.minib("Defean (Discord)", () =>
            {
                var p = Process.GetProcessesByName("Discord").FirstOrDefault();

                try
                {
                    Thread.Sleep(100);

                    imports.SetForegroundWindow(p.MainWindowHandle);
                    Thread.Sleep(100);

                    imports.keybd_event(0xA2, 0, 0, 0);
                    imports.keybd_event(0xA0, 0, 0, 0);
                    imports.keybd_event(0x44, 0, 0, 0);

                    imports.keybd_event(0xA2, 0, 2, 0);
                    imports.keybd_event(0xA0, 0, 2, 0);
                    imports.keybd_event(0x44, 0, 2, 0);


                }
                catch (Exception ex) { NocturnalC.log(ex); }



                Thread.Sleep(100);


                imports.SetForegroundWindow(Main2.hwnd);
            }, Settings.Download_Files.defean);









            objects.qmexpand.transform.SetSiblingIndex(6);

        }


    }
}
