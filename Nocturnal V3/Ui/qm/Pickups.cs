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
            new Submenubutton(Main._mainpage.Getmenu(), "Pickups", _pickupsm, Settings.Download_Files.imagehandler.items, true, 1, 2);

            var rigidlist = new List<UnityEngine.Rigidbody>();

            new NToggle("Max Range", extensions.Getmenu(_pickupsm), () => Settings.ConfigVars.itemmaxrange = true, () => Settings.ConfigVars.itemmaxrange = false, Settings.ConfigVars.itemmaxrange);
            new NToggle("Pickuble", extensions.Getmenu(_pickupsm), () => Settings.ConfigVars.itempickup = true, () => Settings.ConfigVars.itempickup = false, Settings.ConfigVars.itempickup);
            new NToggle("Esp", extensions.Getmenu(_pickupsm), () => { Settings.ConfigVars.itemesp = true;try { Exploits.Itemesp.addesptoitems(true); } catch { }  }, () => { Settings.ConfigVars.itemesp = false; try { Exploits.Itemesp.addesptoitems(false); } catch { } }, Settings.ConfigVars.itemesp);
            new NToggle("Allow Theft", extensions.Getmenu(_pickupsm), () => Settings.ConfigVars.allowitemtheft = true, () => Settings.ConfigVars.allowitemtheft = false, Settings.ConfigVars.allowitemtheft);
            new NToggle("Owner", extensions.Getmenu(_pickupsm), () => Exploits.Pickups._Ownerobj = true, () => Exploits.Pickups._Ownerobj = false, Exploits.Pickups._Ownerobj);
            new NToggle("Stop", extensions.Getmenu(_pickupsm), () => Exploits.Pickups._Stoppickups = true, () => Exploits.Pickups._Stoppickups = false, Exploits.Pickups._Stoppickups);
             new NButton(_pickupsm.Getmenu(), "Respawn Pickups", () =>
              {
                  for (int i = 0; i < Exploits.Pickups.Pickupsobs.Length; i++)
                  {
                      VRC.SDKBase.Networking.SetOwner(VRC.Player.prop_Player_0.field_Private_VRCPlayerApi_0, Exploits.Pickups.Pickupsobs[i].gameObject);
                      Exploits.Pickups.Pickupsobs[i].gameObject.transform.position = new UnityEngine.Vector3(9999999999999999, 0, 0);

                  }
              });
            new NToggle("Velocity Throw", extensions.Getmenu(_pickupsm), () => Settings.ConfigVars.ItemThrowBoost = true, () => Settings.ConfigVars.ItemThrowBoost = false, Settings.ConfigVars.ItemThrowBoost);

            UnityEngine.GameObject VelocityB = null;
            new NButton(out VelocityB, _pickupsm.Getmenu(), "Velocity V: " + Settings.ConfigVars.ItemThrowBoostValue, () =>
            {
                if (!Settings.ConfigVars.ItemThrowBoost)
                {
                    NocturnalC.Log("If u want to change the Velocity Boost Turn on Velocity Throw");
                    return;
                }
                new Apis.Inputpopout("State", value => Settings.ConfigVars.ItemThrowBoostValue = int.Parse(value), () => {
                    for (int i = 0; i < Exploits.Pickups.Pickupsobs.Length; i++)
                        Exploits.Pickups.Pickupsobs[i].ThrowVelocityBoostScale = Settings.ConfigVars.ItemThrowBoostValue;
                    VelocityB.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Velocity V: " + Settings.ConfigVars.ItemThrowBoostValue;
                });
              
            });



          

        }

    }
}
