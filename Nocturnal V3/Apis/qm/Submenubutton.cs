using System;
using UnityEngine;
using Nocturnal.Ui;
using UnityEngine.UI;
namespace Nocturnal.Apis.qm
{
    internal class Submenubutton
    {
        private GameObject _ButtonGameobject { get; set; }
        private Button _ButtonComponent { get; set; }
        private GameObject _ButtonIcon { get; set; }
        private GameObject _Text { get; set; }
        private float? _YValue { get; set; }

        ~Submenubutton()
        {
            this._ButtonGameobject = null;
            this._ButtonComponent = null;
            this._ButtonIcon = null;
            this._Text = null;
            this._YValue = null;
        }
        public Submenubutton(GameObject menu, string text, GameObject menutoopen, string img = null, bool half = false, float X = 628, float Y = 628)
        {
            _YValue = half ? -140 - (Y * (200 / 2) - 45) : -140 - Y * 200;
            _ButtonGameobject = GameObject.Instantiate(Objects._ButtonPrefab, menu.transform).gameObject;
            Component.DestroyImmediate(_ButtonGameobject.transform.Find("Icon").gameObject.GetComponent<VRC.UI.Core.Styles.StyleElement>());
            _ButtonGameobject.name = $"SubBtn_{text}";
            _ButtonGameobject.transform.localEulerAngles = Vector3.zero;
            _ButtonComponent = _ButtonGameobject.GetComponent<Button>();
            _ButtonComponent.onClick.RemoveAllListeners();
            _ButtonComponent.onClick.AddListener(new Action(() =>
            {
                menu.transform.parent.parent.parent.parent.gameObject.SetActive(false);
                menutoopen.gameObject.SetActive(true);
            }
            ));
            _ButtonGameobject.transform.Find("Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = text;
            _ButtonGameobject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = text;
            if (img != null)
            {
                Apis.Change_Image.Loadfrombytes(_ButtonGameobject.transform.Find("Icon").gameObject, img);
                _ButtonGameobject.transform.Find("Icon").gameObject.GetComponent<Image>().color = new Color(0.415f, 0.89f, 0.976f, 1);
            }
            if (X != 628 && Y != 628)
                _ButtonGameobject.transform.localPosition = new Vector3(-350 + X * 240, (float)_YValue);   
            if (!half)
                return;
            _ButtonGameobject.transform.Find("Background").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, -90);
            _ButtonIcon = _ButtonGameobject.transform.Find("Icon").gameObject;
            _ButtonIcon.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            _ButtonIcon.transform.localPosition = new Vector3(-75.5186f, 18.8227f, 0);
            _Text = _ButtonGameobject.transform.Find("Text_H4").gameObject;
            _Text.transform.localScale = new Vector3(0.9f, 0.9f, 1);
            _Text.transform.localPosition = new Vector3(18.58f, -21.0801f, 0);
        }
        
       
    }
}
