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
            new Submenubutton(Main._mainpage.Getmenu(), "World", pickupsm, Settings.Download_Files.imagehandler.World, true, 1, 3);


            var Murderexploits  = submenu.Create("Warrning u will probably crash", pickupsm);
            new Submenubutton(pickupsm.Getmenu(), "Murder", Murderexploits, null);

            new NToggle("Self Gold Weapon", Murderexploits.Getmenu(), () => ConfigVars.murdergoldweapon = true, () => ConfigVars.murdergoldweapon = false, ConfigVars.murdergoldweapon);
            new NToggle("Everyone Gold Weapon", Murderexploits.Getmenu(), () => ConfigVars.everyonegoldgun = true, () => ConfigVars.everyonegoldgun = false, ConfigVars.everyonegoldgun);
            new NToggle("God Mode", Murderexploits.Getmenu(), () => ConfigVars.murdergodmod = true, () => ConfigVars.murdergodmod = false, ConfigVars.murdergodmod);
            new NToggle("Self No ShootC", Murderexploits.Getmenu(), () => ConfigVars.continuesfire = true, () => ConfigVars.continuesfire = false, ConfigVars.continuesfire);
            new NToggle("Everyone No ShootC", Murderexploits.Getmenu(), () => ConfigVars.everyonecontinuesfire = true, () => ConfigVars.everyonecontinuesfire = false, ConfigVars.everyonecontinuesfire);

            var Amongusexploits = submenu.Create("Among Us", pickupsm);
            new Submenubutton(pickupsm.Getmenu(), "Among Us", Amongusexploits, null);

            new NToggle("God Mode", Amongusexploits.Getmenu(), () => ConfigVars.amongusgodmod = true, () => ConfigVars.amongusgodmod = false, ConfigVars.amongusgodmod);


        }

    }
}
