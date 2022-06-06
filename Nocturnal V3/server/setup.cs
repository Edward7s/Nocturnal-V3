using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using Newtonsoft.Json;
using Nocturnal.Settings.wrappers;
using VRC;
using System.Reflection;
using System.Windows.Forms;
using System.Collections;
using UnityEngine;
using System.IO;
using System.Windows.Threading;
namespace Nocturnal.server
{
    internal class setup
    {
        private static WebSocket wss = null;
        private protected static bool onetime = true;
        internal static void serversetup()
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
                   
                    var newi = new Settings.jsonmanager.custommsg()
                    {
                        code = "1",

                        msg = VRC.Core.APIUser.CurrentUser.id,

                    };
                    sendmessage(JsonConvert.SerializeObject(newi));

                    if (File.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp"))
                    {
                        var newmsg = new Settings.jsonmanager.custommsg2()
                        {
                            code = "4",

                            msg = JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg2>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")).msg,

                            msg2 = JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg2>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")).msg2,
                        };

                        sendmessage(JsonConvert.SerializeObject(newmsg));
                    }

                    if (onetime)
                    {
                        var cb = new Settings.jsonmanager.custommsg()
                        {
                            code = "8",

                            msg = "recivechatmsg",
                        };
                        server.setup.sendmessage(JsonConvert.SerializeObject(cb));
                        onetime = false;
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

             // NocturnalC.Log(code);
       //   NocturnalC.Log(message);

            switch (true)
            {

                case true when code == "2":
                    MelonLoader.MelonCoroutines.Start(generatenoralplate(message));
                    break;
                case true when code == "5":
                    MelonLoader.MelonCoroutines.Start(generatenoralplate(message, Settings.Download_Files.imagehandler.logo));
                    break;
                case true when code == "86":
                    var desz3 = JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg>(message);
                    MelonLoader.MelonCoroutines.Start(extensions.clientmessagewaiter(desz3.msg));
                    break;
                case true when code == "7":
                    var desz4 = JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg2>(message);
                    Ui.qm.Chat.chattext.text = $"<color=#f0a1ff>[{string.Format("{0:hh:mm:ss tt}", DateTime.Now)}]</color><color=#f3b5ff>{desz4.msg2}</color><color=white>: {desz4.msg}</color>\n"+ Ui.qm.Chat.chattext.text;
                    MelonLoader.MelonCoroutines.Start(Apis.Onscreenui.showmsgienum($"<color=#f3b5ff>{desz4.msg2}</color><color=white>: {desz4.msg}</color>"));

                    break;
                case true when code == "8":                
                       var getcm = JsonConvert.DeserializeObject<List<Settings.jsonmanager.custommsg2>>(JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg>(message).msg);
                        for (int i = 0; i < getcm.Count; i++)
                            Ui.qm.Chat.chattext.text = $"<color=#f0a1ff>[Old Message]</color><color=#f3b5ff>{getcm[i].msg}</color><color=white>: {getcm[i].msg2}</color>\n" + Ui.qm.Chat.chattext.text;
                    break;
                case true when code == "12":
                    MelonLoader.MelonCoroutines.Start(waitforobj());
                    break;
                case true when code == "11":
                    var dezmsg = JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg>(message);
                    Ui.Objects._trustranktext.text = $"[{Ui.Objects._trustranktext.text}] [{dezmsg.msg}]";
                    break;
                case true when code == "87":
                    var desz2 = JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg>(message);
                    Ui.Qm_basic._secondtext.text = $"C Users:{desz2.msg}";
                    break;
                case true when code == "89":
                   var jsond =  JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg>(message);
                    NocturnalC.Log(jsond.msg, "Server");
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
            while (Ui.buttons_b.buttonaddtag == null)
                yield return null;


            Ui.buttons_b.buttonaddtag.SetActive(true);
            yield return null;
        }
        



            private static IEnumerator generatenoralplate(string st,string img = null)
            {
          
                var deserializedmsg = JsonConvert.DeserializeObject<Settings.jsonmanager.reciveplate>(st);

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
