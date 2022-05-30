using Nocturnal.Apis.BigUI;
using Nocturnal.Settings.Wrappers;
using UnityEngine;
using UnityEngine.UI;
namespace Nocturnal.Ui
{
	internal class BigUIButton
	{
		internal static GameObject buttonaddtag;
		internal static void Run()
		{
			var addnewgmj = new GameObject();
			var grid = addnewgmj.AddComponent<GridLayoutGroup>();
			grid.cellSize = new Vector2(200, 100);
			grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
			grid.constraintCount = 6;
			addnewgmj.name = "N_VBTNHOLDER";
			addnewgmj.transform.parent = Objects.userInfoPannel.transform.Find("User Panel").transform;
			addnewgmj.transform.localPosition = new Vector3(49.7516f, -284.6267f, 0);
			addnewgmj.transform.localScale = Vector3.one;
			BigButton.NormalButton("Target User", addnewgmj, () => Nocturnal.Settings.Wrappers.Target.TargetUser(GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject.GetComponent<VRC.UI.PageUserInfo>().field_Private_APIUser_0.id));
			BigButton.NormalButton("Teleport", addnewgmj, () =>
			{

				var User = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject.GetComponent<VRC.UI.PageUserInfo>().field_Private_APIUser_0.id;
				try
				{
					VRC.Player.prop_Player_0.transform.position = User.GetUserByID().transform.position;

				}
				catch { }

			});
			BigButton.NormalButton("Force Clone", addnewgmj, () =>
			{
				var aviid = "";
				var User = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject.GetComponent<VRC.UI.PageUserInfo>().field_Private_APIUser_0.id;
				try
				{
					var user = User.GetUserByID();

					if (user.field_Private_APIUser_0.id == User)
						aviid = user.prop_ApiAvatar_0.id;

					Exploits.Misc.ChangeToAvatar(aviid);
				}
				catch { }


			});
			BigButton.NormalButton("Copy uid", addnewgmj, () => System.Windows.Forms.Clipboard.SetText(GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject.GetComponent<VRC.UI.PageUserInfo>().field_Private_APIUser_0.id));

			buttonaddtag = BigButton.NormalButton("Set Tag", addnewgmj, () =>
			{
				string tagtosend = "";



				Apis.InputPopup.Run("", value => tagtosend = value, () =>
				{

					if (tagtosend.Trim().Length > 60)
					{
						NocturnalConsole.Log("Message can not be bigger then 60C");
						return;
					}


					var newtag = new Settings.JsonManager.custommsg2()
					{

						code = "9",

						msg2 = buttonaddtag.transform.parent.parent.parent.GetComponent<VRC.UI.PageUserInfo>().field_Private_APIUser_0.id,

						msg = tagtosend.Trim(),

					};

					Server.Setup.sendmessage(Newtonsoft.Json.JsonConvert.SerializeObject(newtag));


				});



			});

			buttonaddtag.gameObject.SetActive(false);
			BigUIScrollbar.Run();
			Bundles.LoadRain();

		}
	}
}
