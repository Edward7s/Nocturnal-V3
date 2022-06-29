using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
namespace Nocturnal.Apis.bigui
{
    internal class Toggle
    {
        private GameObject _ToggleGameObj { get; set; }
        private UnityEngine.UI.Toggle _ToggleComp { get; set; }
        private UnityEngine.UI.Text _TextComp { get; set; }

        ~Toggle() => _ToggleComp = null;
        public Toggle(Transform Path, String name, Action On, Action off, Vector3 poz, bool prevalue = false,float maxheigt = -1)
        {
            _ToggleGameObj = GameObject.Instantiate(Ui.Objects._BigUiToggle, Path);
            _ToggleGameObj.name = name;
            Component.DestroyImmediate(_ToggleGameObj.GetComponent<UiSettingConfig>());
            _TextComp = _ToggleGameObj.transform.Find("Label").gameObject.GetComponent<Text>();
            _TextComp.verticalOverflow = VerticalWrapMode.Truncate;
            _TextComp.horizontalOverflow = HorizontalWrapMode.Overflow;
            _TextComp.text = name;
            _ToggleComp = _ToggleGameObj.gameObject.GetComponent<UnityEngine.UI.Toggle>();
            _ToggleComp.onValueChanged.RemoveAllListeners();
            _ToggleComp.isOn = prevalue;
            _ToggleComp.transform.localPosition = poz;
            _ToggleComp.transform.localEulerAngles = Vector3.zero;
            _ToggleComp.transform.localScale = Vector3.one;
            _ToggleComp.onValueChanged.AddListener((UnityEngine.Events.UnityAction<bool>)RunT);
            _ToggleGameObj.gameObject.AddComponent<UnityEngine.UI.LayoutElement>().minHeight = maxheigt;
            void RunT(bool toggle)
            {
                if (toggle)
                    On.Invoke();
                else
                    off.Invoke();

            }
        }

    }
}
