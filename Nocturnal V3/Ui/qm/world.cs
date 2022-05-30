using Nocturnal.Apis.QM;
using Nocturnal.Settings;
using Nocturnal.Settings.Wrappers;
namespace Nocturnal.Ui.QM
{
	internal class World
	{

		internal static void CreateUI()
		{
			var pickupsm = SubMenu.Create("World", Main.mainPage);
			Main.mainPage.GetMenu().Create("World", pickupsm, Settings.DownloadFiles.world, true, 1, 3);




			var Murderexploits = SubMenu.Create("Warrning u will probably crash", pickupsm);
			pickupsm.GetMenu().Create("Murder", Murderexploits, null);
			Apis.QM.Toggle.Create("Self Gold Weapon", Murderexploits.GetMenu(), () => ConfigVars.murdergoldweapon = true, () => ConfigVars.murdergoldweapon = false, ConfigVars.murdergoldweapon);
			Apis.QM.Toggle.Create("Everyone Gold Weapon", Murderexploits.GetMenu(), () => ConfigVars.everyonegoldgun = true, () => ConfigVars.everyonegoldgun = false, ConfigVars.everyonegoldgun);
			Apis.QM.Toggle.Create("God Mode", Murderexploits.GetMenu(), () => ConfigVars.murdergodmod = true, () => ConfigVars.murdergodmod = false, ConfigVars.murdergodmod);
			Apis.QM.Toggle.Create("Self No ShootC", Murderexploits.GetMenu(), () => ConfigVars.continuesfire = true, () => ConfigVars.continuesfire = false, ConfigVars.continuesfire);
			Apis.QM.Toggle.Create("Everyone No ShootC", Murderexploits.GetMenu(), () => ConfigVars.everyonecontinuesfire = true, () => ConfigVars.everyonecontinuesfire = false, ConfigVars.everyonecontinuesfire);

			var Amongusexploits = SubMenu.Create("Among Us", pickupsm);
			pickupsm.GetMenu().Create("Among Us", Amongusexploits, null);

			Apis.QM.Toggle.Create("God Mode", Amongusexploits.GetMenu(), () => ConfigVars.amongusgodmod = true, () => ConfigVars.amongusgodmod = false, ConfigVars.amongusgodmod);


		}

	}
}
