using Newtonsoft.Json;
using Nocturnal.Apis;
using Nocturnal.Apis.QM;
using Nocturnal.Settings.Wrappers;
using System;
using System.IO;
using UnityEngine;
namespace Nocturnal.Ui.QM
{
	internal class Chat
	{
		internal static TMPro.TextMeshProUGUI chatText = null;
		internal static void CreateUI()
		{
			var chatm = SubMenu.Create("Client Chat", Main.mainPage);
			Main.mainPage.GetMenu().Create("Client Chat", chatm, Settings.DownloadFiles.chat, true, 1, 4);

			var mess = "";
			var buttonchat = Apis.QM.Button.Create(chatm.GetMenu(), "", () => Apis.InputPopup.Run("Send Message", m => mess = m, () =>
			{

				if (mess.Length > 100) { NocturnalConsole.Log("The message its to big", "ERROR", ConsoleColor.Red); return; }

				if (mess.Contains("\n")) { NocturnalConsole.Log("U Can not use multiple lines", "ERROR", ConsoleColor.Red); return; }

				if (mess.Trim().Length < 1) { NocturnalConsole.Log("The message can not be samller then one 1c", "ERROR", ConsoleColor.Red); return; }


				var Tobecomemsg = new Settings.JsonManager.custommsg2()
				{
					code = "7",

					msg = JsonConvert.DeserializeObject<Settings.JsonManager.custommsg2>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")).msg,

					msg2 = mess.Trim(),

				};

				Server.Setup.sendmessage(JsonConvert.SerializeObject(Tobecomemsg));
			}));


			var background = buttonchat.transform.Find("Background");
			background.transform.localPosition = new Vector3(324.8195f, -316.8002f, 0);
			background.transform.localScale = new Vector3(4.56f, 4.84f, 1);
			//  Component.DestroyImmediate(background.GetComponent<UnityEngine.UI.Image>());
			background.gameObject.Loadfrombytes(Settings.DownloadFiles.chatMask);
			var background2 = GameObject.Instantiate(background, background.transform);
			background.gameObject.AddComponent<UnityEngine.UI.Mask>().showMaskGraphic = false;
			background2.transform.localPosition = Vector3.zero;
			background2.transform.localScale = Vector3.one;
			MelonLoader.MelonCoroutines.Start(Apis.ChangeImage.LoadIMGTSprite(background2.gameObject.GetComponent<UnityEngine.UI.Image>(), Settings.ConfigVars.chatimage));
			Component.DestroyImmediate(buttonchat.GetComponent<VRC.UI.Core.Styles.StyleElement>());
			buttonchat.transform.Find("Icon").gameObject.SetActive(false);
			chatText = buttonchat.GetComponentInChildren<TMPro.TextMeshProUGUI>();
			chatText.enableWordWrapping = false;
			chatText.maxVisibleLines = 30;
			chatText.alignment = TMPro.TextAlignmentOptions.TopLeft;
			chatText.transform.parent = background2.transform;
			chatText.gameObject.transform.localPosition = new Vector3(-73, 70.5f, 0);
		}
	}
}
