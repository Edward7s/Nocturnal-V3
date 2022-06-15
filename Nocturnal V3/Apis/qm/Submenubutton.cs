using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;
using Nocturnal.Ui;
namespace Nocturnal.Apis.qm
{
    internal class Submenubutton
    {

        public Submenubutton(GameObject menu, string text, GameObject menutoopen, string img = null, bool half = false, float X = 628, float Y = 628)
        {
            float yvalue = half ? -140 - (Y * (200 / 2) - 45) : -140 - Y * 200;
            var instanciated = GameObject.Instantiate(Objects._ButtonPrefab, menu.transform).gameObject;
            Component.DestroyImmediate(instanciated.transform.Find("Icon").gameObject.GetComponent<VRC.UI.Core.Styles.StyleElement>());
            instanciated.name = $"SubBtn_{text}";
            instanciated.transform.localEulerAngles = Vector3.zero;
            var buttoni = instanciated.GetComponent<UnityEngine.UI.Button>();
            buttoni.onClick.RemoveAllListeners();
            buttoni.onClick.AddListener(new Action(() =>
            {
                menu.transform.parent.parent.parent.parent.gameObject.SetActive(false);
                menutoopen.gameObject.SetActive(true);
            }
            ));
            instanciated.transform.Find("Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = text;
            instanciated.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = text;
            if (img != null)
            {
                Apis.Change_Image.Loadfrombytes(instanciated.transform.Find("Icon").gameObject, img);
                instanciated.transform.Find("Icon").gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(0.415f, 0.89f, 0.976f, 1);
            }

            if (X != 628 && Y != 628)
                instanciated.transform.localPosition = new Vector3(-350 + X * 240, yvalue);
            
            if (!half)
                return;

            instanciated.transform.Find("Background").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, -90);
            var ico = instanciated.transform.Find("Icon").gameObject;
            ico.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            ico.transform.localPosition = new Vector3(-75.5186f, 18.8227f, 0);
            var texts = instanciated.transform.Find("Text_H4").gameObject;
            texts.transform.localScale = new Vector3(0.9f, 0.9f, 1);
            texts.transform.localPosition = new Vector3(18.58f, -21.0801f, 0);
        }
        
       
    }
}
