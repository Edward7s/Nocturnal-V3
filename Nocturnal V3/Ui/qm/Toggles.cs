using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturnal.Ui.qm;
using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
using Nocturnal.Settings;
namespace Nocturnal.Ui.qm
{
    internal class Toggles
    {
        internal static void runantoggles()
        {
            var toggles = submenu.Submenu("Toggles", Main.mainpage);
            Main.mainpage.getmenu().submenu("Toggles", toggles, Settings.Download_Files.Toggles, false, 3, 1);

            Toggle.toggle("Force Jump", toggles.getmenu(), () => ConfigVars.forcejump = true, () => ConfigVars.forcejump = false, ConfigVars.forcejump);
            Toggle.toggle("Infinite Jump", toggles.getmenu(), () => ConfigVars.infinitejump = true, () => ConfigVars.infinitejump = false, ConfigVars.infinitejump);
            Toggle.toggle("Third Person", toggles.getmenu(), () => ConfigVars.Thidperson = true, () => ConfigVars.Thidperson = false, ConfigVars.Thidperson);
            Toggle.toggle("Bhop", toggles.getmenu(), () => ConfigVars.bhop = true, () => ConfigVars.bhop = false, ConfigVars.bhop);
            Toggle.toggle("Join Sound", toggles.getmenu(), () => ConfigVars.joinsound = true, () => ConfigVars.joinsound = false, ConfigVars.joinsound);
            Toggle.toggle("Join Friends Sound Only", toggles.getmenu(), () => ConfigVars.onlyfriendjoin = true, () => ConfigVars.onlyfriendjoin = false, ConfigVars.onlyfriendjoin);
            Toggle.toggle("Hide Questies", toggles.getmenu(), () =>{
                ConfigVars.hidequests = true;
                var playes = extensions.getallplayers();
                for (int i = 0; i < playes.Length; i++)
                {
                    if (playes[i].prop_APIUser_0.last_platform != "standalonewindows" && !playes[i].IsFriend())
                        playes[i].gameObject.SetActive(false);
                }
            }, () => {
                ConfigVars.hidequests = false;
                var playes = extensions.getallplayers();
                for (int i = 0; i < playes.Length; i++)
                {
                    if (playes[i].prop_APIUser_0.last_platform != "standalonewindows" && !playes[i].IsFriend())
                        playes[i].gameObject.SetActive(true);
                }
            }, ConfigVars.hidequests);
            Toggle.toggle("Udon Block", toggles.getmenu(), () => Settings.ConfigVars.udonblock = true, () => Settings.ConfigVars.udonblock = false, Settings.ConfigVars.udonblock);
            
        }


    }
}
