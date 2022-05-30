using Newtonsoft.Json;
using Nocturnal.Apis.QM;
using Nocturnal.Settings.Wrappers;
using System.IO;
namespace Nocturnal.Ui.QM
{
	internal class Discord
	{
		internal static TMPro.TextMeshProUGUI chattext = null;
		internal static void CreateUI()
		{
			var disc = SubMenu.Create("Discord", Main.mainPage);
			Main.mainPage.GetMenu().Create("Discord", disc, Settings.DownloadFiles.discord, true, 2, 4);

			Apis.QM.Toggle.Create("Discord Presence", disc.GetMenu(), () =>
			{
				Settings.DownloadFiles.runrpc.Invoke(Settings.DownloadFiles.runrpc, null);

				var str = JsonConvert.DeserializeObject<Settings.JsonManager.discordrpc>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc"));
				str.ison = true;
				File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc", JsonConvert.SerializeObject(str));
				Settings.DownloadFiles.activityManager.Invoke(Settings.DownloadFiles.activityManager, new object[] { false });
				Settings.ConfigVars.discordrichpresence = true;


			}, () =>
			{
				try
				{
					var str = JsonConvert.DeserializeObject<Settings.JsonManager.discordrpc>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc"));
					str.ison = false;
					File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc", JsonConvert.SerializeObject(str));
					Settings.DownloadFiles.activityManager.Invoke(Settings.DownloadFiles.activityManager, new object[] { true });
					Settings.ConfigVars.discordrichpresence = false;

				}
				catch { }


			}, Settings.ConfigVars.discordrichpresence);
			Settings.DownloadFiles.activityManager.Invoke(Settings.DownloadFiles.activityManager, new object[] { !Settings.ConfigVars.discordrichpresence });


			Button.Create(disc.GetMenu(), "Details", () =>
			{
				var str = JsonConvert.DeserializeObject<Settings.JsonManager.discordrpc>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc"));
				var tobstring = "";
				Apis.InputPopup.Run("Details", value => tobstring = value, () =>
				{
					str.Details = tobstring;
					File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc", JsonConvert.SerializeObject(str));
					Settings.DownloadFiles.activityManager.Invoke(Settings.DownloadFiles.activityManager, new object[] { false });

				});
			});

			Button.Create(disc.GetMenu(), "State", () =>
			{
				var str = JsonConvert.DeserializeObject<Settings.JsonManager.discordrpc>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc"));
				var tobstring = "";
				Apis.InputPopup.Run("State", value => tobstring = value, () =>
				{
					str.State = tobstring;
					File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc", JsonConvert.SerializeObject(str));
					Settings.DownloadFiles.activityManager.Invoke(Settings.DownloadFiles.activityManager, new object[] { false });

				});
			});
			Button.Create(disc.GetMenu(), "Image", () =>
			{
				var str = JsonConvert.DeserializeObject<Settings.JsonManager.discordrpc>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc"));
				var tobstring = "";
				Apis.InputPopup.Run("Image", value => tobstring = value, () =>
				{
					str.LargeImage = tobstring;
					File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc", JsonConvert.SerializeObject(str));
					Settings.DownloadFiles.activityManager.Invoke(Settings.DownloadFiles.activityManager, new object[] { false });

				});
			});


		}

	}
}
