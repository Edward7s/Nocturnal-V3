using System;
using System.IO;
using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
using Newtonsoft.Json;
namespace Nocturnal.Ui.qm
{
    internal class Tags
    {

        internal static void Tagsmenu()
        {
            var tags = submenu.Create("Tags", Main._mainpage);
            Main._mainpage.Getmenu().Create("Tags", tags, Settings.Download_Files.imagehandler.tag, true, 2, 3);
            var tag = "";
            Buttons.Create(tags.Getmenu(), "Add new tag", () => {

                if (!File.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")) { NocturnalC.Log("Cloud Not Find The Key File Please try to enter your key again", "Error", ConsoleColor.Red); return; }

                Apis.Inputpopout.Run("Add New Tag", value => tag = value, () =>
                {
                    if (tag.Length > 300) {  NocturnalC.Log("U can not enter a tag bigger then 300c","Error",ConsoleColor.Red); return; }

                    if (tag.Contains("\n")) { NocturnalC.Log("U can not use multiple lines","Error", ConsoleColor.Red); return; }

                    if (tag.Contains("<size=")) { NocturnalC.Log("U can not change the text size", "Error", ConsoleColor.Red); return; }

                    var sendtag = new Settings.jsonmanager.custommsg2()
                    {
                        code = "5",

                        msg = JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg2>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")).msg,

                        msg2 = tag,
                    };
                    server.setup.sendmessage(JsonConvert.SerializeObject(sendtag));


                });
            });


            Buttons.Create(tags.Getmenu(), "Remove Tags", () => {

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
