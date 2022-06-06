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
            var _pickupsm = submenu.Create("Pickups", Main._mainpage);
            Main._mainpage.Getmenu().Create("Pickups", _pickupsm, Settings.Download_Files.imagehandler.items, true, 1, 2);

            var rigidlist = new List<UnityEngine.Rigidbody>();


            Toggle.Create("Max Range", extensions.Getmenu(_pickupsm), () => Settings.ConfigVars.itemmaxrange = true, () => Settings.ConfigVars.itemmaxrange = false, Settings.ConfigVars.itemmaxrange);
            Toggle.Create("Pickuble", extensions.Getmenu(_pickupsm), () => Settings.ConfigVars.itempickup = true, () => Settings.ConfigVars.itempickup = false, Settings.ConfigVars.itempickup);
            Toggle.Create("Esp", extensions.Getmenu(_pickupsm), () => { Settings.ConfigVars.itemesp = true;try { Exploits.Itemesp.addesptoitems(true); } catch { }  }, () => { Settings.ConfigVars.itemesp = false; try { Exploits.Itemesp.addesptoitems(false); } catch { } }, Settings.ConfigVars.itemesp);
            Toggle.Create("Allow Theft", extensions.Getmenu(_pickupsm), () => Settings.ConfigVars.allowitemtheft = true, () => Settings.ConfigVars.allowitemtheft = false, Settings.ConfigVars.allowitemtheft);
            Toggle.Create("Owner", extensions.Getmenu(_pickupsm), () => Exploits.Pickups._Ownerobj = true, () => Exploits.Pickups._Ownerobj = false, Exploits.Pickups._Ownerobj);
            Toggle.Create("Stop", extensions.Getmenu(_pickupsm), () => Exploits.Pickups._Stoppickups = true, () => Exploits.Pickups._Stoppickups = false, Exploits.Pickups._Stoppickups);
            Buttons.Create(_pickupsm.Getmenu(), "Respawn Pickups", () =>
              {
                  for (int i = 0; i < Exploits.Pickups.Pickupsobs.Length; i++)
                  {
                      VRC.SDKBase.Networking.SetOwner(VRC.Player.prop_Player_0.field_Private_VRCPlayerApi_0, Exploits.Pickups.Pickupsobs[i].gameObject);
                      Exploits.Pickups.Pickupsobs[i].gameObject.transform.position = new UnityEngine.Vector3(9999999999999999, 0, 0);

                  }
              });

        }

    }
}
