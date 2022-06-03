using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturnal.Ui;
using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
namespace Nocturnal.Ui.qm
{
    internal class Pickups
    {

        internal static void pickups()
        {
            var pickupsm = submenu.Create("Pickups", Main.mainpage);
            Main.mainpage.getmenu().Create("Pickups", pickupsm, Settings.Download_Files.items, true, 1, 2);

            var rigidlist = new List<UnityEngine.Rigidbody>();


            Toggle.Create("Max Range", extensions.getmenu(pickupsm), () => Settings.ConfigVars.itemmaxrange = true, () => Settings.ConfigVars.itemmaxrange = false, Settings.ConfigVars.itemmaxrange);
            Toggle.Create("Pickuble", extensions.getmenu(pickupsm), () => Settings.ConfigVars.itempickup = true, () => Settings.ConfigVars.itempickup = false, Settings.ConfigVars.itempickup);
            Toggle.Create("Esp", extensions.getmenu(pickupsm), () => { Settings.ConfigVars.itemesp = true;try { exploits.itemesp.addesptoitems(true); } catch { }  }, () => { Settings.ConfigVars.itemesp = false; try { exploits.itemesp.addesptoitems(false); } catch { } }, Settings.ConfigVars.itemesp);
            Toggle.Create("Allow Theft", extensions.getmenu(pickupsm), () => Settings.ConfigVars.allowitemtheft = true, () => Settings.ConfigVars.allowitemtheft = false, Settings.ConfigVars.allowitemtheft);
            Toggle.Create("Owner", extensions.getmenu(pickupsm), () => exploits.pickups.ownerobj = true, () => exploits.pickups.ownerobj = false, exploits.pickups.ownerobj);
            Toggle.Create("Stop", extensions.getmenu(pickupsm), () => exploits.pickups.stoppickups = true, () => exploits.pickups.stoppickups = false, exploits.pickups.stoppickups);
            Buttons.Create(pickupsm.getmenu(), "Respawn Pickups", () =>
              {
                  for (int i = 0; i < exploits.pickups.pickupsobs.Length; i++)
                  {
                      VRC.SDKBase.Networking.SetOwner(VRC.Player.prop_Player_0.field_Private_VRCPlayerApi_0, exploits.pickups.pickupsobs[i].gameObject);
                      exploits.pickups.pickupsobs[i].gameObject.transform.position = new UnityEngine.Vector3(9999999999999999, 0, 0);

                  }
              });

        }

    }
}
