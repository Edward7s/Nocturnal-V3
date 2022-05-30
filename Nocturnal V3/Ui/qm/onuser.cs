using Nocturnal.Apis.QM;
using Nocturnal.Settings.Wrappers;
using System;
using System.IO;
using UnityEngine;

namespace Nocturnal.Ui.QM
{
	internal class OnUser
	{
		internal static void CreateUI()
		{
			var menu = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UserActions").gameObject;
			Button.Create(menu, "Whitelist Anticrash", () =>
			{
				var id = GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>().field_Private_APIUser_1.id;

				if (!File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AntiCrash.whitelist").Contains(id))
				{
					File.AppendAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AntiCrash.whitelist", $"\n{id}");
					Settings.DownloadFiles.userWhiteList = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AntiCrash.whitelist");
				}

			});

			Button.Create(menu, "Remove Whitelist Anticrash", () =>
			{
				var id = GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>().field_Private_APIUser_1.id;

				if (File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AntiCrash.whitelist").Contains(id))
				{
					var ac = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AntiCrash.whitelist");
					var splited = ac.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
					string becomingback = "";
					for (int i = 0; i < splited.Length; i++)
					{
						var trimduser = splited[i].Trim();
						if (trimduser != id)
							becomingback += $"{trimduser}\n";
					}
					File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AntiCrash.whitelist", becomingback);

					Settings.DownloadFiles.userWhiteList = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AntiCrash.whitelist");
				}

			});


			Button.Create(menu, "Target User", () => Nocturnal.Settings.Wrappers.Target.TargetUser(GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>().field_Private_APIUser_1.id));
			Button.Create(menu, "Teleport", () =>
			{

				var User = GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>().field_Private_APIUser_1.id;
				VRC.Player.prop_Player_0.transform.position = User.GetUserByID().transform.position;

			});
			Button.Create(menu, "Force Clone", () =>
			{
				var aviid = "";
				var User = GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>().field_Private_APIUser_1.id;
				try
				{
					var user = User.GetUserByID();

					if (user.field_Private_APIUser_0.id == User)
						aviid = user.prop_ApiAvatar_0.id;

					Exploits.Misc.ChangeToAvatar(aviid);
				}
				catch { }


			});
			Button.Create(menu, "Copy uid", () => System.Windows.Forms.Clipboard.SetText(GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>().field_Private_APIUser_1.id));

			Button.Create(menu, "Lewd", () =>
			{

				var id = GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>().field_Private_APIUser_1.id;
				Exploits.ForceLewd.Run(Settings.Wrappers.Extensions.GetUserByID(id));
			});
		}
	}
}
