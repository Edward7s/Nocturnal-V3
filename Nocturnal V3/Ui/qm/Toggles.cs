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
        internal static void Runantoggles()
        {
            var toggles = submenu.Create("Toggles", Main._mainpage);
            new Submenubutton(Main._mainpage.Getmenu(), "Toggles", toggles, Settings.Download_Files.imagehandler.Toggles, false, 3, 1);

        //    new NToggle("Hwid Spoofer", toggles.Getmenu(), () => ConfigVars.HwidSpoof = true, () => ConfigVars.HwidSpoof = false, ConfigVars.HwidSpoof);
         //   new NButton(toggles.Getmenu(), "Change HWID", () => ConfigVars.SpoofedHWID = Guid.NewGuid().ToString().Replace("-", "3"));


            new NToggle("Force Jump", toggles.Getmenu(), () => ConfigVars.forcejump = true, () => ConfigVars.forcejump = false, ConfigVars.forcejump);
            new NToggle("Infinite Jump", toggles.Getmenu(), () => ConfigVars.infinitejump = true, () => ConfigVars.infinitejump = false, ConfigVars.infinitejump);
            new NToggle("Third Person", toggles.Getmenu(), () => ConfigVars.Thidperson = true, () => ConfigVars.Thidperson = false, ConfigVars.Thidperson);
            new NToggle("Bhop", toggles.Getmenu(), () => ConfigVars.bhop = true, () => ConfigVars.bhop = false, ConfigVars.bhop);
            new NToggle("Join Sound", toggles.Getmenu(), () => ConfigVars.joinsound = true, () => ConfigVars.joinsound = false, ConfigVars.joinsound);
            new NToggle("Join Friends Sound Only", toggles.Getmenu(), () => ConfigVars.onlyfriendjoin = true, () => ConfigVars.onlyfriendjoin = false, ConfigVars.onlyfriendjoin);
            new NToggle("Hide Questies", toggles.Getmenu(), () =>{
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

        
            new NToggle("Udon Block", toggles.Getmenu(), () => Settings.ConfigVars.udonblock = true, () => Settings.ConfigVars.udonblock = false, Settings.ConfigVars.udonblock);
            
        }


    }
}
