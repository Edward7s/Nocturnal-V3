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
    internal class world
    {

        internal static void World()
        {
            var pickupsm = submenu.Submenu("World", Main.mainpage);
            Main.mainpage.getmenu().submenu("World", pickupsm, Settings.Download_Files.World, true, 1, 3);




            var Murderexploits  = submenu.Submenu("Warrning u will probably crash", pickupsm);
            pickupsm.getmenu().submenu("Murder", Murderexploits, null);
            Apis.qm.Toggle.toggle("Self Gold Weapon", Murderexploits.getmenu(), () => ConfigVars.murdergoldweapon = true, () => ConfigVars.murdergoldweapon = false, ConfigVars.murdergoldweapon);
            Apis.qm.Toggle.toggle("Everyone Gold Weapon", Murderexploits.getmenu(), () => ConfigVars.everyonegoldgun = true, () => ConfigVars.everyonegoldgun = false, ConfigVars.everyonegoldgun);
            Apis.qm.Toggle.toggle("God Mode", Murderexploits.getmenu(), () => ConfigVars.murdergodmod = true, () => ConfigVars.murdergodmod = false, ConfigVars.murdergodmod);
            Apis.qm.Toggle.toggle("Self No ShootC", Murderexploits.getmenu(), () => ConfigVars.continuesfire = true, () => ConfigVars.continuesfire = false, ConfigVars.continuesfire);
            Apis.qm.Toggle.toggle("Everyone No ShootC", Murderexploits.getmenu(), () => ConfigVars.everyonecontinuesfire = true, () => ConfigVars.everyonecontinuesfire = false, ConfigVars.everyonecontinuesfire);

            var Amongusexploits = submenu.Submenu("Among Us", pickupsm);
            pickupsm.getmenu().submenu("Among Us", Amongusexploits, null);

            Apis.qm.Toggle.toggle("God Mode", Amongusexploits.getmenu(), () => ConfigVars.amongusgodmod = true, () => ConfigVars.amongusgodmod = false, ConfigVars.amongusgodmod);


        }

    }
}
