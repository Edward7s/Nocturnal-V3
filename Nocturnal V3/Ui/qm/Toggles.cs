using Nocturnal.Apis.QM;
using Nocturnal.Settings;
using Nocturnal.Settings.Wrappers;
namespace Nocturnal.Ui.QM
{
	internal class TogglesUI
	{
		internal static void CreateUI()
		{
			var toggles = SubMenu.Create("Toggles", Main.mainPage);
			Main.mainPage.GetMenu().Create("Toggles", toggles, Settings.DownloadFiles.toggles, false, 3, 1);

			Toggle.Create("Force Jump", toggles.GetMenu(), () => ConfigVars.forcejump = true, () => ConfigVars.forcejump = false, ConfigVars.forcejump);
			Toggle.Create("Infinite Jump", toggles.GetMenu(), () => ConfigVars.infinitejump = true, () => ConfigVars.infinitejump = false, ConfigVars.infinitejump);
			Toggle.Create("Third Person", toggles.GetMenu(), () => ConfigVars.Thidperson = true, () => ConfigVars.Thidperson = false, ConfigVars.Thidperson);
			Toggle.Create("Bhop", toggles.GetMenu(), () => ConfigVars.bhop = true, () => ConfigVars.bhop = false, ConfigVars.bhop);
			Toggle.Create("Join Sound", toggles.GetMenu(), () => ConfigVars.joinsound = true, () => ConfigVars.joinsound = false, ConfigVars.joinsound);
			Toggle.Create("Join Friends Sound Only", toggles.GetMenu(), () => ConfigVars.onlyfriendjoin = true, () => ConfigVars.onlyfriendjoin = false, ConfigVars.onlyfriendjoin);
			Toggle.Create("Hide Questies", toggles.GetMenu(), () =>
			{
				ConfigVars.hidequests = true;
				var playes = Settings.Wrappers.Extensions.GetAllPlayers();
				for (int i = 0; i < playes.Length; i++)
				{
					if (playes[i].prop_APIUser_0.last_platform != "standalonewindows" && !playes[i].IsFriend())
						playes[i].gameObject.SetActive(false);
				}
			}, () =>
			{
				ConfigVars.hidequests = false;
				var playes = Settings.Wrappers.Extensions.GetAllPlayers();
				for (int i = 0; i < playes.Length; i++)
				{
					if (playes[i].prop_APIUser_0.last_platform != "standalonewindows" && !playes[i].IsFriend())
						playes[i].gameObject.SetActive(true);
				}
			}, ConfigVars.hidequests);
			Toggle.Create("Udon Block", toggles.GetMenu(), () => Settings.ConfigVars.udonblock = true, () => Settings.ConfigVars.udonblock = false, Settings.ConfigVars.udonblock);

		}
	}
}
