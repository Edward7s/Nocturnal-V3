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
            var Target = submenu.Submenu("Target", Main.mainpage);
            Main.mainpage.getmenu().submenu("Target", Target, Settings.Download_Files.Target, false, 3, 2);
            Apis.qm.Buttons.Button(extensions.getmenu(Target), "Sit On Head", () => {  Sitonparts.issiting = !Sitonparts.issiting;
                Sitonparts.part = 0; MelonLoader.MelonCoroutines.Start(exploits.Sitonparts.sitonparts()); 
            });
            Apis.qm.Buttons.Button(extensions.getmenu(Target), "Sit On Right Hand", () => {
                Sitonparts.issiting = !Sitonparts.issiting;
                Sitonparts.part = 1; MelonLoader.MelonCoroutines.Start(exploits.Sitonparts.sitonparts());
            });
            Apis.qm.Buttons.Button(extensions.getmenu(Target), "Sit On Left Hand", () => {
                Sitonparts.issiting = !Sitonparts.issiting;
                Sitonparts.part = 2; MelonLoader.MelonCoroutines.Start(exploits.Sitonparts.sitonparts());
            });
            Apis.qm.Buttons.Button(extensions.getmenu(Target), "Sit On Right Shoulder", () => {
                Sitonparts.issiting = !Sitonparts.issiting;
                Sitonparts.part = 3; MelonLoader.MelonCoroutines.Start(exploits.Sitonparts.sitonparts());
            });
            Apis.qm.Buttons.Button(extensions.getmenu(Target), "Sit On Left Shoulder", () => {
                Sitonparts.issiting = !Sitonparts.issiting; 
                Sitonparts.part = 4; MelonLoader.MelonCoroutines.Start(exploits.Sitonparts.sitonparts());
            });
            Apis.qm.Toggle.toggle("Copy Ik", extensions.getmenu(Target), () => { copyik = true; extensions.togglenetworkserializer(false);  } , () => { copyik = false; extensions.togglenetworkserializer(true); }, copyik);
            //   Apis.qm.Toggle.toggle("Copy Voice", extensions.getmenu(Target), () => copyivoice = true,()=> copyivoice = false, copyivoice);
            Apis.qm.Toggle.toggle("Item Orbit", extensions.getmenu(Target), () => {
                exploits.orbit.isorbiting = true;
                exploits.orbit.orbitobject = UnityEngine.GameObject.CreatePrimitive(UnityEngine.PrimitiveType.Cube);
                exploits.orbit.orbitobject.GetComponent<BoxCollider>().enabled = false;
                exploits.orbit.orbitobject.GetComponent<Renderer>().enabled = false;
            }, () => {
                exploits.orbit.isorbiting = false;
                GameObject.DestroyImmediate(exploits.orbit.orbitobject);
                exploits.orbit.orbitobject = null;
            }, exploits.orbit.isorbiting);

        }
    }
}
