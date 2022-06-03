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
            var pickupsm = submenu.Create("World", Main.mainpage);
            Main.mainpage.getmenu().Create("World", pickupsm, Settings.Download_Files.World, true, 1, 3);




            var Murderexploits  = submenu.Create("Warrning u will probably crash", pickupsm);
            pickupsm.getmenu().Create("Murder", Murderexploits, null);
            Toggle.Create("Self Gold Weapon", Murderexploits.getmenu(), () => ConfigVars.murdergoldweapon = true, () => ConfigVars.murdergoldweapon = false, ConfigVars.murdergoldweapon);
            Toggle.Create("Everyone Gold Weapon", Murderexploits.getmenu(), () => ConfigVars.everyonegoldgun = true, () => ConfigVars.everyonegoldgun = false, ConfigVars.everyonegoldgun);
            Toggle.Create("God Mode", Murderexploits.getmenu(), () => ConfigVars.murdergodmod = true, () => ConfigVars.murdergodmod = false, ConfigVars.murdergodmod);
            Toggle.Create("Self No ShootC", Murderexploits.getmenu(), () => ConfigVars.continuesfire = true, () => ConfigVars.continuesfire = false, ConfigVars.continuesfire);
            Toggle.Create("Everyone No ShootC", Murderexploits.getmenu(), () => ConfigVars.everyonecontinuesfire = true, () => ConfigVars.everyonecontinuesfire = false, ConfigVars.everyonecontinuesfire);

            var Amongusexploits = submenu.Create("Among Us", pickupsm);
            pickupsm.getmenu().Create("Among Us", Amongusexploits, null);

            Toggle.Create("God Mode", Amongusexploits.getmenu(), () => ConfigVars.amongusgodmod = true, () => ConfigVars.amongusgodmod = false, ConfigVars.amongusgodmod);


        }

    }
}
