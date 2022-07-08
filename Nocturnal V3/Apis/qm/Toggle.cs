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
    internal class NToggle
    {
        private GameObject _ToggleGameobject { get; set; }
        private Toggle _ToggleComponent { get; set; }
        private Transform _IconOn { get; set; }
        private Transform _IconOff { get; set; }
        private Dictionary<KeyCode[],bool> _Dictionary1 { get; set; } = new Dictionary<KeyCode[],bool>();
        private Action _Action1 { get; set; }
        private Action _Action2 { get; set; }
        private int _KeyBindListPoz { get; set; }
        private string _ButtonName { get; set; }

        private TMPro.TextMeshProUGUI _Text { get; set; }
        private float? _YValue { get; set; }

        ~NToggle()
        {
            this._ToggleGameobject = null;
            this._Text = null;
            this._YValue = null;
            this._Text = null;
        }
        public NToggle(string text, GameObject menu, Action vtrue, Action vfalse, bool prevalue = false, bool half = false, float X = 628, float Y = 628)
        {
            _Action1 = vtrue;
            _Action2 = vfalse;
            _YValue = half ? -329 - (Y * (200 / 2) - 45) : -140 - Y * 200;
            _ToggleGameobject = GameObject.Instantiate(Objects._TogglePrebab, menu.transform).gameObject;
            Component.DestroyImmediate(_ToggleGameobject.GetComponent<VRC.DataModel.Core.BindingComponent>());
            _ToggleGameobject.name = $"Toggle_{text}";
            _ButtonName = _ToggleGameobject.name;
            _ToggleComponent = _ToggleGameobject.GetComponent<Toggle>();
            _ToggleComponent.onValueChanged.RemoveAllListeners();
            _ToggleComponent.onValueChanged.AddListener((UnityEngine.Events.UnityAction<bool>)Gettoggle);
            _IconOff = _ToggleGameobject.transform.Find("Icon_Off");
            _IconOn = _ToggleGameobject.transform.Find("Icon_On");
            _Text = _ToggleGameobject.transform.Find("Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
            _Text.text = text;
            var tooltip = _ToggleGameobject.GetComponent<VRC.UI.Elements.Tooltips.UiToggleTooltip>();
            tooltip.field_Public_String_0 = "Toggle Off " + text;
            tooltip.field_Public_String_1 = "Toggle On " + text;
            Component.Destroy(_IconOff.GetComponent<VRC.UI.Core.Styles.StyleElement>());
            Component.Destroy(_IconOn.GetComponent<VRC.UI.Core.Styles.StyleElement>());
            if (prevalue)
            {
                _ToggleComponent.isOn = true;
                _IconOff.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 0.1f);
                _IconOn.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 1f);
            }
            else
            {
                _ToggleComponent.isOn = false;
                _IconOff.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 1f);
                _IconOn.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 0.1f);
            }
            void Gettoggle(bool value)
            {
           
                if (value)
                {
                    _IconOn.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 1f);
                    _IconOff.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 0.1f);

                    vtrue.Invoke();
                }
                else
                {
                    _IconOn.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 0.1f);
                    _IconOff.GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 1f);
                    vfalse.Invoke();

                }

            }
            if (X != 628 && Y != 628)
                _ToggleGameobject.transform.localPosition = new Vector3(-350 + X * 240,(float)_YValue);
            
            if (!half)
                return;
            _ToggleGameobject.transform.Find("Background").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, -90);
            _IconOff.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            _IconOff.transform.localPosition = new Vector3(-77, -0.7f, 0);
            _IconOn.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            _IconOn.transform.localPosition = new Vector3(-77, 35f, 0);
            _Text.transform.localScale = new Vector3(0.9f, 0.9f, 1);
            _Text.transform.localPosition = new Vector3(20.7601f, -20.4598f, 0);
        }


        private void UpdateBool(bool value)
        {
        }


        private void AddNewKeyBind(bool value)
        {
           
        }

    }
}
