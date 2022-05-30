using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturnal.Ui.QM;
using Nocturnal.Apis.QM;
using Nocturnal.Settings.Wrappers;
using Nocturnal.Exploits;
using UnityEngine;

namespace Nocturnal.Ui.QM
{
    internal class TargetUI
    {
        internal static bool copyik = false;
        internal static bool copyivoice = false;

        internal static void CreateUI()
        {
            var Target = SubMenu.Create("Target", Main.mainPage);
            Main.mainPage.GetMenu().Create("Target", Target, Settings.DownloadFiles.target, false, 3, 2);
			Apis.QM.Button.Create(Settings.Wrappers.Extensions.GetMenu(Target), "Sit On Head", () => {
				SitOnBodyParts.sitting = !SitOnBodyParts.sitting;
				SitOnBodyParts.part = 0; MelonLoader.MelonCoroutines.Start(Exploits.SitOnBodyParts.Run()); 
            });
			Apis.QM.Button.Create(Settings.Wrappers.Extensions.GetMenu(Target), "Sit On Right Hand", () => {
				SitOnBodyParts.sitting = !SitOnBodyParts.sitting;
				SitOnBodyParts.part = 1; MelonLoader.MelonCoroutines.Start(Exploits.SitOnBodyParts.Run());
            });
			Apis.QM.Button.Create(Settings.Wrappers.Extensions.GetMenu(Target), "Sit On Left Hand", () => {
				SitOnBodyParts.sitting = !SitOnBodyParts.sitting;
				SitOnBodyParts.part = 2; MelonLoader.MelonCoroutines.Start(Exploits.SitOnBodyParts.Run());
            });
			Apis.QM.Button.Create(Settings.Wrappers.Extensions.GetMenu(Target), "Sit On Right Shoulder", () => {
				SitOnBodyParts.sitting = !SitOnBodyParts.sitting;
				SitOnBodyParts.part = 3; MelonLoader.MelonCoroutines.Start(Exploits.SitOnBodyParts.Run());
            });
			Apis.QM.Button.Create(Settings.Wrappers.Extensions.GetMenu(Target), "Sit On Left Shoulder", () => {
				SitOnBodyParts.sitting = !SitOnBodyParts.sitting;
				SitOnBodyParts.part = 4; MelonLoader.MelonCoroutines.Start(Exploits.SitOnBodyParts.Run());
            });
            var ikb = Apis.QM.Toggle.Create("Copy Ik", Settings.Wrappers.Extensions.GetMenu(Target), () => { copyik = true; Settings.Wrappers.Extensions.ToggleNetworkSerializer(false);  } , () => { copyik = false; Settings.Wrappers.Extensions.ToggleNetworkSerializer(true); }, copyik);            ikb.GetComponent<UnityEngine.UI.Toggle>().interactable = false;
			//   Apis.qm.Toggle.toggle("Copy Voice", extensions.getmenu(Target), () => copyivoice = true,()=> copyivoice = false, copyivoice);
			Apis.QM.Toggle.Create("Item Orbit", Settings.Wrappers.Extensions.GetMenu(Target), () => {
				Exploits.Orbit.orbiting = true;
				Exploits.Orbit.OrbitObject = UnityEngine.GameObject.CreatePrimitive(UnityEngine.PrimitiveType.Cube);
				Exploits.Orbit.OrbitObject.GetComponent<BoxCollider>().enabled = false;
				Exploits.Orbit.OrbitObject.GetComponent<Renderer>().enabled = false;
            }, () => {
				Exploits.Orbit.orbiting = false;
				GameObject.DestroyImmediate(Exploits.Orbit.OrbitObject);
				Exploits.Orbit.OrbitObject = null;
            }, Exploits.Orbit.orbiting);

        }
    }
}
