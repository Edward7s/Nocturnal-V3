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
			grid.cellSize = new Vector2(135, 100);
			grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
			grid.constraintCount = 9;
			addnewgmj.name = "N_VBTNHOLDER";
			addnewgmj.transform.parent = Objects.userInfoPannel.transform.Find("User Panel").transform;
			addnewgmj.transform.localPosition = new Vector3(49.7516f, -281.5556f, 0);
			addnewgmj.transform.localScale = Vector3.one;
			addnewgmj.transform.localEulerAngles = Vector3.zero;
			var userp = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject.GetComponent<VRC.UI.PageUserInfo>();
			BigButton.NormalButton("Target User", addnewgmj, () => Nocturnal.Settings.Wrappers.Target.TargetUser(GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject.GetComponent<VRC.UI.PageUserInfo>().field_Private_APIUser_0.id));
			BigButton.NormalButton("Teleport", addnewgmj, () =>
			{


				try
				{
					VRC.Player.prop_Player_0.transform.position = userp.field_Private_APIUser_0.id.GetUserByID().transform.position;

				}
				catch { }

			});
			BigButton.NormalButton("Force Clone", addnewgmj, () =>
			{
				var aviid = "";
				try
				{
					var user = userp.field_Private_APIUser_0.id.GetUserByID();

					if (user.field_Private_APIUser_0.id == userp.field_Private_APIUser_0.id)
						aviid = user.prop_ApiAvatar_0.id;

					Exploits.Misc.ChangeToAvatar(aviid);
				}
				catch { }


			});
			BigButton.NormalButton("Copy uid", addnewgmj, () => System.Windows.Forms.Clipboard.SetText(GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject.GetComponent<VRC.UI.PageUserInfo>().field_Private_APIUser_0.id));

			BigButton.NormalButton("Copy avi id", addnewgmj, () =>
			{
				try
				{
					userp.field_Private_APIUser_0.Fetch();
					NocturnalConsole.Log(userp.field_Private_APIUser_0.avatarId);
					System.Windows.Forms.Clipboard.SetText(userp.field_Private_APIUser_0.avatarId);

				}
				catch { }

			});

			BigButton.NormalButton("Copy avi img", addnewgmj, () =>
			{
				NocturnalConsole.Log(userp.field_Private_APIUser_0.currentAvatarImageUrl);
				System.Windows.Forms.Clipboard.SetText(userp.field_Private_APIUser_0.currentAvatarImageUrl);
			});
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

						msg2 = userp.field_Private_APIUser_0.id,

						msg = tagtosend.Trim(),

					};

					Server.Setup.sendmessage(Newtonsoft.Json.JsonConvert.SerializeObject(newtag));


				});



			});

			buttonaddtag.gameObject.SetActive(false);
			BigUIScrollbar.Run();
			Bundles.LoadRain();

			var worldinfogmj = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/WorldInfo").transform;
			var worldinfo = worldinfogmj.GetComponent<VRC.UI.PageWorldInfo>();
			var newworlgmj = new GameObject();
			var newgrid = newworlgmj.AddComponent<GridLayoutGroup>();
			// grid.cellSize = new Vector2(200, 100);
			newgrid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
			newgrid.constraintCount = 3;
			newworlgmj.name = "N_VBTNHOLDER";
			newworlgmj.transform.parent = worldinfogmj;
			newworlgmj.transform.localPosition = new Vector3(-475, 320, 0);
			newworlgmj.transform.localScale = Vector3.one;
			newworlgmj.transform.localEulerAngles = Vector3.zero;
			BigButton.NormalButton("Copy Id", newworlgmj, () =>
			{
				NocturnalConsole.Log(worldinfo.field_Public_ApiWorldInstance_0.id);
				System.Windows.Forms.Clipboard.SetText(worldinfo.field_Public_ApiWorldInstance_0.id);
			});
			BigButton.NormalButton("Creator Id", newworlgmj, () =>
			{
				NocturnalConsole.Log(worldinfo.field_Public_APIUser_0.id);
				System.Windows.Forms.Clipboard.SetText(worldinfo.field_Public_APIUser_0.id);
			});
			BigButton.NormalButton("Asset Url", newworlgmj, () =>
			{
				NocturnalConsole.Log(worldinfo.field_Private_ApiWorld_0.assetUrl);
				System.Windows.Forms.Clipboard.SetText(worldinfo.field_Private_ApiWorld_0.assetUrl);
				Application.OpenURL(worldinfo.field_Private_ApiWorld_0.assetUrl);
			});
			BigButton.NormalButton("Copy Img", newworlgmj, () =>
			{
				NocturnalConsole.Log(worldinfo.field_Private_ApiWorld_0.imageUrl);
				System.Windows.Forms.Clipboard.SetText(worldinfo.field_Private_ApiWorld_0.imageUrl);
			});

		}
	}
}
