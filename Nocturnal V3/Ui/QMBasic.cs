using Nocturnal.Apis;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace Nocturnal.Ui
{
	class QMBasic
	{
		//TODO: Unity is NOT thread safe this can cause crashes
		internal static Thread runs = new Thread(Setup);

		internal static TMPro.TextMeshProUGUI debugText = null;
		internal static TMPro.TextMeshProUGUI playerListText = null;
		internal static AudioSource audioSourceNotification = null;
		internal static TMPro.TextMeshProUGUI firstText = null;
		internal static TMPro.TextMeshProUGUI secondText = null;
		internal static TMPro.TextMeshProUGUI ThirdText = null;
		internal static TMPro.TextMeshProUGUI GUIInfo = null;

		internal static void Setup()
		{
			var styletimer = System.Diagnostics.Stopwatch.StartNew();

			var DashBoardV = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup").transform;

			if (Settings.ConfigVars.qmdebug)
			{
				DashBoardV.Find("Carousel_Banners").gameObject.SetActive(false);
				DashBoardV.Find("Header_QuickActions").gameObject.SetActive(false);
				DashBoardV.Find("Header_QuickLinks").gameObject.SetActive(false);

				var childs = DashBoardV.gameObject.GetComponentsInChildren<UnityEngine.UI.Button>(true);
				for (int i = 0; i < childs.Length; i++)
				{
					//  if (childs[i].transform.Find("Background") == null)
					try
					{
						childs[i].transform.Find("Background").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, -90);
						var ico = childs[i].transform.Find("Icon").gameObject;
						ico.transform.localScale = new Vector3(0.5f, 0.5f, 1);
						ico.transform.localPosition = new Vector3(-75.5186f, 18.8227f, 0);
						var text = childs[i].transform.Find("Text_H4").gameObject;
						text.transform.localScale = new Vector3(0.9f, 0.9f, 1);
						text.transform.localPosition = new Vector3(18.58f, -21.0801f, 0);
						childs[i].transform.Find("Badge_MMJump").transform.localPosition = new Vector3(88.8256f, 34.0999f, 0f);


						if (childs[i].name == "Button_SelectUser")
						{

							childs[i].transform.Find("Text_H4").gameObject.transform.localPosition = new Vector3(18.58f, 70, 0);
							childs[i].transform.Find("Icon").transform.localPosition = new Vector3(-75.5186f, -70, 0);

							//Icon
						}
						if (childs[i].name == " Button_InteractionPauseWithState")
						{
							childs[i].transform.Find("Text_H4").gameObject.transform.localPosition = new Vector3(18.58f, 70, 0);
							childs[i].transform.Find("Icon").transform.localPosition = new Vector3(-75.5186f, -70, 0);

						}

					}
					catch { }



				}

				var vrcpbanner = DashBoardV.transform.Find("VRC+_Banners").gameObject;
				var debbuger = GameObject.Instantiate(vrcpbanner, vrcpbanner.transform.parent).gameObject;
				Component.DestroyImmediate(debbuger.GetComponent<VRC.UI.Core.Styles.StyleElement>());
				GameObject.DestroyImmediate(debbuger.transform.Find("ThankYouMM").gameObject);
				debbuger.name = "N_Debbuger";
				var mask = debbuger.transform.Find("SupportVRChat").gameObject;
				Component.DestroyImmediate(mask.GetComponent<UnityEngine.UI.Button>());
				Component.DestroyImmediate(mask.GetComponent<UnityEngine.UI.RawImage>());
				Component.DestroyImmediate(mask.GetComponent<VRC.DataModel.Core.BindingComponent>());
				debbuger.transform.SetSiblingIndex(0);
				debbuger.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(950, 570);
				debbuger.gameObject.SetActive(true);
				mask.AddComponent<UnityEngine.UI.Image>();
				mask.AddComponent<UnityEngine.UI.Mask>();
				var img2 = GameObject.Instantiate(mask, mask.transform).gameObject;
				var maskimg = mask.gameObject.GetComponent<Image>();
				var img2i = img2.gameObject.GetComponent<Image>();
				MelonLoader.MelonCoroutines.Start(Apis.ChangeImage.LoadIMGTSprite(maskimg, "https://nocturnal-client.xyz/Resources/mask%20qm.png"));
				MelonLoader.MelonCoroutines.Start(Apis.ChangeImage.LoadIMGTSprite(img2i, Settings.ConfigVars.QmDebbugerImg));
				img2i.color = new Color(1, 1, 1, Settings.ConfigVars.debuggeropacity);
				img2i.color = Color.white;
				img2.gameObject.transform.localPosition = Vector3.zero;
				Component.DestroyImmediate(img2.GetComponent<Mask>());
				maskimg.GetComponent<Image>().color = new Color(0, 0, 0, 0.1f);
				var img3 = GameObject.Instantiate(img2, img2.transform).gameObject;
				var img3i = img3.gameObject.GetComponent<Image>();

				img3.transform.localPosition = Vector3.zero;
				MelonLoader.MelonCoroutines.Start(Apis.ChangeImage.LoadIMGTSprite(img3i, "https://nocturnal-client.xyz/Resources/border.png"));
				mask.transform.localPosition = new Vector3(0, 295, 0);
				mask.transform.localScale = new Vector3(1.05f, 2.61f, 1f);
				var debbugertxt = new GameObject();
				debugText = debbugertxt.AddComponent<TMPro.TextMeshProUGUI>();
				debugText.text = "";
				debugText.enableWordWrapping = false;
				debugText.fontSize = 8;
				debugText.maxVisibleLines = 18;
				debbugertxt.gameObject.transform.parent = img3.transform;
				debbugertxt.transform.localPosition = new Vector3(-150f, -53.86f, 1);
				debbugertxt.transform.localScale = new Vector3(2.65f, 1, 1);
				Style.Debugger.DebugMsg($"<color=#2700c2>Nocturnal V3</color> Made by <color=#ff1934>Edward7");

			}

			GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 80);
			Objects.userInfoPannel.transform.Find("User Panel").transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
			var userblackbackground = Objects.userInfoPannel.transform.Find("User Panel/Panel").gameObject;
			var ldimg = Objects.userInfoPannel.transform.Find("User Panel/PanelHeaderBackground").gameObject.GetComponent<Image>();
			ldimg.color = Color.white;
			MelonLoader.MelonCoroutines.Start(Apis.ChangeImage.LoadIMGTSprite(ldimg, "https://nocturnal-client.xyz/cl/Download/Media/offwhite.png"));
			var bgimg = userblackbackground.gameObject.GetComponent<Image>();
			MelonLoader.MelonCoroutines.Start(Apis.ChangeImage.LoadIMGTSprite(bgimg, "https://nocturnal-client.xyz/Resources/Normalborder.png"));
			bgimg.color = Color.black;

			userblackbackground.transform.localScale = new Vector3(1.05f, 0.6f, 1);
			userblackbackground.transform.localPosition = new Vector3(400f, -512.4001f, 0);
			var bio = Objects.userInfoPannel.transform.Find("User Panel/UserBio").transform;
			bio.localScale = new Vector3(0.95f, 0.95f, 1);
			bio.transform.localPosition = new Vector3(365.1563f, -511.416f, 0);
			var userblackbg2 = GameObject.Instantiate(userblackbackground, userblackbackground.transform.parent).transform;


			userblackbg2.transform.localScale = new Vector3(1.05f, 0.34f, 1);
			userblackbg2.transform.localPosition = new Vector3(400f, -135.7954f, 0);
			userblackbg2.SetSiblingIndex(0);

			MelonLoader.MelonCoroutines.Start(Apis.ChangeImage.LoadIMGTSprite(userblackbg2.gameObject.GetComponent<Image>(), "https://nocturnal-client.xyz/Resources/Normalborder.png"));


			//Load music
			var qm = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").gameObject.AddComponent<AudioSource>();
			qm.loop = true;
			qm.playOnAwake = true;
			MelonLoader.MelonCoroutines.Start(Settings.Wrappers.Extensions.LoadAudio(qm, Settings.DownloadFiles.musicPath));
			qm.volume = Settings.ConfigVars.clientvolume;
			var toinst = DashBoardV.transform.Find("VRC+_Banners").gameObject;
			Transform path = Settings.ConfigVars.rightsideplayerlist ? GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button").transform : GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button").transform;
			Vector3 poz = Settings.ConfigVars.rightsideplayerlist ? new Vector3(46, -534, 0) : new Vector3(-967, -512, 0);
			qm.GetComponent<AudioSource>().enabled = Settings.ConfigVars.qmmusic;

			var playerlist = GameObject.Instantiate(toinst, path);
			GameObject.DestroyImmediate(playerlist.transform.Find("ThankYouMM").gameObject);
			playerlist.gameObject.SetActive(true);
			Component.DestroyImmediate(playerlist.GetComponent<VRC.UI.Core.Styles.StyleElement>());
			var mask2 = playerlist.transform.Find("SupportVRChat");
			playerlist.transform.localPosition = new Vector3(457, 1035, 1);
			mask2.name = "Mask";
			mask2.transform.localPosition = poz;
			mask2.transform.localScale = new Vector3(0.9f, 4.5f, 1);
			Component.DestroyImmediate(mask2.GetComponent<Button>());
			Component.DestroyImmediate(mask2.GetComponent<UnityEngine.UI.RawImage>());
			mask2.gameObject.AddComponent<Image>();

			var image = GameObject.Instantiate(mask2, mask2.transform);
			image.localScale = Vector3.one;
			image.localPosition = Vector3.zero;
			var border = GameObject.Instantiate(image, image.transform);
			MelonLoader.MelonCoroutines.Start(Apis.ChangeImage.LoadIMGTSprite(image.gameObject.GetComponent<Image>(), Settings.ConfigVars.PlayerListImg));
			mask2.gameObject.AddComponent<UnityEngine.UI.Mask>().showMaskGraphic = false;
			mask2.gameObject.Loadfrombytes(Settings.DownloadFiles.playerListMask);
			border.gameObject.Loadfrombytes(Settings.DownloadFiles.playerListBorder);
			border.transform.localPosition = Vector3.zero;
			image.GetComponent<UnityEngine.UI.Image>().color = new Color(0.7f, 0.7f, 0.7f, Settings.ConfigVars.playelerlistopacity);
			border.GetComponent<Image>().color = new Color(0.6f, 0.6f, 0.6f, 0.95f);
			var playlerlistext = GameObject.Instantiate(border.gameObject, border.transform.parent.transform);
			Component.DestroyImmediate(playlerlistext.GetComponent<Image>());
			playerListText = playlerlistext.AddComponent<TMPro.TextMeshProUGUI>();
			playerListText.enableWordWrapping = false;
			playerListText.richText = true;
			playerListText.text = "";
			playerListText.maxVisibleLines = 30;
			playerListText.fontSize = 24;
			playerListText.alignment = TMPro.TextAlignmentOptions.TopLeft;
			playerListText.gameObject.transform.localScale = new Vector3(0.95f, 0.21f, 1);
			playerListText.gameObject.transform.localPosition = new Vector3(60, -8, 0);
			playerListText.transform.SetSiblingIndex(0);
			playerListText.transform.parent.parent.parent.gameObject.SetActive(Settings.ConfigVars.playerlist);

			Component.DestroyImmediate(Objects.qmBackground.GetComponent<VRC.UI.Core.Styles.StyleElement>());
			var qmimage = GameObject.Instantiate(Objects.qmBackground, Objects.qmBackground.transform);
			qmimage.name = "_Background";
			var imagecomponentqm = qmimage.gameObject.GetComponent<UnityEngine.UI.Image>();
			MelonLoader.MelonCoroutines.Start(Apis.ChangeImage.LoadIMGTSprite(imagecomponentqm, Settings.ConfigVars.QmImg));
			imagecomponentqm.color = new Color(1, 1, 1, Settings.ConfigVars.QMopacity);
			var qmmask = Objects.qmBackground.AddComponent<UnityEngine.UI.Mask>();
			qmmask.showMaskGraphic = false;
			Objects.qmBackground.gameObject.Loadfrombytes(Settings.DownloadFiles.quickMenuMask);
			qmimage.transform.localPosition = Vector3.zero;
			qmimage.transform.localScale = Vector3.one;



			GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer02").gameObject.SetActive(false);
			Ui.UIColors.HudColors();
			Ui.UIColors.ApplyButton();
			Ui.UIColors.ApplyText();


			var joinsound = new GameObject("Joinsound");
			joinsound.transform.parent = GameObject.Find("/UserInterface").transform;
			audioSourceNotification = joinsound.AddComponent<AudioSource>();
			audioSourceNotification.playOnAwake = false;
			audioSourceNotification.volume = Settings.ConfigVars.clientvolume / 6;
			MelonLoader.MelonCoroutines.Start(Settings.Wrappers.Extensions.LoadAudio(audioSourceNotification, Settings.DownloadFiles.joinSound));
			var infop = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMNotificationsArea/DebugInfoPanel");
			var secondp = GameObject.Instantiate(infop, infop.transform.parent);
			secondp.GetComponent<UnityEngine.UI.LayoutElement>().enabled = true;
			Component.DestroyImmediate(secondp.GetComponent<VRC.UI.Elements.DebugInfoPanel>());
			Component.DestroyImmediate(secondp.GetComponent<VRC.DataModel.Core.BindingComponent>());
			secondp.gameObject.SetActive(Settings.ConfigVars.qminfopannel);
			secondp.transform.SetSiblingIndex(2);
			firstText = secondp.transform.Find("Panel/Text_FPS").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
			secondText = secondp.transform.Find("Panel/Text_Ping").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
			ThirdText = GameObject.Instantiate(secondText, secondText.transform.parent);
			ThirdText.transform.localPosition = new Vector3(380, 0, 0);
			secondp.transform.Find("Panel/Background").transform.localPosition = new Vector3(300, 0, 0);
			secondp.transform.Find("Panel/Background").GetComponent<RectTransform>().sizeDelta = new Vector2(200, 0);
			ThirdText.enableWordWrapping = false;
			secondText.enableWordWrapping = false;
			firstText.transform.localPosition = new Vector3(firstText.transform.localPosition.x - 30, 0, 0);
			secondText.transform.localPosition = new Vector3(secondText.transform.localPosition.x - 30, 0, 0);
			var texts = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_AvInteractions/Button_ToggleSelfInteract/Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
			texts.text = texts.text += " /Self ERP";

			//meObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)Container/Window/QMParent/Menu_Dashboard/Header_H1/LeftItemContainer/Text_Title").gameObject.transform.localPosition = new Vector3(-32, 0, 0);
			var pushtotalkxbox = GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/VoiceDotParent/PushToTalkXbox").gameObject;
			var instanciatedpushb = GameObject.Instantiate(pushtotalkxbox, pushtotalkxbox.transform.parent.parent);
			var _Imageb = instanciatedpushb.GetComponent<Image>();
			_Imageb.sprite = null;
			_Imageb.color = new Color(0, 0, 0, 0.6f);
			instanciatedpushb.name = "InfoPannel";
			instanciatedpushb.SetActive(true);
			instanciatedpushb.transform.localPosition = new Vector3(-363, -296f, 663);
			instanciatedpushb.transform.localScale = new Vector3(1, 1.2f, 1);
			var tobetext = GameObject.Instantiate(instanciatedpushb, instanciatedpushb.transform).gameObject;
			Component.DestroyImmediate(tobetext.GetComponent<UnityEngine.UI.Image>());
			GUIInfo = tobetext.AddComponent<TMPro.TextMeshProUGUI>();
			GUIInfo.text = "Loading";
			GUIInfo.fontSize = 12;
			GUIInfo.alignment = TMPro.TextAlignmentOptions.Center;
			GUIInfo.transform.localPosition = Vector3.zero;
			GUIInfo.color = new Color(Settings.ConfigVars.HuDColor[0], Settings.ConfigVars.HuDColor[1], Settings.ConfigVars.HuDColor[2]);
			tobetext.transform.localPosition = Vector3.zero;
			tobetext.transform.localScale = Vector3.one;
			Apis.OnScreenUI.GenerateUIMessage();
			instanciatedpushb.gameObject.SetActive(Settings.ConfigVars.hudUi);
			styletimer.Stop();
			NocturnalConsole.Log($"Qm Style Loaded in {styletimer.Elapsed.ToString("hh\\:mm\\:ss\\.ff")} ", "Style", ConsoleColor.Green);

		}
	}
}
