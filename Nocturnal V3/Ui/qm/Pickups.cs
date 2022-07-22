using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturnal.Ui;
using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
using UnityEngine;
using Nocturnal.Settings;

namespace Nocturnal.Ui.qm
{
    internal class Pickups
    {

        internal static void pickups()
        {
            var _pickupsm = submenu.Create("Pickups", Main.s_mainpage);
            new Submenubutton(Main.s_mainpage.Getmenu(), "Pickups", _pickupsm, Settings.Download_Files.imagehandler.items, true, 1, 2);
            var rigidlist = new List<UnityEngine.Rigidbody>();
            new NToggle("Max Range", extensions.Getmenu(_pickupsm), () => Settings.ConfigVars.itemmaxrange = true, () => Settings.ConfigVars.itemmaxrange = false, Settings.ConfigVars.itemmaxrange);
            new NToggle("Pickuble", extensions.Getmenu(_pickupsm), () => Settings.ConfigVars.itempickup = true, () => Settings.ConfigVars.itempickup = false, Settings.ConfigVars.itempickup);
            new NToggle("Esp", extensions.Getmenu(_pickupsm), () => { Settings.ConfigVars.itemesp = true; try { new Exploits.Itemesp(true); } catch { } }, () => { Settings.ConfigVars.itemesp = false; try { new Exploits.Itemesp(false); } catch { } }, Settings.ConfigVars.itemesp);
            new NToggle("Allow Theft", extensions.Getmenu(_pickupsm), () => Settings.ConfigVars.allowitemtheft = true, () => Settings.ConfigVars.allowitemtheft = false, Settings.ConfigVars.allowitemtheft);
            new NToggle("Owner", extensions.Getmenu(_pickupsm), () => Inject_monos._UpdateManager.GetComponent<Monobehaviours.UpdateManager>().InvokeRepeating("OwnerPickups", -1, Time.smoothDeltaTime * 5.5f), () => Inject_monos._UpdateManager.GetComponent<Monobehaviours.UpdateManager>().CancelInvoke("OwnerPickups"));
            new NToggle("Stop", extensions.Getmenu(_pickupsm), () => Inject_monos._UpdateManager.GetComponent<Monobehaviours.UpdateManager>().InvokeRepeating("StopObjs", -1, Time.smoothDeltaTime * 5.5f), () => Inject_monos._UpdateManager.GetComponent<Monobehaviours.UpdateManager>().CancelInvoke("StopObjs"));
            new NToggle("Lagger", extensions.Getmenu(_pickupsm), () => Inject_monos._ItemLagger.SetActive(true), () => Inject_monos._ItemLagger.SetActive(false));
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
                    NocturnalC.Log("If u want to change the Velocity Boost Turn on Velocity Throw", "Pickups", ConsoleColor.Red);
                    return;
                }
                XRefedMethods.PopOutNumbersKeyboard("State", value => Settings.ConfigVars.ItemThrowBoostValue = value, () => {
                    for (int i = 0; i < Exploits.Pickups.Pickupsobs.Length; i++)
                        Exploits.Pickups.Pickupsobs[i].ThrowVelocityBoostScale = Settings.ConfigVars.ItemThrowBoostValue;
                    VelocityB.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Velocity V: " + Settings.ConfigVars.ItemThrowBoostValue;
                });

            });
            new NToggle("Become Pickup", extensions.Getmenu(_pickupsm), () => Settings.Hooks.PickupMover = true, () => Settings.Hooks.PickupMover = false, Settings.Hooks.PickupMover);

            new NToggle("Gravity", extensions.Getmenu(_pickupsm), () => Settings.ConfigVars.ItemsGrav = true, () => { Settings.ConfigVars.ItemsGrav = false;
                var objects = GameObject.FindObjectsOfType<Monobehaviours.PickupLevitation>();
                if (objects.Length != 0)
                    for (int i = 0; i < objects.Length; i++)
                        Component.DestroyImmediate(objects[i]);
            }, Settings.ConfigVars.ItemsGrav);

        }
        // ItemsGrav
    }
}
