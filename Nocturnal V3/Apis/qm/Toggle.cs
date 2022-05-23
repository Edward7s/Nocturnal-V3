using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using MelonLoader;
using Nocturnal.Ui;
namespace Nocturnal.Apis.qm
{
    internal class Toggle
    {
        internal static GameObject toggle(string text, GameObject menu, Action vtrue, Action vfalse, bool prevalue = false,bool half = false,float X = 628, float Y = 628)
        {
            float yvalue = half ? -140 - (Y * (200 / 2) - 45) : -140 - Y * 200;

        

            var instanciated = GameObject.Instantiate(objects.TogglePrebab, menu.transform).gameObject;
            Component.DestroyImmediate(instanciated.GetComponent<VRC.DataModel.Core.BindingComponent>());
            instanciated.name = $"Toggle_{text}";
            var toggle = instanciated.GetComponent<UnityEngine.UI.Toggle>();
            toggle.onValueChanged.RemoveAllListeners();
            toggle.onValueChanged.AddListener((UnityEngine.Events.UnityAction<bool>)Gettoggle);
            var iconoff = instanciated.transform.Find("Icon_Off");
            var iconon = instanciated.transform.Find("Icon_On");
            var textt = instanciated.transform.Find("Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
            textt.text = text;
            var tooltip =instanciated.GetComponent<VRC.UI.Elements.Tooltips.UiToggleTooltip>();
            tooltip.field_Public_String_0 = "Toggle Off " + text;
            tooltip.field_Public_String_1 = "Toggle On " + text;
            Component.Destroy(iconoff.GetComponent<VRC.UI.Core.Styles.StyleElement>());
            Component.Destroy(iconon.GetComponent<VRC.UI.Core.Styles.StyleElement>());

            if (prevalue)
            {
                toggle.isOn = true;
                iconoff.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 0.1f);
                iconon.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 1f);

            }
            else
            {
                toggle.isOn = false;
                iconoff.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 1f);
                iconon.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 0.1f);
            }
            void Gettoggle(bool value)
            {
                var iconoff = instanciated.transform.Find("Icon_Off");
                var iconon = instanciated.transform.Find("Icon_On");
                if (value)
                {
                    iconon.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 1f);
                    iconoff.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 0.1f);

                    vtrue.Invoke();
                }
                else
                {
                    iconon.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 0.1f);
                    iconoff.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 1f);
                    vfalse.Invoke();

                }

            }
            if (X != 628 && Y != 628)
            {
                instanciated.transform.localPosition = new Vector3(-350 + X * 240, yvalue);
            }

            if (!half)
            return instanciated;

            instanciated.transform.Find("Background").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, -90);
            iconoff.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            iconoff.transform.localPosition = new Vector3(-77, -0.7f, 0);
            iconon.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            iconon.transform.localPosition = new Vector3(-77, 35f, 0);
            textt.transform.localScale = new Vector3(0.9f, 0.9f, 1);
            textt.transform.localPosition = new Vector3(20.7601f, - 20.4598f, 0);

            
            return instanciated;

        }
    }
}
