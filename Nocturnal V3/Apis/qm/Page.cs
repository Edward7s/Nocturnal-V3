using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturnal.Ui;
using UnityEngine;
using UnityEngine.UI;

namespace Nocturnal.Apis.qm
{
    public class Page
    {
        internal static GameObject lastmen;
        internal static GameObject page(string text, GameObject opengmj, byte[] img = null)
        {
            lastmen = opengmj;
            var instanciate = GameObject.Instantiate(objects.Page, objects.Page.transform.parent);
            instanciate.name = $"_Page_{text}";
            instanciate.transform.rotation = new Quaternion(0, 0, 0, 0);
            instanciate.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = text;
            instanciate.SetActive(true);
            Component.Destroy(instanciate.transform.Find("Icon").GetComponent<VRC.UI.Core.Styles.StyleElement>());
            instanciate.GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
            instanciate.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(new Action(() => {
                foreach (GameObject gameobject in submenu.submenuslist)
                {

                    if (gameobject != lastmen.gameObject)
                        gameobject.SetActive(false);
                    else
                        gameobject.SetActive(true);

                }
                objects.Submenu.transform.Find("Header_DevTools").gameObject.SetActive(false);
                objects.Submenu.transform.Find("Scrollrect").gameObject.SetActive(false);
                opengmj.SetActive(true);


                for (int i = 0; i < objects.Submenu.transform.childCount; ++i)
                {
                    Transform child = objects.Submenu.transform.GetChild(i);
                    if (child.gameObject.name.Contains("_Submenu_") && opengmj.name != child.gameObject.name)
                        child.gameObject.SetActive(false);

                }
            }));
            //VRC.UI.Elements.Controls.MenuTab
            //MonoBehaviourPublicStInBoGaObObUnique
            foreach (var btn in GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup").GetComponentsInChildren<VRC.UI.Elements.Controls.MenuTab>(true))
            {
                if (btn.name != "_Page_Nocturnal")
                {
                    foreach (var btnn in submenu.submenuslist)
                    {
                        btnn.SetActive(false);
                    }
                    GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_DevTools/Header_DevTools").gameObject.SetActive(true);
                    GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_DevTools/Scrollrect").gameObject.SetActive(true);

                }
            }

            if (img != null)
                Apis.Change_Image.Loadfrombytes(instanciate.transform.Find("Icon").gameObject, img);
            return instanciate;
        }

    }
}