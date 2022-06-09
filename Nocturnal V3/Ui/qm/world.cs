using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturnal.Ui;
using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
using Nocturnal.Settings;
using UnityEngine;
using Nocturnal.Exploits;

namespace Nocturnal.Ui.qm
{
    internal class World
    {
        internal static GameObject udonmanager;
        internal static VRC.Udon.Common.Interfaces.NetworkEventTarget reciver = VRC.Udon.Common.Interfaces.NetworkEventTarget.All;

        internal static void _World()
        {
            var worldmenu = submenu.Create("World", Main._mainpage);
            new Submenubutton(Main._mainpage.Getmenu(), "World", worldmenu, Settings.Download_Files.imagehandler.World, true, 1, 3);

            var Murderexploits  = submenu.Create("Warrning u will probably crash", worldmenu);
            new Submenubutton(worldmenu.Getmenu(), "Murder", Murderexploits, null);

            new NToggle("Self Gold Weapon", Murderexploits.Getmenu(), () => ConfigVars.murdergoldweapon = true, () => ConfigVars.murdergoldweapon = false, ConfigVars.murdergoldweapon);
            new NToggle("Everyone Gold Weapon", Murderexploits.Getmenu(), () => ConfigVars.everyonegoldgun = true, () => ConfigVars.everyonegoldgun = false, ConfigVars.everyonegoldgun);
            new NToggle("God Mode", Murderexploits.Getmenu(), () => ConfigVars.murdergodmod = true, () => ConfigVars.murdergodmod = false, ConfigVars.murdergodmod);
            new NToggle("Self No ShootC", Murderexploits.Getmenu(), () => ConfigVars.continuesfire = true, () => ConfigVars.continuesfire = false, ConfigVars.continuesfire);
            new NToggle("Everyone No ShootC", Murderexploits.Getmenu(), () => ConfigVars.everyonecontinuesfire = true, () => ConfigVars.everyonecontinuesfire = false, ConfigVars.everyonecontinuesfire);

            var Amongusexploits = submenu.Create("Among Us", worldmenu);
            new Submenubutton(worldmenu.Getmenu(), "Among Us", Amongusexploits, null);

            new NToggle("God Mode", Amongusexploits.Getmenu(), () => ConfigVars.amongusgodmod = true, () => ConfigVars.amongusgodmod = false, ConfigVars.amongusgodmod);


            udonmanager = submenu.Create("Udon Manager", worldmenu);
            new Submenubutton(worldmenu.Getmenu(), "Udon Manager", udonmanager);

            new Apis.qm.NButton(udonmanager.Getmenu(), "NRefresh", () => {
                destroybuttons();
                addbuttons();
            });

            new Apis.qm.NButton(udonmanager.Getmenu(), "NDestroy Buttons", () => {
                destroybuttons();
            });

            new Apis.qm.NToggle("Only Target", udonmanager.Getmenu(), () => {
                reciver = VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner;
            }, () =>
            {
                reciver = VRC.Udon.Common.Interfaces.NetworkEventTarget.All;
            });
        }


        private static void addbuttons()
        {

            foreach (var udon in Udon.udonbeh)
            {
                foreach (var table in udon._eventTable)
                {
                    if (table.Key.StartsWith("_")) continue;

                    var act = new Action(() => {

                        if (reciver == VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner)
                        {
                            VRC.SDKBase.Networking.SetOwner(Settings.wrappers.Target.targertuser.field_Private_VRCPlayerApi_0, udon.gameObject);
                            udon.SendCustomNetworkEvent(reciver, table.Key);
                        }
                        else
                            udon.SendCustomNetworkEvent(reciver, table.Key);

                    });

                    if (udonmanager.Getmenu().transform.Find($"_Button_{table.Key}") != null)
                    {
                        udonmanager.Getmenu().transform.Find($"_Button_{table.Key}").gameObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(act);
                        continue;
                    }
                    new Apis.qm.NButton(udonmanager.Getmenu(), table.Key, act);
                }
            }
               
        }

        private static void destroybuttons()
        {

            var buttons = udonmanager.Getmenu().GetComponentsInChildren<UnityEngine.UI.LayoutElement>();
            if (buttons.Length != 0)
                for (int i = 0; i < buttons.Length; i++)
                {
                    if (buttons[i].name == "_Button_NRefresh") continue;

                    if (buttons[i].name == "_Button_NDestroy Buttons") continue;

                    if (buttons[i].name == "Toggle_Only Target") continue;


                    GameObject.DestroyImmediate(buttons[i].gameObject);
                }
        }

    }
}
