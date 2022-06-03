using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturnal.Apis;
using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
namespace Nocturnal.Ui.qm
{
    internal class chat
    {
        internal static TMPro.TextMeshProUGUI chattext = null;
        internal static void Chat()
        {
            var chatm = submenu.Create("Client Chat", Main.mainpage);
            Main.mainpage.getmenu().Create("Client Chat", chatm, Settings.Download_Files.chat, true, 1, 4);

            var mess = "";
           var buttonchat = Buttons.Create(chatm.getmenu(),"" ,()=> Apis.inputpopout.run("Send Message", m => mess = m, () =>
            {

                if (mess.Length > 100) { NocturnalC.log("The message its to big","ERROR",ConsoleColor.Red);  return; }

                if (mess.Contains("\n")) { NocturnalC.log("U Can not use multiple lines", "ERROR", ConsoleColor.Red); return; }

                if (mess.Trim().Length < 1) { NocturnalC.log("The message can not be samller then one 1c", "ERROR", ConsoleColor.Red); return; }


                var Tobecomemsg = new Settings.jsonmanager.custommsg2()
                {
                    code = "7",

                    msg = JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg2>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")).msg,

                    msg2 = mess.Trim(),
                    
                };

                server.setup.sendmessage(JsonConvert.SerializeObject(Tobecomemsg));
            }));


            var background = buttonchat.transform.Find("Background");
            background.transform.localPosition = new Vector3(324.8195f, -316.8002f, 0);
            background.transform.localScale = new Vector3(4.56f, 4.84f, 1);
            //  Component.DestroyImmediate(background.GetComponent<UnityEngine.UI.Image>());
            background.gameObject.Loadfrombytes(Settings.Download_Files.chatmask);
            var background2 = GameObject.Instantiate(background, background.transform);
            background.gameObject.AddComponent<UnityEngine.UI.Mask>().showMaskGraphic = false;
            background2.transform.localPosition = Vector3.zero;
            background2.transform.localScale = Vector3.one;
            MelonLoader.MelonCoroutines.Start(Apis.Change_Image.LoadIMGTSprite(background2.gameObject.GetComponent<UnityEngine.UI.Image>(), Settings.ConfigVars.chatimage));
            Component.DestroyImmediate(buttonchat.GetComponent<VRC.UI.Core.Styles.StyleElement>());
            buttonchat.transform.Find("Icon").gameObject.SetActive(false);
            chattext = buttonchat.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            chattext.enableWordWrapping = false;
            chattext.maxVisibleLines = 30;
            chattext.alignment = TMPro.TextAlignmentOptions.TopLeft;
            chattext.transform.parent = background2.transform;
            chattext.gameObject.transform.localPosition = new Vector3(-73, 70.5f, 0);
        
        }

    }
}
