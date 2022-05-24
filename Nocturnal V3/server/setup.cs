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

             // NocturnalC.log(code);
       //   NocturnalC.log(message);

            switch (true)
            {

                case true when code == "2":
                    MelonLoader.MelonCoroutines.Start(generatenoralplate(message));
                    break;
                case true when code == "5":
                    MelonLoader.MelonCoroutines.Start(generatenoralplate(message, Settings.Download_Files.logo));
                    break;
                case true when code == "86":
                    var desz3 = JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg>(message);
                    MelonLoader.MelonCoroutines.Start(extensions.clientmessagewaiter(desz3.msg));
                    break;
                case true when code == "7":
                    var desz4 = JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg2>(message);
                    Ui.qm.chat.chattext.text = $"<color=#f0a1ff>[{string.Format("{0:hh:mm:ss tt}", DateTime.Now)}]</color><color=#f3b5ff>{desz4.msg2}</color><color=white>: {desz4.msg}</color>\n"+ Ui.qm.chat.chattext.text;
                    Apis.onscreenui.showmsg($"<color=#f3b5ff>{desz4.msg2}</color><color=white>: {desz4.msg}</color>");

                    break;
                case true when code == "8":                
                       var getcm = JsonConvert.DeserializeObject<List<Settings.jsonmanager.custommsg2>>(JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg>(message).msg);
                        for (int i = 0; i < getcm.Count; i++)
                            Ui.qm.chat.chattext.text = $"<color=#f0a1ff>[Old Message]</color><color=#f3b5ff>{getcm[i].msg}</color><color=white>: {getcm[i].msg2}</color>\n" + Ui.qm.chat.chattext.text;
    
                    
                    break;
                case true when code == "87":
                    var desz2 = JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg>(message);
                    Ui.Qm_basic.secondtext.text = $"C Users:{desz2.msg}";
                    break;
                case true when code == "89":
                   var jsond =  JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg>(message);
                    NocturnalC.log(jsond.msg, "Server");
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

     


            private static IEnumerator generatenoralplate(string st,byte[] img = null)
            {
          
                var deserializedmsg = JsonConvert.DeserializeObject<Settings.jsonmanager.reciveplate>(st);

                var players = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray();

                foreach (var player in players)
                {
                    yield return new WaitForSeconds(1f);
                
                    if (player.field_Private_APIUser_0.id != deserializedmsg.userid) continue;
                    for (int i = 0; i < deserializedmsg.tagslist.Length; i++)
                   {
                    yield return new WaitForSeconds(1f);
                    player.GeneratePlate(deserializedmsg.tagslist[i], img);

                    }
                }
               yield return null;
            }
    }

}
