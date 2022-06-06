using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturnal.Ui.qm;
using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
using Nocturnal.Exploits;
using UnityEngine;

namespace Nocturnal.Ui.qm
{
    internal class Target
    {
        internal static bool _copyik = false;
        internal static bool _copyivoice = false;

        internal static void tarGetmenu()
        {
            var Target = submenu.Create("Target", Main._mainpage);
            Main._mainpage.Getmenu().Create("Target", Target, Settings.Download_Files.imagehandler.Target, false, 3, 2);
            Buttons.Create(extensions.Getmenu(Target), "Sit On Head", () => {
                Sitonparts.issiting = !Sitonparts.issiting;
                Sitonparts.part = 0; MelonLoader.MelonCoroutines.Start(Sitonparts._Sitonparts());
            });
            Buttons.Create(extensions.Getmenu(Target), "Sit On Right Hand", () => {
                Sitonparts.issiting = !Sitonparts.issiting;
                Sitonparts.part = 1; MelonLoader.MelonCoroutines.Start(Sitonparts._Sitonparts());
            });
            Buttons.Create(extensions.Getmenu(Target), "Sit On Left Hand", () => {
                Sitonparts.issiting = !Sitonparts.issiting;
                Sitonparts.part = 2; MelonLoader.MelonCoroutines.Start(Sitonparts._Sitonparts());
            });
            Buttons.Create(extensions.Getmenu(Target), "Sit On Right Shoulder", () => {
                Sitonparts.issiting = !Sitonparts.issiting;
                Sitonparts.part = 3; MelonLoader.MelonCoroutines.Start(Sitonparts._Sitonparts());
            });
            Buttons.Create(extensions.Getmenu(Target), "Sit On Left Shoulder", () => {
                Sitonparts.issiting = !Sitonparts.issiting;
                Sitonparts.part = 4; MelonLoader.MelonCoroutines.Start(Sitonparts._Sitonparts());
            });
            //   Toggle.Create("Copy Ik", extensions.Getmenu(Target), () => { copyik = true; extensions.togglenetworkserializer(false);  } , () => { copyik = false; extensions.togglenetworkserializer(true); }, copyik);            ikb.GetComponent<UnityEngine.UI.Toggle>().interactable = false;
            //  Toggle.toggle("Copy Voice", extensions.Getmenu(Target), () => copyivoice = true,()=> copyivoice = false, copyivoice);
            Toggle.Create("Item Orbit", extensions.Getmenu(Target), () => {
                Orbit.isorbiting = true;
                Orbit.orbitobject = UnityEngine.GameObject.CreatePrimitive(UnityEngine.PrimitiveType.Cube);
                Orbit.orbitobject.GetComponent<BoxCollider>().enabled = false;
                Orbit.orbitobject.GetComponent<Renderer>().enabled = false;
            }, () => {
                Orbit.isorbiting = false;
                GameObject.DestroyImmediate(Orbit.orbitobject);
                Orbit.orbitobject = null;
            }, Orbit.isorbiting);
            Buttons.Create(extensions.Getmenu(Target), "Teleport", () =>
            {
                if (Settings.wrappers.Target.targertuser != null)
                    VRC.Player.prop_Player_0.transform.position = Settings.wrappers.Target.targertuser.transform.position;

            }, false, Settings.Download_Files.imagehandler.teleport);


        }
    }
}
