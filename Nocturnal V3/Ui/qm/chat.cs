using System;
using System.Collections.Generic;
using Nocturnal.Settings;
using Nocturnal.Apis;
using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
namespace Nocturnal.Ui.qm
{
    internal class Chat
    {
        internal static TMPro.TextMeshProUGUI chattext = null;
        internal static void _Chat()
        {
            var chatm = submenu.Create("Client Chat", Main.s_mainpage);
            new Submenubutton(Main.s_mainpage.Getmenu(), "Client Chat", chatm, Settings.Download_Files.imagehandler.chat, true, 1, 4);

            var mess = "";
            GameObject buttonchat = null;
            new NButton(out buttonchat, chatm.Getmenu(), "", () => XRefedMethods.PopOutInput("Send Message", m => mess = m, () =>
            {

                if (mess.Length > 100) { NocturnalC.Log("The message its to big", "ERROR", ConsoleColor.Red); return; }

                if (mess.Contains("\n")) { NocturnalC.Log("U Can not use multiple lines", "ERROR", ConsoleColor.Red); return; }

                if (mess.Trim().Length < 1) { NocturnalC.Log("The message can not be samller then one 1c", "ERROR", ConsoleColor.Red); return; }


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
            background.gameObject.Loadfrombytes(Settings.Download_Files.imagehandler.chatmask);
            var background2 = GameObject.Instantiate(background, background.transform);
            background.gameObject.AddComponent<UnityEngine.UI.Mask>().showMaskGraphic = false;
            background2.transform.localPosition = Vector3.zero;
            background2.transform.localScale = Vector3.one;
            MelonLoader.MelonCoroutines.Start(Apis.Change_Image.LoadIMGTSprite(background2.gameObject.GetComponent<UnityEngine.UI.Image>(), Settings.ConfigVars.chatimage));
            Component.Destroy(buttonchat.GetComponent<VRC.UI.Core.Styles.StyleElement>());
            buttonchat.transform.Find("Icon").gameObject.SetActive(false);
            chattext = buttonchat.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            chattext.enableWordWrapping = false;
            chattext.maxVisibleLines = 30;
            chattext.alignment = TMPro.TextAlignmentOptions.TopLeft;
            chattext.transform.parent = background2.transform;
            chattext.gameObject.transform.localPosition = new Vector3(-73, 10, 0);
        
        }

    }
}
