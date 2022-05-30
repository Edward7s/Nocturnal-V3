using Newtonsoft.Json;
using Nocturnal.Apis.QM;
using Nocturnal.Settings;
using Nocturnal.Settings.Wrappers;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using VRC;
using VRC.SDKBase;

namespace Nocturnal.Ui.QM
{
	internal class Main
	{
		internal static UnityEngine.GameObject mainPage = null;
		internal static TMPro.TextMeshProUGUI jumpImpulse = null;
		internal static bool stopev7 = false;

		[DllImport("user32.dll")] //Set the active window
		public static extern IntPtr SetActiveWindow(IntPtr hWnd);

		internal static void CreateMenu()
		{

			mainPage = SubMenu.Create("Nocturnal", null, true);
			var Main = SubMenu.Create("Main", mainPage);
			var pg = Page.Create("Nocturnal", mainPage, Settings.DownloadFiles.logo);
			//  MelonLoader.MelonCoroutines.Start(Apis.Change_Image.LoadIMGTSprite(pg.transform.Find("Icon").gameObject.GetComponent<UnityEngine.UI.Image>(),""));
			AntiCrashUI.CreateUI();
			TogglesUI.CreateUI();
			UI.CreateUI();
			TargetUI.CreateUI();
			Pickups.CreateUI();
			World.CreateUI();
			OnUser.CreateUI();
			WorldHistory.CreateUI();
			Tags.CreateUI();
			Chat.CreateUI();
			Discord.CreateUI();
			Mic.CreateUI();
			ItemManager.CreateUI();
			Button.Create(Settings.Wrappers.Extensions.GetMenu(mainPage), "Close", () => Process.GetCurrentProcess().Kill(), true, null, 3, 6);
			Button.Create(Settings.Wrappers.Extensions.GetMenu(mainPage), "Restart", () =>
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
			Button.Create(Settings.Wrappers.Extensions.GetMenu(mainPage), "Change avi", () =>
			{
				try
				{
					string aviid = "";
					Apis.InputPopup.Run("Avatar id", value => aviid = value, () =>
					{
						Exploits.Misc.ChangeToAvatar(aviid);
					});


				}

				catch
				{
					NocturnalConsole.Log("Cloud not change into that avatar");
				}


			}, true, null, 2, 6);
			Button.Create(Settings.Wrappers.Extensions.GetMenu(mainPage), "Join By Id", () =>
			{
				string roomid = "";
				Apis.InputPopup.Run("Room Instance Id", value => roomid = value, () =>
				{
					if (!Networking.GoToRoom(roomid))
					{
						string[] array = roomid.Split(':');
						new PortalInternal().Method_Private_Void_String_String_PDM_0(array[0], array[1]);
					}
				});

			}, true, null, 2, 7);
			Button.Create(Settings.Wrappers.Extensions.GetMenu(mainPage), "Delete Portals", () => Exploits.Misc.DeletePortals(), true, null, 1, 6);

			Button.Create(Settings.Wrappers.Extensions.GetMenu(mainPage), "Set Pedistals", () =>
			{
				Apis.InputPopup.Run("Avatar ID", value =>
				{
					Exploits.Misc.SetPedestals(value);
				}, () => { });
			}, true, null, 0, 8);
			Button.Create(Settings.Wrappers.Extensions.GetMenu(mainPage), "Net Del Portals", () => Exploits.Misc.NetworkedDeletePortals(), true, null, 1, 8);
			Button.Create(Settings.Wrappers.Extensions.GetMenu(mainPage), "Max Portals", () => Exploits.Misc.NetworkedMaxPortals(), true, null, 2, 8);
			jumpImpulse = Button.Create(Settings.Wrappers.Extensions.GetMenu(mainPage), "Jump Imp", () =>
			{
				try
				{
					Apis.InputPopup.Run("Jump Impulse", value => Settings.ConfigVars.jumpimpulse = float.Parse(value), () => { });
					Networking.LocalPlayer.SetJumpImpulse(Settings.ConfigVars.jumpimpulse);
					jumpImpulse.text = $"[{Networking.LocalPlayer.GetJumpImpulse()}] Jump imp";
				}
				catch { }

			}, true, null, 1, 7).gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>();
			Button.Create(Settings.Wrappers.Extensions.GetMenu(mainPage), "Save Config", () =>
			{
				Settings.ConfigVars.SaveConfig($"{Directory.GetCurrentDirectory()}\\Nocturnal V3\\Config\\Config.json"); NocturnalConsole.Log("Saved Config", "Settings", ConsoleColor.Green);
			}, false, Settings.DownloadFiles.saveConfig, 1, 0);

			Button.Create(Settings.Wrappers.Extensions.GetMenu(mainPage), "Enter Key", () =>
			{
				Imports.SetForegroundWindow(Imports.GetConsoleWindow());

				NocturnalConsole.Log("Enter Your Key", "Verification", ConsoleColor.Green);
				string getkey = Console.ReadLine();
				NocturnalConsole.Log("Enter A Username u want", "Verification", ConsoleColor.Red);
				string getusername = Console.ReadLine();

				var sendinfo = new JsonManager.custommsg2()
				{
					code = "3",

					msg = getkey.Trim(),

					msg2 = getusername.Trim(),
				};
				Server.Setup.sendmessage(Newtonsoft.Json.JsonConvert.SerializeObject(sendinfo));

				File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp", Newtonsoft.Json.JsonConvert.SerializeObject(sendinfo));

				var newmsg = new Settings.JsonManager.custommsg2()
				{
					code = "4",

					msg = JsonConvert.DeserializeObject<Settings.JsonManager.custommsg2>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")).msg.Trim(),

					msg2 = JsonConvert.DeserializeObject<Settings.JsonManager.custommsg2>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")).msg2.Trim(),

				};

				Server.Setup.sendmessage(JsonConvert.SerializeObject(newmsg));

			}, false, Settings.DownloadFiles.enterKey, 2, 0);

			Toggle.Create("Fly", Settings.Wrappers.Extensions.GetMenu(mainPage), () =>
			{
				Exploits.Fly.flyToggle = true;
				Settings.Wrappers.Extensions.ToggleController(!Exploits.Fly.flyToggle);

			}, () =>
			{
				Exploits.Fly.flyToggle = false;
				Settings.Wrappers.Extensions.ToggleController(!Exploits.Fly.flyToggle);


			}, Exploits.Fly.flyToggle, true, 0, 6);
			Toggle.Create("Esp", Settings.Wrappers.Extensions.GetMenu(mainPage), () =>
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
			mainPage.GetMenu().Create("Main", Main, Settings.DownloadFiles.main, false, 0, 0);







			Apis.Slider.Create(Settings.Wrappers.Extensions.GetMenu(Main), value => Settings.ConfigVars.Flyspeed = value, Settings.ConfigVars.Flyspeed, () =>
			{
			}, true, "Fly Speed");


			Apis.QM.Toggle.Create("Mirror", Settings.Wrappers.Extensions.GetMenu(Main), () => Exploits.Mirror.togglemirror(true), () => Exploits.Mirror.togglemirror(false));

			Apis.QM.Toggle.Create("Optimized Mirror", Settings.Wrappers.Extensions.GetMenu(Main), () => Exploits.Mirror.togglemirror(true, true), () => Exploits.Mirror.togglemirror(false));

			Apis.QM.Toggle.Create("Ghost Mode", Settings.Wrappers.Extensions.GetMenu(Main), () => stopev7 = true, () => stopev7 = false, Settings.Hooks.fakelag);

			Apis.QM.Toggle.Create("Fake Lag", Settings.Wrappers.Extensions.GetMenu(Main), () => Settings.Hooks.fakelag = true, () => Settings.Hooks.fakelag = false, stopev7);



			Objects.qmExpand.transform.parent.gameObject.Create("Copy instance id to clipboard", () =>
				{
					var worldid = RoomManager.prop_String_0;
					NocturnalConsole.Log(worldid);
					System.Windows.Forms.Clipboard.SetText(worldid);
				}, Settings.DownloadFiles.clipboard);


			Objects.qmExpand.transform.parent.gameObject.Create("Previous Track (Spotify)", () =>
			{
				var p = Process.GetProcessesByName("Spotify").FirstOrDefault();

				try
				{
					Thread.Sleep(100);

					Imports.SetForegroundWindow(p.MainWindowHandle);
					Thread.Sleep(100);

					Imports.keybd_event(0x11, 0, 0, 0);
					Imports.keybd_event(0x25, 0, 0, 0);
					Imports.keybd_event(0x11, 0, 2, 0);
					Imports.keybd_event(0x25, 0, 2, 0);
				}
				catch { }

				Thread.Sleep(100);




				Imports.SetForegroundWindow(Main2.hwnd);
			}, Settings.DownloadFiles.prev);

			Objects.qmExpand.transform.parent.gameObject.Create("Play Pause (Spotify)", () =>
			{
				var p = Process.GetProcessesByName("Spotify").FirstOrDefault();

				try
				{
					Thread.Sleep(100);

					Imports.SetForegroundWindow(p.MainWindowHandle);
					Thread.Sleep(100);

					Imports.keybd_event(0x20, 0, 0, 0);
					Imports.keybd_event(0x20, 0, 2, 0);
				}
				catch { }

				Thread.Sleep(100);


				Imports.SetForegroundWindow(Main2.hwnd);
			}, Settings.DownloadFiles.stopPlay);


			Objects.qmExpand.transform.parent.gameObject.Create("Next Track (Spotify)", () =>
			{
				var p = Process.GetProcessesByName("Spotify").FirstOrDefault();

				try
				{
					Thread.Sleep(100);

					Imports.SetForegroundWindow(p.MainWindowHandle);
					Thread.Sleep(100);

					Imports.keybd_event(0x11, 0, 0, 0);
					Imports.keybd_event(0x27, 0, 0, 0);
					Imports.keybd_event(0x11, 0, 2, 0);
					Imports.keybd_event(0x27, 0, 2, 0);
				}
				catch { }
				Thread.Sleep(100);


				Imports.SetForegroundWindow(Main2.hwnd);
			}, Settings.DownloadFiles.next);


			Objects.qmExpand.transform.parent.gameObject.Create("Mute (Discord)", () =>
			{
				//  var p = Process.GetProcesses().Where(pname => pname.ProcessName.Contains("Discord")).FirstOrDefault();
				var p = Process.GetProcessesByName("Discord").FirstOrDefault();


				try
				{
					Thread.Sleep(100);

					Imports.SetForegroundWindow(p.MainWindowHandle);
					Thread.Sleep(100);

					Imports.keybd_event(0xA2, 0, 0, 0);
					Imports.keybd_event(0xA0, 0, 0, 0);
					Imports.keybd_event(0x4D, 0, 0, 0);

					Imports.keybd_event(0xA2, 0, 0x0002, 0);
					Imports.keybd_event(0xA0, 0, 0x0002, 0);
					Imports.keybd_event(0x4D, 0, 0x0002, 0);


				}
				catch (Exception ex) { NocturnalConsole.Log(ex); }
				Thread.Sleep(100);


				Imports.SetForegroundWindow(Main2.hwnd);

			}, Settings.DownloadFiles.mute);


			Objects.qmExpand.transform.parent.gameObject.Create("Defean (Discord)", () =>
			{
				var p = Process.GetProcessesByName("Discord").FirstOrDefault();

				try
				{
					Thread.Sleep(100);

					Imports.SetForegroundWindow(p.MainWindowHandle);
					Thread.Sleep(100);

					Imports.keybd_event(0xA2, 0, 0, 0);
					Imports.keybd_event(0xA0, 0, 0, 0);
					Imports.keybd_event(0x44, 0, 0, 0);

					Imports.keybd_event(0xA2, 0, 2, 0);
					Imports.keybd_event(0xA0, 0, 2, 0);
					Imports.keybd_event(0x44, 0, 2, 0);


				}
				catch (Exception ex) { NocturnalConsole.Log(ex); }



				Thread.Sleep(100);


				Imports.SetForegroundWindow(Main2.hwnd);
			}, Settings.DownloadFiles.defean);
			Objects.qmExpand.transform.SetSiblingIndex(6);
		}
	}
}
