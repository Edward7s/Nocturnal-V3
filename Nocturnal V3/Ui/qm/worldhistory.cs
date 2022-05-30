using Nocturnal.Apis.QM;
using Nocturnal.Settings.Wrappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using VRC.SDKBase;

namespace Nocturnal.Ui.QM
{
	internal class WorldHistory
	{
		internal static GameObject worldhistorymenu = null;
		internal static void CreateUI()
		{
			worldhistorymenu = SubMenu.Create("World History", Main.mainPage);
			Main.mainPage.GetMenu().Create("World History", worldhistorymenu, Settings.DownloadFiles.worldHistory, true, 2, 2);
		}

		internal static void updatehistory(string worldname, string wolrdid)
		{

			var filewh = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Settings.JsonManager.worldhistory>>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\WorldHistory.json"));
			if (filewh.Any())
				filewh.RemoveAt(filewh.Count - 1);

			var newworldh = new Settings.JsonManager.worldhistory()
			{
				worldid = wolrdid,

				worldname = worldname,
			};

			filewh.Insert(0, newworldh);

			var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(filewh);
			File.WriteAllText((Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\WorldHistory.json"), serialized);

			var gmj = worldhistorymenu.GetMenu().GetComponentsInChildren<UnityEngine.UI.Button>(true).Where(gmj => gmj.gameObject != worldhistorymenu.GetMenu().gameObject).ToArray();
			for (int i = 0; i < gmj.Length; i++)
			{
				try
				{
					GameObject.DestroyImmediate(gmj[i].gameObject);
				}
				catch { }
			}
			var getworldsfromfile = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Settings.JsonManager.worldhistory>>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\WorldHistory.json")).ToArray();
			foreach (var world in getworldsfromfile)
			{


				Apis.QM.Button.Create(worldhistorymenu.GetMenu(), world.worldname, () =>
				{

					try
					{
						if (!Networking.GoToRoom(world.worldid))
						{
							string[] array = world.worldid.Split(':');
							new PortalInternal().Method_Private_Void_String_String_PDM_0(array[0], array[1]);
						}
					}
					catch (Exception e) { NocturnalConsole.Log(e); }

				}, true);



			}
		}
	}
}
