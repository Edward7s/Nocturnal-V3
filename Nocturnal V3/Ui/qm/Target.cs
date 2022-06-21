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
        internal static UnityEngine.UI.LayoutElement[] _LayoutElements { get; set; }
        internal static void tarGetmenu()
        {
            var Target = submenu.Create("Target", Main._mainpage);
            new Submenubutton(Main._mainpage.Getmenu(), "Target", Target, Settings.Download_Files.imagehandler.Target, false, 3, 2);

            new NButton(extensions.Getmenu(Target), "Sit On Head", () => {
                Sitonparts._IsSiting = !Sitonparts._IsSiting;
                Sitonparts._Part = 0; MelonLoader.MelonCoroutines.Start(Sitonparts._Sitonparts());
            });
            new NButton(extensions.Getmenu(Target), "Sit On Right Hand", () => {
                Sitonparts._IsSiting = !Sitonparts._IsSiting;
                Sitonparts._Part = 1; MelonLoader.MelonCoroutines.Start(Sitonparts._Sitonparts());
            });
            new NButton(extensions.Getmenu(Target), "Sit On Left Hand", () => {
                Sitonparts._IsSiting = !Sitonparts._IsSiting;
                Sitonparts._Part = 2; MelonLoader.MelonCoroutines.Start(Sitonparts._Sitonparts());
            });
            new NButton(extensions.Getmenu(Target), "Sit On Right Shoulder", () => {
                Sitonparts._IsSiting = !Sitonparts._IsSiting;
                Sitonparts._Part = 3; MelonLoader.MelonCoroutines.Start(Sitonparts._Sitonparts());
            });
            new NButton(extensions.Getmenu(Target), "Sit On Left Shoulder", () => {
                Sitonparts._IsSiting = !Sitonparts._IsSiting;
                Sitonparts._Part = 4; MelonLoader.MelonCoroutines.Start(Sitonparts._Sitonparts());
            });
            //   new NToggle("Copy Ik", extensions.Getmenu(Target), () => { copyik = true; extensions.togglenetworkserializer(false);  } , () => { copyik = false; extensions.togglenetworkserializer(true); }, copyik);            ikb.GetComponent<UnityEngine.UI.Toggle>().interactable = false;
            //  Toggle.toggle("Copy Voice", extensions.Getmenu(Target), () => copyivoice = true,()=> copyivoice = false, copyivoice);
            new NToggle("Item Orbit", extensions.Getmenu(Target), () => {
                Orbit.isorbiting = true;
                Orbit.orbitobject = UnityEngine.GameObject.CreatePrimitive(UnityEngine.PrimitiveType.Cube);
                Orbit.orbitobject.GetComponent<BoxCollider>().enabled = false;
                Orbit.orbitobject.GetComponent<Renderer>().enabled = false;
            }, () => {
                Orbit.isorbiting = false;
                GameObject.DestroyImmediate(Orbit.orbitobject);
                Orbit.orbitobject = null;
            }, Orbit.isorbiting);

            new NButton(extensions.Getmenu(Target), "Teleport", () =>
           {
               if (Settings.wrappers.Target.targertuser != null)
                   VRC.Player.prop_Player_0.transform.position = Settings.wrappers.Target.targertuser.transform.position;

           }, false, Settings.Download_Files.imagehandler.teleport);

            GameObject svasticaobj = new GameObject();
            new NToggle("Svastica", extensions.Getmenu(Target), () => {
                svasticaobj = new GameObject().AddComponent<Monobehaviours.Svastica>().gameObject;
            }, () => {
                GameObject.DestroyImmediate(svasticaobj);
            });

            new Apis.Slider(extensions.Getmenu(Target), val => Monobehaviours.Svastica.size = val, Monobehaviours.Svastica.size);

            new NButton(extensions.Getmenu(Target), "Spam Udon", () => Exploits.Udon.SpamTarget());


            
            var Lewed = submenu.Create("Lewd Options", Target);
            new Submenubutton(Target.Getmenu(), "Lewed Options", Lewed, null, false, 3, 2);

            new Apis.qm.NButton(Lewed.Getmenu(), "NRefresh", () =>
            {
                _LayoutElements = Lewed.Getmenu().GetComponentsInChildren<UnityEngine.UI.LayoutElement>();
                if (_LayoutElements.Length != 0)
                    for (int i = 0; i < _LayoutElements.Length; i++)
                    {
                        if (_LayoutElements[i].name == "_Button_NRefresh") continue;
                        if (_LayoutElements[i].name == "_Button_NDestroy") continue;

                        GameObject.DestroyImmediate(_LayoutElements[i].gameObject);
                    }
                foreach (var Rend in Settings.wrappers.Target.targertuser._vrcplayer.prop_VRCAvatarManager_0.gameObject.GetComponentsInChildren<Renderer>(true))
                {
                    if (Lewed.Getmenu().transform.Find("_Button_" + Rend.gameObject.name) != null)
                    {
                        Lewed.Getmenu().transform.Find("_Button_" + Rend.gameObject.name).gameObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(
                            new Action(() =>
                            {
                                try
                                {
                                    GameObject.DestroyImmediate(Lewed.Getmenu().transform.Find("_Button_" + Rend.gameObject.name).gameObject);
                                }
                                catch { }
                                GameObject.Destroy(Rend.gameObject);
                            }));
                        continue;
                    }
                    new Apis.qm.NButton(Lewed.Getmenu(), Rend.gameObject.name, () =>
                    {
                        try
                        {
                            GameObject.DestroyImmediate(Lewed.Getmenu().transform.Find("_Button_" + Rend.name).gameObject);
                        }
                        catch { }
                        GameObject.Destroy(Rend.gameObject);
                    });
                }
            });
            new Apis.qm.NButton(Lewed.Getmenu(), "NDestroy", () =>
            {
                _LayoutElements = Lewed.Getmenu().GetComponentsInChildren<UnityEngine.UI.LayoutElement>();
                if (_LayoutElements.Length != 0)
                    for (int i = 0; i < _LayoutElements.Length; i++)
                    {
                        if (_LayoutElements[i].name == "_Button_NRefresh") continue;
                        if (_LayoutElements[i].name == "_Button_NDestroy") continue;

                        GameObject.DestroyImmediate(_LayoutElements[i].gameObject);
                    }
            });
        }
    }
}
