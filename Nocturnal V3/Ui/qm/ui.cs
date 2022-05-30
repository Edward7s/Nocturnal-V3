using Nocturnal.Apis.QM;
using Nocturnal.Settings.Wrappers;
using UnityEngine;
using UnityEngine.UI;
using VRC;

namespace Nocturnal.Ui.QM
{
	internal class UI
	{
		internal static Image btnt;
		internal static UnityEngine.UI.Slider[] sliderarray;

		internal static string tochange;
		internal static void CreateUI()
		{
			var uipg = SubMenu.Create("UI", Main.mainPage);
			Main.mainPage.GetMenu().Create("UI", uipg, Settings.DownloadFiles.ui, false, 3, 0);

			Apis.Slider.Create(Settings.Wrappers.Extensions.GetMenu(uipg), value => Settings.ConfigVars.espwidth = value, Settings.ConfigVars.espwidth, () =>
			{
				var player = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0;
				for (int i = 0; i < player.Count; i++)
				{
					try
					{
						if (player[i].field_Private_APIUser_0.id == VRC.Player.prop_Player_0.field_Private_APIUser_0.id) continue;
						player[i].transform.Find("SelectRegion/ESP").gameObject.GetComponent<UnityEngine.MeshRenderer>().materials[1].SetFloat("_Width", Settings.ConfigVars.espwidth);

					}
					catch { }
				}//_falloff
			}, true, "Esp Width");

			Apis.Slider.Create(Settings.Wrappers.Extensions.GetMenu(uipg), value => Settings.ConfigVars.falloff = value, Settings.ConfigVars.falloff, () =>
			{
				var player = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0;
				for (int i = 0; i < player.Count; i++)
				{
					try
					{
						if (player[i].field_Private_APIUser_0.id == VRC.Player.prop_Player_0.field_Private_APIUser_0.id) continue;
						player[i].transform.Find("SelectRegion/ESP").gameObject.GetComponent<UnityEngine.MeshRenderer>().materials[1].SetFloat("_falloff", Settings.ConfigVars.falloff * 30);

					}
					catch { }
				}

			}, true, "Esp Falloff");

			Apis.QM.Toggle.Create("Thunder Big Ui", Settings.Wrappers.Extensions.GetMenu(uipg), () =>
			{
				GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Rain/Image").gameObject.GetComponent<Image>().material.SetFloat("postpr", 1);
				Settings.ConfigVars.thunderbigui = true;
			}, () =>
			{
				GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Rain/Image").gameObject.GetComponent<Image>().material.SetFloat("postpr", 0);
				Settings.ConfigVars.thunderbigui = false;

			}, Settings.ConfigVars.thunderbigui);

			Apis.QM.Toggle.Create("Debugger", Settings.Wrappers.Extensions.GetMenu(uipg), () =>
			{
				Settings.ConfigVars.qmdebug = true;
			}, () =>
			{
				Settings.ConfigVars.qmdebug = false;

			}, Settings.ConfigVars.qmdebug);

			Apis.QM.Toggle.Create("Qm Music", Settings.Wrappers.Extensions.GetMenu(uipg), () =>
			{
				Settings.ConfigVars.qmmusic = true;
				GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").gameObject.GetComponent<AudioSource>().enabled = true;
			}, () =>
			{
				Settings.ConfigVars.qmmusic = false;
				GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").gameObject.GetComponent<AudioSource>().enabled = false;

			}, Settings.ConfigVars.qmmusic);

			Apis.QM.Toggle.Create("Player List", Settings.Wrappers.Extensions.GetMenu(uipg), () =>
			{

				string obj = Settings.ConfigVars.rightsideplayerlist ? "Wing_Right" : "Wing_Left";
				GameObject.Find("/UserInterface").transform.Find($"Canvas_QuickMenu(Clone)/Container/Window/{obj}/Button/VRC+_Banners(Clone)").gameObject.SetActive(true);

				Settings.ConfigVars.playerlist = true;

			}, () =>
			{
				string obj = Settings.ConfigVars.rightsideplayerlist ? "Wing_Right" : "Wing_Left";

				GameObject.Find("/UserInterface").transform.Find($"Canvas_QuickMenu(Clone)/Container/Window/{obj}/Button/VRC+_Banners(Clone)").gameObject.SetActive(false);
				Settings.ConfigVars.playerlist = false;

			}, Settings.ConfigVars.playerlist);

			Apis.QM.Toggle.Create("Player List Right side", Settings.Wrappers.Extensions.GetMenu(uipg), () =>
			{
				Settings.ConfigVars.rightsideplayerlist = true;
				try
				{
					var btn = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button/VRC+_Banners(Clone)").transform;
					var path = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button").transform;
					btn.transform.parent = path;
					btn.transform.Find("Mask").transform.localPosition = new Vector3(1150, -534, 0);

				}
				catch { }

			}, () =>
			{
				Settings.ConfigVars.rightsideplayerlist = false;

				try
				{
					var btn = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/VRC+_Banners(Clone)").transform;
					var path = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button").transform;
					btn.transform.parent = path;
					btn.transform.Find("Mask").transform.localPosition = new Vector3(-967, -512, 0);
					btn.transform.localPosition = new Vector3(457, 1035, 1);
					//457 1035 1
				}
				catch { }

			}, Settings.ConfigVars.rightsideplayerlist);

			Apis.QM.Toggle.Create("Qm Info Pannel", Settings.Wrappers.Extensions.GetMenu(uipg), () =>
			{
				Settings.ConfigVars.qminfopannel = true;
				try
				{
					Ui.QMBasic.firstText.transform.parent.parent.gameObject.SetActive(true);
				}
				catch { }


			}, () =>
			{
				Settings.ConfigVars.qminfopannel = false;
				try
				{
					Ui.QMBasic.firstText.transform.parent.parent.gameObject.SetActive(false);
				}
				catch { }

			}, Settings.ConfigVars.qminfopannel);

			Apis.QM.Toggle.Create("Rain Background", Settings.Wrappers.Extensions.GetMenu(uipg), () =>
			{
				Settings.ConfigVars.rainbackground = true;
				try
				{
					GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Rain/Image").gameObject.SetActive(true);
				}
				catch { }


			}, () =>
			{
				Settings.ConfigVars.rainbackground = false;
				try
				{
					GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Rain/Image").gameObject.SetActive(false);
				}
				catch { }

			}, Settings.ConfigVars.rainbackground);

			Apis.QM.Toggle.Create("Hud Info", Settings.Wrappers.Extensions.GetMenu(uipg), () =>
			{
				Settings.ConfigVars.hudUi = true;
				Ui.QMBasic.GUIInfo.transform.parent.gameObject.SetActive(true);

			}, () =>
			{
				Settings.ConfigVars.hudUi = false;
				Ui.QMBasic.GUIInfo.transform.parent.gameObject.SetActive(false);


			}, Settings.ConfigVars.hudUi);

			Apis.QM.Toggle.Create("Screen Logger", Settings.Wrappers.Extensions.GetMenu(uipg), () =>
			{

				Settings.ConfigVars.toggleonscreenlogger = true;
				GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/ONscreennotui").gameObject.SetActive(true);

			}, () =>
			{
				Settings.ConfigVars.toggleonscreenlogger = false;
				GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/ONscreennotui").gameObject.SetActive(false);


			}, Settings.ConfigVars.toggleonscreenlogger);
			GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/ONscreennotui").gameObject.SetActive(Settings.ConfigVars.toggleonscreenlogger);



			//VRC+_Banners(Clone)

			//////////////////////////////////////////////////////////////////////////////////////////////////////////////
			var Colors = SubMenu.Create("Colors", Main.mainPage);
			Main.mainPage.GetMenu().Create("Colors", Colors, Settings.DownloadFiles.colors, false, 0, 1);

			Apis.Slider.Create(Settings.Wrappers.Extensions.GetMenu(Colors), value => Settings.ConfigVars.BigImgOpacity = value, Settings.ConfigVars.BigImgOpacity, () =>
			{
				GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Rain/Rain(Clone)").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, Settings.ConfigVars.BigImgOpacity);
			}, true, "Big Img Opacity");

			Apis.Slider.Create(Settings.Wrappers.Extensions.GetMenu(Colors), value => Settings.ConfigVars.debuggeropacity = value, Settings.ConfigVars.debuggeropacity, () =>
			{
				try
				{
					GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/N_Debbuger/SupportVRChat/SupportVRChat(Clone)").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, Settings.ConfigVars.debuggeropacity);

				}
				catch { }
			}, true, "Debbuger Opacity");


			Apis.Slider.Create(Settings.Wrappers.Extensions.GetMenu(Colors), value => Settings.ConfigVars.playelerlistopacity = value, Settings.ConfigVars.playelerlistopacity, () =>
			{
				if (GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/VRC+_Banners(Clone)/Mask/Mask(Clone)") != null)
					GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/VRC+_Banners(Clone)/Mask/Mask(Clone)").gameObject.GetComponent<Image>().color = new Color(0.7f, 0.7f, 0.7f, Settings.ConfigVars.playelerlistopacity);

				else
					GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button/VRC+_Banners(Clone)/Mask/Mask(Clone)").gameObject.GetComponent<Image>().color = new Color(0.7f, 0.7f, 0.7f, Settings.ConfigVars.playelerlistopacity);


			}, true, "Player List Opacity");

			Apis.Slider.Create(Settings.Wrappers.Extensions.GetMenu(Colors), value => Settings.ConfigVars.QMopacity = value, Settings.ConfigVars.QMopacity, () =>
			{
				Objects.qmBackground.transform.Find("_Background").gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, Settings.ConfigVars.QMopacity);
			}, true, "Qm Opacity");


			Apis.QM.Button.Create(Settings.Wrappers.Extensions.GetMenu(Colors), "Big Image", () =>
			{
				Apis.InputPopup.Run("Big Image", value => Settings.ConfigVars.BiguiImg = value, () =>
				{
					MelonLoader.MelonCoroutines.Start(Apis.ChangeImage.LoadIMGTSprite(
						GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Rain/Rain(Clone)").gameObject.GetComponent<Image>(), Settings.ConfigVars.BiguiImg
					));
				});
			}, false, null);
			Apis.QM.Button.Create(Settings.Wrappers.Extensions.GetMenu(Colors), "Debbuger Image", () =>
			{
				try
				{
					Apis.InputPopup.Run("Debbuger Image", value => Settings.ConfigVars.QmDebbugerImg = value, () =>
					{
						MelonLoader.MelonCoroutines.Start(Apis.ChangeImage.LoadIMGTSprite(
							GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/N_Debbuger/SupportVRChat/SupportVRChat(Clone)").gameObject.GetComponent<Image>(), Settings.ConfigVars.QmDebbugerImg
							));
					});
				}
				catch { }


			}, false, null);

			Apis.QM.Button.Create(Settings.Wrappers.Extensions.GetMenu(Colors), "Qm Image", () =>
			{
				Apis.InputPopup.Run("Qm Image", value => Settings.ConfigVars.QmImg = value, () =>
				{
					MelonLoader.MelonCoroutines.Start(Apis.ChangeImage.LoadIMGTSprite(
						Objects.qmBackground.transform.Find("_Background").gameObject.GetComponent<Image>(), Settings.ConfigVars.QmImg
					));
				});

			}, false, null);

			Apis.QM.Button.Create(Settings.Wrappers.Extensions.GetMenu(Colors), "Playerlist Image", () =>
			{
				Apis.InputPopup.Run("Player List Image", value => Settings.ConfigVars.PlayerListImg = value, () =>
				{

					if (GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/VRC+_Banners(Clone)/Mask/Mask(Clone)") != null)
						MelonLoader.MelonCoroutines.Start(Apis.ChangeImage.LoadIMGTSprite(
							GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/VRC+_Banners(Clone)/Mask/Mask(Clone)").gameObject.GetComponent<Image>(), Settings.ConfigVars.PlayerListImg
							));
					else
						MelonLoader.MelonCoroutines.Start(Apis.ChangeImage.LoadIMGTSprite(
						GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button/VRC+_Banners(Clone)/Mask/Mask(Clone)").gameObject.GetComponent<Image>(), Settings.ConfigVars.PlayerListImg
					));
				});

			}, false, null);



			float r = 0;
			float g = 0;
			float b = 0;
			float a = 0;

			sliderarray = new UnityEngine.UI.Slider[4];

			sliderarray[0] = Apis.Slider.Create(Settings.Wrappers.Extensions.GetMenu(Colors), value => r = value, 0, () =>
			{
				if (tochange == null)
					return;
				Settings.Wrappers.Extensions.SetConfigeFieldValue(tochange, new float[] { r, g, b, a });
				btnt.color = new Color(r, g, b, a);
			}, true, "Red").GetComponent<UnityEngine.UI.Slider>();

			sliderarray[1] = Apis.Slider.Create(Settings.Wrappers.Extensions.GetMenu(Colors), value => g = value, 0, () =>
			{
				if (tochange == null)
					return;
				Settings.Wrappers.Extensions.SetConfigeFieldValue(tochange, new float[] { r, g, b, a });
				btnt.color = new Color(r, g, b, a);
			}, true, "Green").GetComponent<UnityEngine.UI.Slider>();

			sliderarray[2] = Apis.Slider.Create(Settings.Wrappers.Extensions.GetMenu(Colors), value => b = value, 0, () =>
			{
				if (tochange == null)
					return;
				Settings.Wrappers.Extensions.SetConfigeFieldValue(tochange, new float[] { r, g, b, a });
				btnt.color = new Color(r, g, b, a);
			}, true, "Blue").GetComponent<UnityEngine.UI.Slider>();
			sliderarray[3] = Apis.Slider.Create(Settings.Wrappers.Extensions.GetMenu(Colors), value => a = value, 0, () =>
			{
				if (tochange == null)
					return;
				Settings.Wrappers.Extensions.SetConfigeFieldValue(tochange, new float[] { r, g, b, a });
				btnt.color = new Color(r, g, b, a);
			}, true, "Alpha").GetComponent<UnityEngine.UI.Slider>();
			var bc = Apis.QM.Button.Create(Settings.Wrappers.Extensions.GetMenu(Colors), "Color View(Refresh)", (System.Action)(() =>
			{
				Ui.UIColors.HudColors();
				Ui.UIColors.ApplyButton();
				Ui.UIColors.ApplyText();

				var player = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0;
				for (int i = 0; i < player.Count; i++)
				{
					try
					{
						if (player[i].field_Private_APIUser_0.id == VRC.Player.prop_Player_0.field_Private_APIUser_0.id) continue;

						string empt = "";
						Color outlinecolor = Color.white;
						Settings.Wrappers.Ranks.GetTrustRank(player[i].field_Private_APIUser_0, ref empt, ref outlinecolor);

						if (Settings.Wrappers.Extensions.IsFriend(player[i]))
							outlinecolor = new Color(Settings.ConfigVars.friend[0], Settings.ConfigVars.friend[1], Settings.ConfigVars.friend[2], Settings.ConfigVars.friend[3]);
						player[i].transform.Find("SelectRegion/ESP").gameObject.GetComponent<UnityEngine.MeshRenderer>().materials[1].SetColor("_Color", outlinecolor);



					}
					catch { }
				}//_falloff







			}));
			bc.transform.Find("Icon").gameObject.SetActive(false);
			Component.DestroyImmediate(bc.gameObject.transform.Find("Background").GetComponent<Image>());
			btnt = bc.gameObject.transform.Find("Background").gameObject.AddComponent<Image>();
			btnt.sprite = null;

			Apis.QM.Button.Create(Settings.Wrappers.Extensions.GetMenu(Colors), "Client Chat Image", () =>
			{
				Apis.InputPopup.Run("Qm Image", value => Settings.ConfigVars.chatimage = value, () =>
				{
					MelonLoader.MelonCoroutines.Start(Apis.ChangeImage.LoadIMGTSprite(
						GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_DevTools/_Submenu_Client Chat/Masked/Scrollrect(Clone)/Viewport/VerticalLayoutGroup/_Button_/Background/Background(Clone)").gameObject.GetComponent<Image>(), Settings.ConfigVars.chatimage
						));
				});

			}, false, null);


			Apis.QM.Button.Create(Nocturnal.Settings.Wrappers.Extensions.GetMenu(Colors), "Friends", () =>
			{
				btnt.color = new Color(Settings.ConfigVars.friend[0], Settings.ConfigVars.friend[1], Settings.ConfigVars.friend[2], Settings.ConfigVars.trusted[3]);
				tochange = nameof(Settings.ConfigVars.friend);
				csliderv(Settings.ConfigVars.friend);

			}, true);

			Apis.QM.Button.Create(Nocturnal.Settings.Wrappers.Extensions.GetMenu(Colors), "Visitor", () =>
			{
				btnt.color = new Color(Settings.ConfigVars.visitor[0], Settings.ConfigVars.visitor[1], Settings.ConfigVars.visitor[2], Settings.ConfigVars.trusted[3]);
				tochange = nameof(Settings.ConfigVars.visitor);
				csliderv(Settings.ConfigVars.visitor);

			}, true);

			Apis.QM.Button.Create(Nocturnal.Settings.Wrappers.Extensions.GetMenu(Colors), "New User", () =>
			{
				btnt.color = new Color(Settings.ConfigVars.newuser[0], Settings.ConfigVars.newuser[1], Settings.ConfigVars.newuser[2], Settings.ConfigVars.trusted[3]);
				tochange = nameof(Settings.ConfigVars.newuser);
				csliderv(Settings.ConfigVars.newuser);

			}, true);

			Apis.QM.Button.Create(Nocturnal.Settings.Wrappers.Extensions.GetMenu(Colors), "User", () =>
			{
				btnt.color = new Color(Settings.ConfigVars.user[0], Settings.ConfigVars.user[1], Settings.ConfigVars.user[2], Settings.ConfigVars.trusted[3]);
				tochange = nameof(Settings.ConfigVars.user);
				csliderv(Settings.ConfigVars.user);

			}, true);

			Apis.QM.Button.Create(Nocturnal.Settings.Wrappers.Extensions.GetMenu(Colors), "Known User", () =>
			{
				btnt.color = new Color(Settings.ConfigVars.known[0], Settings.ConfigVars.known[1], Settings.ConfigVars.known[2], Settings.ConfigVars.trusted[3]);
				tochange = nameof(Settings.ConfigVars.known);
				csliderv(Settings.ConfigVars.known);

			}, true);

			Apis.QM.Button.Create(Nocturnal.Settings.Wrappers.Extensions.GetMenu(Colors), "Trusted", () =>
			{
				btnt.color = new Color(Settings.ConfigVars.trusted[0], Settings.ConfigVars.trusted[1], Settings.ConfigVars.trusted[2], Settings.ConfigVars.trusted[3]);
				tochange = nameof(Settings.ConfigVars.trusted);
				csliderv(Settings.ConfigVars.trusted);

			}, true);


			Apis.QM.Button.Create(Nocturnal.Settings.Wrappers.Extensions.GetMenu(Colors), "Super Powers", () =>
			{
				btnt.color = new Color(Settings.ConfigVars.superpowers[0], Settings.ConfigVars.superpowers[1], Settings.ConfigVars.superpowers[2], Settings.ConfigVars.superpowers[3]);
				tochange = nameof(Settings.ConfigVars.superpowers);
				csliderv(Settings.ConfigVars.superpowers);

			}, true);

			Apis.QM.Button.Create(Nocturnal.Settings.Wrappers.Extensions.GetMenu(Colors), "Moderator", () =>
			{
				btnt.color = new Color(Settings.ConfigVars.Moderator[0], Settings.ConfigVars.Moderator[1], Settings.ConfigVars.Moderator[2], Settings.ConfigVars.Moderator[3]);
				tochange = nameof(Settings.ConfigVars.Moderator);
				csliderv(Settings.ConfigVars.Moderator);

			}, true);

			Apis.QM.Button.Create(Nocturnal.Settings.Wrappers.Extensions.GetMenu(Colors), "Hud", () =>
			{
				btnt.color = new Color(Settings.ConfigVars.HuDColor[0], Settings.ConfigVars.HuDColor[1], Settings.ConfigVars.HuDColor[2], Settings.ConfigVars.HuDColor[3]);
				tochange = nameof(Settings.ConfigVars.HuDColor);
				csliderv(Settings.ConfigVars.HuDColor);

			}, true);
			Apis.QM.Button.Create(Nocturnal.Settings.Wrappers.Extensions.GetMenu(Colors), "Buttons", () =>
			{
				btnt.color = new Color(Settings.ConfigVars.ButtonColor[0], Settings.ConfigVars.ButtonColor[1], Settings.ConfigVars.ButtonColor[2], Settings.ConfigVars.ButtonColor[3]);
				tochange = nameof(Settings.ConfigVars.ButtonColor);
				csliderv(Settings.ConfigVars.ButtonColor);

			}, true);
			Apis.QM.Button.Create(Nocturnal.Settings.Wrappers.Extensions.GetMenu(Colors), "Text", () =>
			{
				btnt.color = new Color(Settings.ConfigVars.textcolor[0], Settings.ConfigVars.textcolor[1], Settings.ConfigVars.textcolor[2], Settings.ConfigVars.textcolor[3]);
				tochange = nameof(Settings.ConfigVars.textcolor);
				csliderv(Settings.ConfigVars.textcolor);

			}, true);
			//////////////////////////////////////////////////////////////////////////////////////////////////////////////

		}
		private static void csliderv(float[] flarray)
		{
			sliderarray[0].value = flarray[0];
			sliderarray[1].value = flarray[1];
			sliderarray[2].value = flarray[2];
			sliderarray[3].value = flarray[3];


		}

	}
}
