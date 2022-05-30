using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Nocturnal.Settings
{
	internal class DownloadFiles
	{
		internal static string shaderList = null;
		internal static string userWhiteList = null;
		internal static byte[] nameplates = null;
		internal static byte[] nameplateIcon = null;
		internal static byte[] playerListMask = null;
		internal static byte[] playerListBorder = null;
		internal static byte[] quickMenuMask = null;

		internal static byte[] main = null;
		internal static byte[] saveConfig = null;
		internal static byte[] enterKey = null;
		internal static byte[] ui = null;
		internal static byte[] toggles = null;
		internal static byte[] target = null;
		internal static byte[] anticrash = null;
		internal static byte[] colors = null;
		internal static byte[] clipboard = null;
		internal static byte[] world = null;
		internal static byte[] items = null;
		internal static byte[] worldHistory = null;
		internal static byte[] mute = null;
		internal static byte[] defean = null;
		internal static byte[] next = null;
		internal static byte[] prev = null;
		internal static byte[] stopPlay = null;
		internal static byte[] loadingScreen = null;
		internal static byte[] shaderESP = null;
		internal static byte[] rain = null;
		internal static byte[] uiNotifications = null;
		internal static byte[] logo = null;
		internal static byte[] chatMask = null;
		internal static string musicPath = null;
		internal static string loadingScreenMusicPath = null;
		internal static string joinSound = null;
		internal static byte[] chat = null;
		internal static byte[] tag = null;
		internal static MethodInfo runrpc = null;
		internal static MethodInfo callback = null;
		internal static MethodInfo activityManager = null;
		internal static byte[] discord = null;
		internal static MethodInfo setworldinfo = null;
		internal static byte[] micmenu = null;

		internal static void DownloadHanler()
		{

			var sttime = Stopwatch.StartNew();
			NocturnalConsole.Log("Starting DownloadHander");
			var webclient = new System.Net.WebClient();

			if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3"))
				Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Nocturnal V3");

			if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config"))
				Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config");


			if (!File.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Config.json"))
				File.Create(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Config.json").Close();

			if (!File.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AntiCrash.whitelist"))
				File.Create(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AntiCrash.whitelist").Close();

			if (!File.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\WorldHistory.json"))
				webclient.DownloadFile("https://nocturnal-client.xyz/Resources/WorldHistory.json", Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\WorldHistory.json");

			if (!File.Exists(Directory.GetCurrentDirectory() + "\\UserLibs\\discord_game_sdk.dll"))
				webclient.DownloadFile("https://nocturnal-client.xyz/Resources/discord_game_sdk.dll", Directory.GetCurrentDirectory() + "\\UserLibs\\discord_game_sdk.dll");

			if (!File.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc"))
			{
				var setc = new JsonManager.discordrpc()
				{
					Details = "In my zone now.",
					State = "That's what they told me.",
					LargeImage = "https://i.pinimg.com/564x/79/99/fd/7999fdb988362d0982dc774a4e7d7d60.jpg",
					ison = true,
				};
				File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc", Newtonsoft.Json.JsonConvert.SerializeObject(setc));
			}

			userWhiteList = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AntiCrash.whitelist");

			if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\LoadingMusic"))
				Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\LoadingMusic");

			if (Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\LoadingMusic").Length == 0)
				webclient.DownloadFile("https://nocturnal-client.xyz/Resources/LoadingMusic.mp3", Directory.GetCurrentDirectory() + "\\Nocturnal V3\\LoadingMusic\\LoadingMusic.mp3");

			loadingScreenMusicPath = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\LoadingMusic").FirstOrDefault().ToString();

			if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\QmMusic"))
				Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\QmMusic");

			if (Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\QmMusic").Length == 0)
				webclient.DownloadFile("https://nocturnal-client.xyz/Resources/Qmmusic.mp3", Directory.GetCurrentDirectory() + "\\Nocturnal V3\\QmMusic\\Qmmusic.mp3");

			musicPath = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\QmMusic").FirstOrDefault().ToString();

			if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Joinsound"))
				Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Joinsound");

			if (Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Joinsound").Length == 0)
				webclient.DownloadFile("https://nocturnal-client.xyz/Resources/joinsound.mp3", Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Joinsound\\Joinsound.mp3");

			joinSound = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Joinsound").FirstOrDefault();



			//TODO: is this what you wanted?
			if (!File.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Joinsound.mp3"))
				nameplates = webclient.DownloadData("https://nocturnal-client.xyz/Resources/namepalte.png");

			shaderList = webclient.DownloadString("https://nocturnal-client.xyz/cl/anticrashshader.txt");

			playerListMask = webclient.DownloadData("https://nocturnal-client.xyz/Resources/maskplist.png");

			playerListBorder = webclient.DownloadData("https://nocturnal-client.xyz/Resources/playerlistborder.png");

			quickMenuMask = webclient.DownloadData("https://nocturnal-client.xyz/Resources/qmmask.png");

			nameplateIcon = webclient.DownloadData("https://nocturnal-client.xyz/Resources/iconbackground.png");

			main = webclient.DownloadData("https://nocturnal-client.xyz/Resources/icons/Base.png");

			saveConfig = webclient.DownloadData("https://nocturnal-client.xyz/Resources/icons/Save%20Config.png");

			enterKey = webclient.DownloadData("https://nocturnal-client.xyz/Resources/icons/Key.png");

			ui = webclient.DownloadData("https://nocturnal-client.xyz/Resources/icons/Ui.png");

			toggles = webclient.DownloadData("https://nocturnal-client.xyz/Resources/icons/Toggle.png");

			target = webclient.DownloadData("https://nocturnal-client.xyz/Resources/icons/target.png");

			anticrash = webclient.DownloadData("https://nocturnal-client.xyz/Resources/icons/anticrash.png");

			colors = webclient.DownloadData("https://nocturnal-client.xyz/Resources/icons/Colors.png");

			worldHistory = webclient.DownloadData("https://nocturnal-client.xyz/Resources/icons/World%20History.png");

			world = webclient.DownloadData("https://nocturnal-client.xyz/Resources/icons/World.png");

			items = webclient.DownloadData("https://nocturnal-client.xyz/Resources/icons/items.png");

			clipboard = webclient.DownloadData("https://nocturnal-client.xyz/Resources/icons/clipboard.png");

			mute = webclient.DownloadData("https://nocturnal-client.xyz/Resources/icons/Microphone.png");

			defean = webclient.DownloadData("https://nocturnal-client.xyz/Resources/icons/defean.png");

			next = webclient.DownloadData("https://nocturnal-client.xyz/Resources/icons/rightarrow.png");

			prev = webclient.DownloadData("https://nocturnal-client.xyz/Resources/icons/leftarrow.png");

			stopPlay = webclient.DownloadData("https://nocturnal-client.xyz/Resources/icons/playpause.png");

			loadingScreen = webclient.DownloadData("https://nocturnal-client.xyz/Resources/loading");
			shaderESP = webclient.DownloadData("https://nocturnal-client.xyz/Resources/outline");
			rain = webclient.DownloadData("https://nocturnal-client.xyz/Resources/rain2");
			uiNotifications = webclient.DownloadData("https://nocturnal-client.xyz/Resources/ui");
			logo = webclient.DownloadData("https://nocturnal-client.xyz/Resources/Nocturnal%20logo.png");
			chatMask = webclient.DownloadData("https://nocturnal-client.xyz/Resources/chatmask.png");
			tag = webclient.DownloadData("https://nocturnal-client.xyz/Resources/Tagas.png");
			chat = webclient.DownloadData("https://nocturnal-client.xyz/Resources/Chat.png");
			var bytes = webclient.DownloadData("https://nocturnal-client.xyz/Resources/discordrpc.dll");
			discord = webclient.DownloadData("https://nocturnal-client.xyz/Resources/Discord.png");
			micmenu = webclient.DownloadData("https://nocturnal-client.xyz/Resources/mic%20icon.png");


			try
			{
				Assembly asembly = Assembly.Load(bytes);
				Type[] types = asembly.GetTypes();
				var callclass = types.Where(clname => clname.Name == "RPCM").FirstOrDefault();
				runrpc = callclass.GetMethod("startrpc", BindingFlags.NonPublic | BindingFlags.Static);
				callback = callclass.GetMethod("runcallback", BindingFlags.NonPublic | BindingFlags.Static);
				activityManager = callclass.GetMethod("updateRPC", BindingFlags.NonPublic | BindingFlags.Static);
				setworldinfo = callclass.GetMethod("setworld", BindingFlags.NonPublic | BindingFlags.Static);
			}
			catch (Exception ex)
			{
				NocturnalConsole.Log("DISCORD RICH PRESENCE FAILED: " + ex);
			}
			var bytess = webclient.DownloadData("https://nocturnal-client.xyz/cl/Download/Nocturnal%20Circle.ico");
			Stream stream = new MemoryStream(bytess);
			Icon icon = new Icon(stream);

			try
			{
				Main2.hwnd = Settings.Imports.FindWindow(null, "VRChat");


				if (Main2.hwnd == IntPtr.Zero || Main2.hwnd == null)
				{
					Main2.hwnd = Process.GetProcessById(Main2.pid).MainWindowHandle;
				}

			}
			catch
			{
				NocturnalConsole.Log("Exception In Finding the VRC Window,Tryng PID", "ERROR");
				Main2.hwnd = Process.GetProcessById(Main2.pid).MainWindowHandle;
			}

			Settings.Imports.SendMessage(Main2.hwnd, 0x0080, 0, icon.Handle);
			Settings.Imports.SendMessage(Main2.hwnd, 0x0080, 1, icon.Handle);

			Settings.Imports.SendMessage(Imports.GetConsoleWindow(), 0x0080, 0, icon.Handle);
			Settings.Imports.SendMessage(Imports.GetConsoleWindow(), 0x0080, 1, icon.Handle);
			Settings.Imports.SetWindowText(Main2.hwnd, "Nocturanl[VRChat]");

			NocturnalConsole.Log($"Resources Downloaded In {sttime.Elapsed.ToString("hh\\:mm\\:ss\\.ff")} ", "Download Manager", ConsoleColor.Green);
			sttime.Stop();

		}
	}
}
