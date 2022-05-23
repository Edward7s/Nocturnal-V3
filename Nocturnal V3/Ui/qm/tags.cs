using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturnal;
using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
using UnityEngine;
using VRC.SDKBase;
using Newtonsoft.Json;
namespace Nocturnal.Ui.qm
{
    internal class tags
    {

        internal static void Tagsmenu()
        {
            var tags = submenu.Submenu("Tags", Main.mainpage);
            Main.mainpage.getmenu().submenu("Tags", tags, Settings.Download_Files.tag, true, 2, 3);
            var tag = "";
            Apis.qm.Buttons.Button(tags.getmenu(), "Add new tag", () => {

                if (!File.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")) { NocturnalC.log("Cloud Not Find The Key File Please try to enter your key again", "Error", ConsoleColor.Red); return; }

                Apis.inputpopout.run("Add New Tag", value => tag = value, () =>
                {
                    if (tag.Length > 300) {  NocturnalC.log("U can not enter a tag bigger then 300c","Error",ConsoleColor.Red); return; }

                    if (tag.Contains("\n")) { NocturnalC.log("U can not use multiple lines","Error", ConsoleColor.Red); return; }

                    if (tag.Contains("<size=")) { NocturnalC.log("U can not change the text size", "Error", ConsoleColor.Red); return; }

                    var sendtag = new Settings.jsonmanager.custommsg2()
                    {
                        code = "5",

                        msg = JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg2>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")).msg,

                        msg2 = tag,
                    };
                    server.setup.sendmessage(JsonConvert.SerializeObject(sendtag));


                });
            });


            Apis.qm.Buttons.Button(tags.getmenu(), "Remove Tags", () => {

                    var RemoveTags = new Settings.jsonmanager.custommsg()
                    {
                        code = "6",

                        msg = JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg2>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")).msg,

                    };
                server.setup.sendmessage(JsonConvert.SerializeObject(RemoveTags));

            });

        

    }

          
  
       }
}
