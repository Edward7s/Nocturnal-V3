using Newtonsoft.Json;
using Nocturnal.Apis.QM;
using Nocturnal.Settings.Wrappers;
using System;
using System.IO;
namespace Nocturnal.Ui.QM
{
	internal class Tags
	{

		internal static void CreateUI()
		{
			var tags = SubMenu.Create("Tags", Main.mainPage);
			Main.mainPage.GetMenu().Create("Tags", tags, Settings.DownloadFiles.tag, true, 2, 3);
			var tag = "";
			Apis.QM.Button.Create(tags.GetMenu(), "Add new tag", () =>
			{

				if (!File.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")) { NocturnalConsole.Log("Cloud Not Find The Key File Please try to enter your key again", "Error", ConsoleColor.Red); return; }

				Apis.InputPopup.Run("Add New Tag", value => tag = value, () =>
				{
					if (tag.Length > 300) { NocturnalConsole.Log("U can not enter a tag bigger then 300c", "Error", ConsoleColor.Red); return; }
					if (tag.Contains("\n")) { NocturnalConsole.Log("U can not use multiple lines", "Error", ConsoleColor.Red); return; }
					if (tag.Contains("<size=")) { NocturnalConsole.Log("U can not change the text size", "Error", ConsoleColor.Red); return; }

					var sendtag = new Settings.JsonManager.custommsg2()
					{
						code = "5",
						msg = JsonConvert.DeserializeObject<Settings.JsonManager.custommsg2>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")).msg,
						msg2 = tag,
					};
					Server.Setup.sendmessage(JsonConvert.SerializeObject(sendtag));
				});
			});

			Apis.QM.Button.Create(tags.GetMenu(), "Remove Tags", () =>
			{
				var RemoveTags = new Settings.JsonManager.custommsg()
				{
					code = "6",
					msg = JsonConvert.DeserializeObject<Settings.JsonManager.custommsg2>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")).msg,
				};
				Server.Setup.sendmessage(JsonConvert.SerializeObject(RemoveTags));
			});
		}
	}
}
