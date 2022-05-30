using Newtonsoft.Json;
using Nocturnal.Settings.Wrappers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using VRC;
using WebSocketSharp;
namespace Nocturnal.Server
{
	internal class Setup
	{
		private static WebSocket wss = null;
		private protected static bool oneTime = true;
		internal static void ServerSetup()
		{
			using (wss = new WebSocket("wss://wsserver.nocturnal-client.xyz"))
			{
				wss.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12;
				wss.Connect();
				wss.OnClose += (sender, e) =>
				{
					tryrecconect();
				};
				wss.OnOpen += (sender, e) =>
				{

					var newi = new Settings.JsonManager.custommsg()
					{
						code = "1",
						msg = VRC.Core.APIUser.CurrentUser.id,
					};
					sendmessage(JsonConvert.SerializeObject(newi));

					if (File.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp"))
					{
						var newmsg = new Settings.JsonManager.custommsg2()
						{
							code = "4",
							msg = JsonConvert.DeserializeObject<Settings.JsonManager.custommsg2>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")).msg,
							msg2 = JsonConvert.DeserializeObject<Settings.JsonManager.custommsg2>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")).msg2,
						};
						sendmessage(JsonConvert.SerializeObject(newmsg));
					}

					if (oneTime)
					{
						var cb = new Settings.JsonManager.custommsg()
						{
							code = "8",
							msg = "recivechatmsg",
						};
						Server.Setup.sendmessage(JsonConvert.SerializeObject(cb));
						oneTime = false;
					}

				};
				wss.OnMessage += Wss_OnMessage; ;
				wss.Log.Output = (_, __) => { };
			}

		}

		internal static void sendmessage(string text)
		{
			try
			{
				if (wss.IsAlive)
					wss.Send(text);
			}
			catch { }

		}

		private static void Wss_OnMessage(object sender, MessageEventArgs e)
		{
			var message = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(e.Data));

			string code = "Number";
			if (message.Substring(10, 1) != "\"")
				code = message.Substring(9, 2);
			else
				code = message.Substring(9, 1);

			// NocturnalC.log(code);
			//   NocturnalC.log(message);

			switch (true)
			{

				case true when code == "2":
					MelonLoader.MelonCoroutines.Start(generatenoralplate(message));
					break;
				case true when code == "5":
					MelonLoader.MelonCoroutines.Start(generatenoralplate(message, Settings.DownloadFiles.logo));
					break;
				case true when code == "86":
					var desz3 = JsonConvert.DeserializeObject<Settings.JsonManager.custommsg>(message);
					MelonLoader.MelonCoroutines.Start(Settings.Wrappers.Extensions.ClientMessageWaiter(desz3.msg));
					break;
				case true when code == "7":
					var desz4 = JsonConvert.DeserializeObject<Settings.JsonManager.custommsg2>(message);
					Ui.QM.Chat.chatText.text = $"<color=#f0a1ff>[{string.Format("{0:hh:mm:ss tt}", DateTime.Now)}]</color><color=#f3b5ff>{desz4.msg2}</color><color=white>: {desz4.msg}</color>\n" + Ui.QM.Chat.chatText.text;
					MelonLoader.MelonCoroutines.Start(Apis.OnScreenUI.ShowMessageIEnumerator($"<color=#f3b5ff>{desz4.msg2}</color><color=white>: {desz4.msg}</color>"));

					break;
				case true when code == "8":
					var getcm = JsonConvert.DeserializeObject<List<Settings.JsonManager.custommsg2>>(JsonConvert.DeserializeObject<Settings.JsonManager.custommsg>(message).msg);
					for (int i = 0; i < getcm.Count; i++)
						Ui.QM.Chat.chatText.text = $"<color=#f0a1ff>[Old Message]</color><color=#f3b5ff>{getcm[i].msg}</color><color=white>: {getcm[i].msg2}</color>\n" + Ui.QM.Chat.chatText.text;
					break;
				case true when code == "12":
					MelonLoader.MelonCoroutines.Start(waitforobj());
					break;
				case true when code == "11":
					var dezmsg = JsonConvert.DeserializeObject<Settings.JsonManager.custommsg>(message);
					Ui.Objects.trustRankText.text = $"[{Ui.Objects.trustRankText.text}] [{dezmsg.msg}]";
					break;
				case true when code == "87":
					var desz2 = JsonConvert.DeserializeObject<Settings.JsonManager.custommsg>(message);
					Ui.QMBasic.secondText.text = $"C Users:{desz2.msg}";
					break;
				case true when code == "89":
					var jsond = JsonConvert.DeserializeObject<Settings.JsonManager.custommsg>(message);
					NocturnalConsole.Log(jsond.msg, "Server");
					break;
			}
		}
		internal static void tryrecconect()
		{
			try
			{
				wss.Connect();
			}
			catch { }

		}

		private static IEnumerator waitforobj()
		{
			while (Ui.BigUIButton.buttonaddtag == null)
				yield return null;

			Ui.BigUIButton.buttonaddtag.SetActive(true);
			yield return null;
		}

		private static IEnumerator generatenoralplate(string st, byte[] img = null)
		{

			var deserializedmsg = JsonConvert.DeserializeObject<Settings.JsonManager.reciveplate>(st);
			var players = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray();

			for (int i2 = 0; i2 < players.Length; i2++)
			{
				yield return new WaitForSeconds(1.5f);

				if (players[i2].field_Private_APIUser_0.id != deserializedmsg.userid) continue;
				for (int i = 0; i < deserializedmsg.tagslist.Length; i++)
				{
					yield return new WaitForSeconds(1.5f);
					players[i2].GeneratePlate(deserializedmsg.tagslist[i], img);
				}
			}

			yield return null;
		}
	}

}
