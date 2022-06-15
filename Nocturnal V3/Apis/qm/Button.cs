using System;
using UnityEngine;
using UnityEngine.UI;
using Nocturnal.Ui;
using Il2CppMicrosoft.Win32;

namespace Nocturnal.Apis.qm
{
    internal class NButton
    {
        private GameObject _ButtonGameObj { get; set; }
        private Button _ButtonComp { get; set; }
        private GameObject _ImageGameObj { get; set; }
        private GameObject _TextGameobj { get; set; }
        private float _YValue { get; set; }
        ~NButton()
        {
            this._ButtonGameObj = null;
            this._ButtonComp = null;
            this._TextGameobj = null;
            this._ImageGameObj = null;
        }
      
        public NButton(out GameObject instance, GameObject path, string name, Action action, bool half = false, string img = null, float X = 628, float Y = 628)
        {
            _YValue = half ? -140 - (Y * (200 / 2) - 45) : -140 - Y * 200;
            _ButtonGameObj = GameObject.Instantiate(Objects._ButtonPrefab, path.transform);
            _ButtonGameObj.transform.Find("Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = name;
            _ButtonGameObj.name = "_Button_" + name;
            _ButtonComp = _ButtonGameObj.gameObject.GetComponent<Button>();
            _ButtonComp.onClick.RemoveAllListeners();
            _ButtonComp.onClick.AddListener(action);
            _ButtonGameObj.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = name;
            if (X != 628 && Y != 628)
                _ButtonGameObj.transform.localPosition = new Vector3(-350 + X * 240, _YValue);
            if (img != null)
            {
                _ImageGameObj = _ButtonGameObj.transform.Find("Icon").gameObject;
                Component.DestroyImmediate(_ImageGameObj.GetComponent<VRC.UI.Core.Styles.StyleElement>());
                _ImageGameObj.Loadfrombytes(img);
                _ImageGameObj.GetComponent<Image>().color = new Color(0.415f, 0.89f, 0.976f, 1);
            }
            instance = _ButtonGameObj;
            if (!half)
                return;
            _ButtonGameObj.transform.Find("Background").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, -90);
            _ImageGameObj = _ButtonGameObj.transform.Find("Icon").gameObject;
            _ImageGameObj.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            _ImageGameObj.transform.localPosition = new Vector3(-75.5186f, 18.8227f, 0);
            _TextGameobj = _ButtonGameObj.transform.Find("Text_H4").gameObject;
            _TextGameobj.transform.localScale = new Vector3(0.9f, 0.9f, 1);
            _TextGameobj.transform.localPosition = new Vector3(18.58f, -21.0801f, 0);
        }
        public NButton(GameObject path, string name, Action action, bool half = false, string img = null, float X = 628, float Y = 628)
        {
            _YValue = half ? -140 - (Y * (200 / 2) - 45) : -140 - Y * 200;
            _ButtonGameObj = GameObject.Instantiate(Objects._ButtonPrefab, path.transform);
            _ButtonGameObj.transform.Find("Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = name;
            _ButtonGameObj.name = "_Button_" + name;
            _ButtonComp = _ButtonGameObj.GetComponent<Button>();
            _ButtonComp.onClick.RemoveAllListeners();
            _ButtonComp.onClick.AddListener(action);
            _ButtonGameObj.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = name;
            if (X != 628 && Y != 628)
                _ButtonGameObj.transform.localPosition = new Vector3(-350 + X * 240, _YValue);
            if (img != null)
            {
                _ImageGameObj = _ButtonGameObj.transform.Find("Icon").gameObject;
                _ImageGameObj.GetComponent<VRC.UI.Core.Styles.StyleElement>();
                _ImageGameObj.Loadfrombytes(img);
                _ImageGameObj.GetComponent<Image>().color = new Color(0.415f, 0.89f, 0.976f, 1);
            }
            if (!half)
                return;
            _ButtonGameObj.transform.Find("Background").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, -90);
            _ImageGameObj = _ButtonGameObj.transform.Find("Icon").gameObject;
            _ImageGameObj.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            _ImageGameObj.transform.localPosition = new Vector3(-75.5186f, 18.8227f, 0);
            _TextGameobj = _ButtonGameObj.transform.Find("Text_H4").gameObject;
            _TextGameobj.transform.localScale = new Vector3(0.9f, 0.9f, 1);
            _TextGameobj.transform.localPosition = new Vector3(18.58f, -21.0801f, 0);

        }
       
          
        
    }



}
