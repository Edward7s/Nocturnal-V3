using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturnal.Ui;
using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
using Nocturnal.Settings;
namespace Nocturnal.Ui.qm
{
    internal class World
    {

        internal static void _World()
        {
            var pickupsm = submenu.Create("World", Main._mainpage);
            Main._mainpage.Getmenu().Create("World", pickupsm, Settings.Download_Files.imagehandler.World, true, 1, 3);




            var Murderexploits  = submenu.Create("Warrning u will probably crash", pickupsm);
            pickupsm.Getmenu().Create("Murder", Murderexploits, null);
            Toggle.Create("Self Gold Weapon", Murderexploits.Getmenu(), () => ConfigVars.murdergoldweapon = true, () => ConfigVars.murdergoldweapon = false, ConfigVars.murdergoldweapon);
            Toggle.Create("Everyone Gold Weapon", Murderexploits.Getmenu(), () => ConfigVars.everyonegoldgun = true, () => ConfigVars.everyonegoldgun = false, ConfigVars.everyonegoldgun);
            Toggle.Create("God Mode", Murderexploits.Getmenu(), () => ConfigVars.murdergodmod = true, () => ConfigVars.murdergodmod = false, ConfigVars.murdergodmod);
            Toggle.Create("Self No ShootC", Murderexploits.Getmenu(), () => ConfigVars.continuesfire = true, () => ConfigVars.continuesfire = false, ConfigVars.continuesfire);
            Toggle.Create("Everyone No ShootC", Murderexploits.Getmenu(), () => ConfigVars.everyonecontinuesfire = true, () => ConfigVars.everyonecontinuesfire = false, ConfigVars.everyonecontinuesfire);

            var Amongusexploits = submenu.Create("Among Us", pickupsm);
            pickupsm.Getmenu().Create("Among Us", Amongusexploits, null);

            Toggle.Create("God Mode", Amongusexploits.Getmenu(), () => ConfigVars.amongusgodmod = true, () => ConfigVars.amongusgodmod = false, ConfigVars.amongusgodmod);


        }

    }
}
