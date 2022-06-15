using System;
using Nocturnal.Ui;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
namespace Nocturnal.Apis.qm
{
    public class Page
    {
        public Page(string menuname,string image = null)
        {
          GameObject instanciated = GameObject.Instantiate(Objects._Page, Objects._Page.transform.parent);
          instanciated.name = $"_Page_{menuname}";
          instanciated.transform.rotation = new Quaternion(0, 0, 0, 0);
          Button btn = instanciated.GetComponent<Button>();
          btn.onClick.RemoveAllListeners();
          instanciated.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = menuname;
          VRC.UI.Elements.Controls.MenuTab tab = instanciated.GetComponent<VRC.UI.Elements.Controls.MenuTab>();
          GameObject newmenu = GameObject.Instantiate(Objects._Submenu, Objects._Submenu.transform.parent);
          newmenu.name = "Menu_Nocturanl";
           var devtools = newmenu.GetComponent<VRC.UI.Elements.Menus.DevMenu>();
          devtools.field_Public_String_0 = "QuickMenuNocturnal";
          instanciated.gameObject.SetActive(true);
          tab.field_Public_String_0 = "QuickMenuNocturnal";
          tab.field_Private_MenuStateController_0.field_Private_Dictionary_2_String_UIPage_0.Add("QuickMenuNocturnal", newmenu.GetComponent<VRC.UI.Elements.Menus.DevMenu>());
          var newlist = tab.field_Private_MenuStateController_0.field_Public_ArrayOf_UIPage_0.ToList();
          newlist.Add(devtools);
          tab.field_Private_MenuStateController_0.field_Public_ArrayOf_UIPage_0 = newlist.ToArray();
          newmenu.gameObject.SetActive(true);
          newmenu.gameObject.transform.localPosition = new Vector3(9000, 0, 0);
          btn.onClick.AddListener(new Action(() => {
         {
          newmenu.gameObject.transform.localPosition = new Vector3(0, 512, 0);
          btn.onClick.RemoveAllListeners();
         }
         }));
            GameObject.DestroyImmediate(newmenu.transform.Find("Header_DevTools").gameObject);
            GameObject.DestroyImmediate(newmenu.transform.Find("Scrollrect").gameObject);
            Component.DestroyImmediate(instanciated.transform.Find("Icon").GetComponent<VRC.UI.Core.Styles.StyleElement>());
            if (image != null)
                Change_Image.Loadfrombytes(instanciated.transform.Find("Icon").gameObject, image);
        }
    }
}