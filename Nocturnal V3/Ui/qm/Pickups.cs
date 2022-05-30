using Nocturnal.Apis.QM;
using Nocturnal.Settings.Wrappers;
using System.Collections.Generic;
namespace Nocturnal.Ui.QM
{
	internal class Pickups
	{

		internal static void CreateUI()
		{
			var pickupsm = SubMenu.Create("Pickups", Main.mainPage);
			Main.mainPage.GetMenu().Create("Pickups", pickupsm, Settings.DownloadFiles.items, true, 1, 2);

			var rigidlist = new List<UnityEngine.Rigidbody>();


			Toggle.Create("Max Range", Settings.Wrappers.Extensions.GetMenu(pickupsm), () => Settings.ConfigVars.itemmaxrange = true, () => Settings.ConfigVars.itemmaxrange = false, Settings.ConfigVars.itemmaxrange);
			Toggle.Create("Pickuble", Settings.Wrappers.Extensions.GetMenu(pickupsm), () => Settings.ConfigVars.itempickup = true, () => Settings.ConfigVars.itempickup = false, Settings.ConfigVars.itempickup);
			Toggle.Create("Esp", Settings.Wrappers.Extensions.GetMenu(pickupsm), () => { Settings.ConfigVars.itemesp = true; try { Exploits.ItemESP.AddESPToItems(true); } catch { } }, () => { Settings.ConfigVars.itemesp = false; try { Exploits.ItemESP.AddESPToItems(false); } catch { } }, Settings.ConfigVars.itemesp);
			Toggle.Create("Allow Theft", Settings.Wrappers.Extensions.GetMenu(pickupsm), () => Settings.ConfigVars.allowitemtheft = true, () => Settings.ConfigVars.allowitemtheft = false, Settings.ConfigVars.allowitemtheft);
			Toggle.Create("Owner", Settings.Wrappers.Extensions.GetMenu(pickupsm), () => Exploits.Pickups.OwnObjects = true, () => Exploits.Pickups.OwnObjects = false, Exploits.Pickups.OwnObjects);
			Toggle.Create("Stop", Settings.Wrappers.Extensions.GetMenu(pickupsm), () => Exploits.Pickups.stopPickups = true, () => Exploits.Pickups.stopPickups = false, Exploits.Pickups.stopPickups);
			Button.Create(pickupsm.GetMenu(), "Respawn Pickups", () =>
			{
				for (int i = 0; i < Exploits.Pickups.pickupsobs.Length; i++)
				{
					VRC.SDKBase.Networking.SetOwner(VRC.Player.prop_Player_0.field_Private_VRCPlayerApi_0, Exploits.Pickups.pickupsobs[i].gameObject);
					Exploits.Pickups.pickupsobs[i].gameObject.transform.position = new UnityEngine.Vector3(9999999999999999, 0, 0);
				}
			});
		}
	}
}
