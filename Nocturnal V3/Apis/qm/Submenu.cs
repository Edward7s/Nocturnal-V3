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
    internal class submenu
    {
        internal static List<GameObject> submenuslist = new List<GameObject>();

        internal static GameObject Create(string text, GameObject indexer = null,bool selfaling = false)
        {
            GameObject gam = new GameObject();
            gam.AddComponent<UnityEngine.CanvasGroup>();
           
            gam.name = $"_Submenu_{text}";
            gam.transform.parent = Objects._Submenu.transform.parent.transform.Find("Menu_Nocturanl").transform;
            gam.SetActive(false);
            var mask = new GameObject();
            mask.transform.parent = gam.transform;
            mask.AddComponent<UIInvisibleGraphic>();
            mask.AddComponent<UnityEngine.UI.RectMask2D>();
            mask.transform.localScale = new Vector3(10.5f, 9.2f, 1);
            mask.transform.localPosition = new Vector3(0f, -554.4909f, 0);
            mask.transform.localRotation = new Quaternion(0, 0, 0, 0);
            mask.name = "Masked";
            var instanciateds = GameObject.Instantiate(Objects._Submenu.transform.Find("Header_DevTools").gameObject, gam.transform);
            instanciateds.transform.Find("LeftItemContainer/Text_Title").GetComponent<TMPro.TextMeshProUGUI>().text = text;
            instanciateds.transform.localPosition = new Vector3(-514, 0, 0);
            var instanciated = GameObject.Instantiate(Objects._Submenu.transform.Find("Scrollrect").gameObject, mask.transform);
            instanciated.transform.localPosition = new Vector3(0, 50, 0);
            instanciated.transform.localScale = new Vector3(0.095f, 0.11f, 1f);
            instanciated.gameObject.SetActive(true);
            instanciated.GetComponent<ScrollRect>().enabled = true;
            gam.transform.localScale = Vector3.one;
            gam.transform.rotation = new Quaternion(0, 0, 0, 0);
            gam.transform.localPosition = new Vector3(0, 512, 0);
            var childs = instanciated.transform.Find("Viewport/VerticalLayoutGroup/Buttons").GetComponentsInChildren<LayoutElement>(true);
            for (int i = 0; i < childs.Length; i++)
                GameObject.DestroyImmediate(childs[i].gameObject);
            

            instanciated.transform.Find("Viewport/VerticalLayoutGroup").gameObject.GetComponent<UnityEngine.UI.VerticalLayoutGroup>().childControlHeight = true;
            Component.DestroyImmediate(instanciated.transform.Find("Viewport/VerticalLayoutGroup/Buttons").gameObject.GetComponent<GridLayoutGroup>());
            instanciated.transform.Find("Viewport/VerticalLayoutGroup/Buttons").gameObject.AddComponent<GridLayoutGroup>().cellSize = new Vector2(1100, 150);
            instanciated.transform.Find("Viewport/VerticalLayoutGroup/Buttons").gameObject.SetActive(false);
            submenuslist.Add(gam.gameObject);

            if (indexer != null)
            {

                var buttoni = instanciateds.transform.Find("LeftItemContainer/Button_Back").gameObject.GetComponent<UnityEngine.UI.Button>();

                buttoni.gameObject.SetActive(true);

                buttoni.onClick.RemoveAllListeners();

                buttoni.onClick.AddListener(new Action(() =>
                {

                    for (int i = 0; i < submenuslist.Count; i++)
                    {
                        if (submenuslist[i] != indexer.gameObject)
                            submenuslist[i].SetActive(false);
                        else
                        {
                            Page.lastmen = submenuslist[i];
                            submenuslist[i].SetActive(true);
                        }
                    }
                }));
            }
            if (selfaling == true)
            {
                Component.DestroyImmediate(gam.transform.Find("Masked/Scrollrect(Clone)").gameObject.GetComponent<ScrollRect>());
                Component.DestroyImmediate(gam.transform.Find("Masked/Scrollrect(Clone)/Viewport/VerticalLayoutGroup").gameObject.GetComponent<VerticalLayoutGroup>());
                return gam;
            }
            Component.DestroyImmediate(gam.transform.Find("Masked/Scrollrect(Clone)/Viewport/VerticalLayoutGroup").gameObject.GetComponent<VerticalLayoutGroup>());
            var grid = gam.transform.Find("Masked/Scrollrect(Clone)/Viewport/VerticalLayoutGroup").gameObject.AddComponent<GridLayoutGroup>();
            grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            grid.cellSize = new Vector2(200, 175);
            grid.spacing = new Vector2(30, 30);
            grid.constraintCount = 4;
            gam.transform.Find("Masked/Scrollrect(Clone)/Viewport/VerticalLayoutGroup/Spacer_8pt").gameObject.SetActive(false);
            Component.DestroyImmediate(gam.transform.Find("Masked/Scrollrect(Clone)").gameObject.GetComponent<ScrollRect>());
            gam.transform.Find("Masked/Scrollrect(Clone)").gameObject.AddComponent<ScrollRect>();
            var scrollbar =  bigui.Custom_ScrollBar.Scroll(gam.transform.Find("Masked").gameObject, 4.6f, 0.0f, 0.1f, 0.98f);
            gam.transform.Find("Masked/Scrollrect(Clone)").gameObject.GetComponent<ScrollRect>().verticalScrollbar = scrollbar;
            gam.transform.Find("Masked/Scrollrect(Clone)").gameObject.GetComponent<ScrollRect>().content = gam.transform.Find("Masked/Scrollrect(Clone)/Viewport/VerticalLayoutGroup").gameObject.GetComponent<RectTransform>();
            gam.transform.Find("Masked/Scrollrect(Clone)").transform.localPosition = new Vector3(-38, 42.06f, 0);
            return gam;
        }
    }
}
