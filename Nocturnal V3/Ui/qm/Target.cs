using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturnal.Ui.qm;
using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
using Nocturnal.exploits;
using UnityEngine;

namespace Nocturnal.Ui.qm
{
    internal class Target
    {
        internal static bool copyik = false;
        internal static bool copyivoice = false;

        internal static void targetmenu()
        {
            var Target = submenu.Create("Target", Main.mainpage);
            Main.mainpage.getmenu().Create("Target", Target, Settings.Download_Files.Target, false, 3, 2);
           Buttons.Create(extensions.getmenu(Target), "Sit On Head", () => {  Sitonparts.issiting = !Sitonparts.issiting;
                Sitonparts.part = 0; MelonLoader.MelonCoroutines.Start(Sitonparts.sitonparts()); 
            });
           Buttons.Create(extensions.getmenu(Target), "Sit On Right Hand", () => {
                Sitonparts.issiting = !Sitonparts.issiting;
                Sitonparts.part = 1; MelonLoader.MelonCoroutines.Start(Sitonparts.sitonparts());
            });
           Buttons.Create(extensions.getmenu(Target), "Sit On Left Hand", () => {
                Sitonparts.issiting = !Sitonparts.issiting;
                Sitonparts.part = 2; MelonLoader.MelonCoroutines.Start(Sitonparts.sitonparts());
            });
           Buttons.Create(extensions.getmenu(Target), "Sit On Right Shoulder", () => {
                Sitonparts.issiting = !Sitonparts.issiting;
                Sitonparts.part = 3; MelonLoader.MelonCoroutines.Start(Sitonparts.sitonparts());
            });
           Buttons.Create(extensions.getmenu(Target), "Sit On Left Shoulder", () => {
                Sitonparts.issiting = !Sitonparts.issiting; 
                Sitonparts.part = 4; MelonLoader.MelonCoroutines.Start(Sitonparts.sitonparts());
            });
        //   Toggle.Create("Copy Ik", extensions.getmenu(Target), () => { copyik = true; extensions.togglenetworkserializer(false);  } , () => { copyik = false; extensions.togglenetworkserializer(true); }, copyik);            ikb.GetComponent<UnityEngine.UI.Toggle>().interactable = false;
            //  Toggle.toggle("Copy Voice", extensions.getmenu(Target), () => copyivoice = true,()=> copyivoice = false, copyivoice);
           Toggle.Create("Item Orbit", extensions.getmenu(Target), () => {
                orbit.isorbiting = true;
                orbit.orbitobject = UnityEngine.GameObject.CreatePrimitive(UnityEngine.PrimitiveType.Cube);
                orbit.orbitobject.GetComponent<BoxCollider>().enabled = false;
                orbit.orbitobject.GetComponent<Renderer>().enabled = false;
            }, () => {
                orbit.isorbiting = false;
                GameObject.DestroyImmediate(orbit.orbitobject);
                orbit.orbitobject = null;
            }, orbit.isorbiting);
            Buttons.Create(extensions.getmenu(Target), "Teleport", () =>
            {
                if (Settings.wrappers.Target.targertuser != null)
                VRC.Player.prop_Player_0.transform.position = Settings.wrappers.Target.targertuser.transform.position;

            }, false, Settings.Download_Files.teleport);


        }
    }
}
