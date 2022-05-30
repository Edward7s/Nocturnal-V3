using Newtonsoft.Json;
using System;
using System.IO;

namespace Nocturnal.Settings
{
	internal class LoadConfig
	{
		/*  [DllImport("User32.dll", EntryPoint = "MessageBox",
			 CharSet = CharSet.Auto)]
		  internal static extern int MsgBox(
			 IntPtr hWnd, string lpText, string lpCaption, uint uType);*/

		internal static void Load()
		{
			var configTimer = System.Diagnostics.Stopwatch.StartNew();

			NocturnalConsole.Log("Checking Config", "Config Setup");

			if (File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Config.json") == string.Empty)
				ConfigVars.SaveConfig(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Config.json");

			var mainl = Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Config.json"));
			foreach (var bbc in mainl.GetType().GetProperties())
			{
				try
				{

					var bcc = bbc.GetValue(mainl);
					bcc.ToString();
					// NocturnalC.log($"{bbc.Name}:{bcc}", "Config Setup", ConsoleColor.Yellow);
				}
				catch
				{
					//   NocturnalC.log(bbc.Name + " FAILED", "Config Setup", ConsoleColor.DarkRed);
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
						catch { NocturnalConsole.Log($"BIG FAIL {bbc.Name}", "Config Setup", ConsoleColor.Red); }
					}

				}

			}
			ConfigVars.ApplyConfig($"{Directory.GetCurrentDirectory()}\\Nocturnal V3\\Config\\Config.json", mainl);
			var deserializedtexxt = JsonConvert.DeserializeObject<Settings.JsonManager.discordrpc>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc"));
			ConfigVars.discordrichpresence = deserializedtexxt.ison;

			NocturnalConsole.Log($"Config Applied in {configTimer.Elapsed.ToString("hh\\:mm\\:ss\\.ff")} ", "Config Setup", ConsoleColor.Green);

			configTimer.Stop();
		}
	}
}
